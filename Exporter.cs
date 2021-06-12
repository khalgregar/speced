using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SpecEd
{
    public enum RoomCompressionType
    {
        L8B8,
        L4B4
    }

    public class Exporter
    {
        
        public Exporter()
        {
        }

        private void shiftFrame(byte[] _frame)
        {
            for (int y = 0, i = 0; y < 16; ++y, i += 3)
            {
                int a = (_frame[i] << 16) | (_frame[i + 1] << 8) | _frame[i];
                a >>= 1;
                _frame[i] = (byte)((a >> 16) & 0xff);
                _frame[i+1] = (byte)((a >> 8) & 0xff);
                _frame[i+2] = (byte)(a & 0xff);
            }
        }

        private byte reverseByte(byte _byte)
        {
            byte a = 0;
            for (int i = 0; i < 8; ++i)
            {
                a |= (byte)((_byte & (1 << i)) != 0 ? (1 << (7 - i)) : 0);
            }
            
            return a;
        }

        private void mirrorFrame(byte[] _frame)
        {
            for (int y = 0, i = 0; y < 16; ++y, i += 3)
            {
                byte a = _frame[i];
                byte b = _frame[i+2];
                _frame[i] = reverseByte(b);
                _frame[i + 1] = reverseByte(_frame[i + 1]);
                _frame[i+2] = reverseByte(a);
            }
        }

        private byte[] buildPlayerFrames(Sprite _sprite)
        {
            byte[] bytes;
            using (var s = new MemoryStream())
            {
                // Scanlines are interleaved bmp/mask
                for (int frameIdx = 0; frameIdx < 16; ++frameIdx)
                {
                    for (int y = 0, i = 0; y < 16; ++y)
                    {
                        s.WriteByte(_sprite.frames[frameIdx, 0, y]);
                        s.WriteByte(_sprite.frames[frameIdx, 1, y]);
                        s.WriteByte( (byte)~_sprite.masks[frameIdx, 0, y]);
                        s.WriteByte( (byte)~_sprite.masks[frameIdx, 1, y]);
                    }
                }
                bytes = s.ToArray();
            }
            return bytes;
        }

        public void export128( GameData _gameData, String _template, String _filename, TextWriter _log )
        {
            _log.WriteLine("Exporting {0} ", _filename);
            
            // Tiles and sprites that aren't used aren't exported.

            byte[] bank0 = null;
            byte[] bank1 = null;
            byte[] bank3 = null;
            byte[] bank4 = null;
            byte[] bank6 = null;

            var tileIdLookup = new Dictionary<int, int>();  // <Tile ID, exported ID>
            List<int> tileIds = new List<int>();

            var spriteIdLookup = new Dictionary<int, int>();  // <Sprite ID, exported ID>
            var spriteIds = new List<int>();
            

            if (!_gameData.m_sprites.ContainsKey(_gameData.m_playerSprite))
            {
                throw new Exception("Player sprite not set or invalid.");
            }

            spriteIds.Add(_gameData.m_playerSprite);

            // Build global object name table

            var objectNames = new Dictionary<string, int>();
            foreach (var pair in _gameData.m_rooms)
            {
                var room = pair.Value;
                foreach (var ti in room.m_tileInstances)
                {
                    if (!string.IsNullOrWhiteSpace(ti.name))
                    {
                        objectNames.Add(ti.name, objectNames.Count);
                    }
                }
            }

            // STRINGS (BANK 6)
            // Strings 0-255 are room titles
            // Strings >= 256 are misc strings, in game IDs are -256

            var stringLookup = new Dictionary<String, int>();
            
            _log.WriteLine("\nWriting BANK 6...");
            using (var s = new MemoryStream())
            {
                var titleOffsets = new uint[256];
                var stringOffsets = new List<uint>();

                for (uint roomHash = 0; roomHash < 256; ++roomHash)
                {
                    Room room;
                    if (_gameData.m_rooms.TryGetValue(roomHash, out room))
                    {
                        titleOffsets[roomHash] = (uint)s.Position;
                        byte[] titleBytes = Encoding.ASCII.GetBytes(room.m_title);
                        s.WriteByte((byte)titleBytes.Length);
                        s.Write(titleBytes, 0, titleBytes.Length);
                    }
                }


                foreach (StringTableItem item in _gameData.m_strings)
                {
                    if (!String.IsNullOrEmpty(item.ID) && !String.IsNullOrEmpty(item.ID))
                    {
                        stringOffsets.Add((uint)s.Position);
                        stringLookup.Add(item.ID, stringLookup.Count);
                        string str = item.Value.Replace(@"\n", "\n");
                        byte[] strBytes = Encoding.ASCII.GetBytes(str);
                        s.WriteByte((byte)strBytes.Length);
                        s.Write(strBytes, 0, strBytes.Length);
                    }
                }

                uint baseAddr = 0xc000 + (uint)((titleOffsets.Length + stringOffsets.Count) * 2);
                using (var bankStream = new MemoryStream())
                {
                    foreach (uint offset in titleOffsets)
                    {
                        writeAddress16(bankStream, baseAddr+offset);
                    }

                    foreach (uint offset in stringOffsets)
                    {
                        writeAddress16(bankStream, baseAddr+offset);
                    }

                    s.Seek(0, SeekOrigin.Begin);
                    s.CopyTo(bankStream);
                    bank6 = bankStream.ToArray();
                }
            }

            // ROOMS (BANK 0)

            using (var s = new MemoryStream())
            {
                _log.WriteLine("\nWriting BANK 0...");

                var roomOffsets = new uint[256];

                for (uint roomHash = 0; roomHash < 256; ++roomHash)
                {
                    writeAddress16(s, 0);
                }

                _log.WriteLine("C000 - C1FF : Room data pointers");

                // Object masks
                for (uint i = 0; i < 256; ++i)
                {
                    s.WriteByte(0);
                }

                int numRoomBytes = 0;
                int maxRoomBytes = 0;
                Point? maxRoomId = null;
                int numRooms = 0;
                for (uint roomHash = 0; roomHash < 256; ++roomHash)
                {
                    int startPosition = (int)s.Position;

                    Room room;
                    if (_gameData.m_rooms.TryGetValue(roomHash, out room))
                    {
                        ++numRooms;

                        roomOffsets[roomHash] = (uint)s.Position;

                        var tileGroups = room.m_tileInstances.GroupBy(x => x.tileId).ToList();
                        var spriteGroups = room.m_spriteInstances.Values.GroupBy(x => x.spriteId).ToList();
                        var evaluators = new Dictionary<int, string>();

                        int roomInfoID = 0;
                        if (!string.IsNullOrWhiteSpace(room.m_infoID))
                        {
                            if (!stringLookup.TryGetValue(room.m_infoID, out roomInfoID))
                            {
                                Point loc = GameData.getRoomLocation(roomHash);
                                _log.Write("Room [{0},{1}] has invalid info ID '{2}'", loc.X, loc.Y, room.m_infoID);
                            }
                        }

                        s.WriteByte((byte)roomInfoID);
                        s.WriteByte((byte)tileGroups.Count);
                        s.WriteByte((byte)spriteGroups.Count);
                        
                        // Write Tile instances
                        {
                            foreach (var group in tileGroups)
                            {
                                int tileId;
                                if (!tileIdLookup.TryGetValue(group.Key, out tileId))
                                {
                                    tileId = tileIds.Count;
                                    tileIdLookup.Add(group.Key, tileId);
                                    tileIds.Add(group.Key);
                                }

                                s.WriteByte((byte)tileId);
                                s.WriteByte((byte)group.Count());
                                foreach (TileInstance inst in group)
                                {
                                    

                                    int x = inst.x | (inst.repeatX << 5);
                                    int y = inst.y | (inst.repeatY << 5);
                                    s.WriteByte((byte)x);
                                    s.WriteByte((byte)y);

                                    if (!string.IsNullOrWhiteSpace(inst.name))
                                    {
                                        int objectId = objectNames[inst.name];
                                        s.WriteByte((byte)objectId);
                                    }

                                    if (inst.x + inst.repeatX > 31 || inst.y + inst.repeatY >= 20)
                                    {
                                        _log.WriteLine("**ERROR*** TileInstance at [{0},{1}] in Room exceeds boundaries", inst.x, inst.y);
                                    }

                                    
                                }
                            }
                        }

                        // Write Sprite instances
                        {
                            int spriteIdx = 0;
                            foreach (var group in spriteGroups)
                            {
                                int spriteId;
                                if (!spriteIdLookup.TryGetValue(group.Key, out spriteId))
                                {
                                    spriteId = spriteIds.Count;
                                    spriteIdLookup.Add(group.Key, spriteId);
                                    spriteIds.Add(group.Key);
                                }

                                var spriteDef = _gameData.m_sprites[group.Key];

                                s.WriteByte((byte)spriteId);
                                s.WriteByte((byte)group.Count());
                                
                                foreach (SpriteInstance sprite in group)
                                {
                                    if (!String.IsNullOrWhiteSpace(sprite.evaluator))
                                    {
                                        evaluators.Add(spriteIdx, sprite.evaluator);
                                    }
                                    
                                    s.WriteByte((byte)(sprite.startX*8));
                                    s.WriteByte((byte)(sprite.startY*8));

                                    int extentMin = 0;
                                    int extentMax = 0;
                                    if (!(sprite.deltaMin == 0 && sprite.deltaMax == 0))
                                    {
                                        switch (spriteDef.moveType)
                                        {
                                            case 0:
                                                extentMin = (sprite.startX - sprite.deltaMin) * 8;
                                                extentMax = (sprite.startX + sprite.deltaMax) * 8;
                                                break;
                                            default:
                                                extentMin = (sprite.startY - sprite.deltaMin) * 8;
                                                extentMax = (sprite.startY + sprite.deltaMax) * 8;
                                                break;
                                        }
                                    }
                                    
                                    s.WriteByte((byte)extentMin);
                                    s.WriteByte((byte)extentMax);
                                    s.WriteByte((byte)(sprite.colour));
                                    s.WriteByte((byte)sprite.speed);

                                    ++spriteIdx;
                                }
                            }
                        }

                        int nEvalBytes = 0;
                        using (var evalStream = new MemoryStream())
                        {
                            var evalParser = new EvaluatorParser(objectNames);
                            foreach (var eval in evaluators)
                            {
                                evalStream.WriteByte((byte)eval.Key);    // sprite index
                                try
                                {
                                    var evalBytes = evalParser.Parse(eval.Value);
                                    evalStream.Write(evalBytes, 0, evalBytes.Length);
                                }
                                catch (Exception e)
                                {
                                    _log.Write("Error in evaluator '{0}': {1}", eval.Value, e.Message);
                                }
                            }

                            nEvalBytes = (int)evalStream.Length;
                            s.WriteByte((byte)nEvalBytes);
                            if (evalStream.Length > 0)
                            {
                                evalStream.Seek(0, SeekOrigin.Begin);
                                evalStream.CopyTo(s);
                            }
                        }
                        

                        int nBytes = (int)s.Position - startPosition;
                        numRoomBytes += nBytes;
                        if (maxRoomBytes < nBytes)
                        {
                            maxRoomBytes = nBytes;
                            maxRoomId = GameData.getRoomLocation(roomHash);
                        }

                        {
                            var loc = GameData.getRoomLocation(roomHash);
                            _log.WriteLine("Room [{0},{1}] : {2} bytes, {3} evaluator bytes", loc.X, loc.Y, nBytes, nEvalBytes);
                        }
                        
                    }
                }

                s.Seek(0, SeekOrigin.Begin);
                for (int i = 0; i < 256; ++i)
                {
                    uint offset = roomOffsets[i];
                    if (offset > 0)
                    {
                        offset += 0xc000;
                    }
                    writeAddress16(s, offset);
                }

                bank0 = s.ToArray();

                
                _log.WriteLine("C200 - {0:X4} : Room data, {1} rooms, {2} bytes", 0xc000+(numRoomBytes-1), numRooms, numRoomBytes);
                if (maxRoomId.HasValue)
                {
                    _log.WriteLine("Largest room - [{0},{1}], {2} bytes", maxRoomId.Value.X, maxRoomId.Value.Y, maxRoomBytes);
                }
                
            }

            // TILES (BANK 1)

            using (var s = new MemoryStream())
            {
                List<uint> offsets = new List<uint>();

                foreach (int tileId in tileIds)
                {
                    writeAddress16(s, 0);
                }

                foreach (int tileId in tileIds)
                {
                    Tile tile = _gameData.m_tiles[tileId];

                    if (tile.Cells.Length != tile.Width * tile.Height)
                    {
                        throw new Exception("Tile cells length does not match width * height.");
                    }

                    offsets.Add((uint)s.Position);

                    if (tile.BlockType == BlockType.None)
                    {
                        tile.BlockType = BlockType.Empty;
                    }

                    s.WriteByte((byte)tile.Width);
                    s.WriteByte((byte)tile.Height);
                    s.WriteByte((byte)tile.BlockType);
                    s.WriteByte((byte)tile.SwitchType);

                    // Write bitmaps
                    for (int y = 0; y < tile.Height; ++y)
                    {
                        for (int x = 0; x < tile.Width; ++x)
                        {
                            CharacterCell cell = tile.getCell(x, y);
                            s.Write(cell.rows, 0, 8);
                            s.WriteByte(cell.colour.asByte());
                        }

                    }
                }

                s.Seek(0, SeekOrigin.Begin);
                foreach (uint offset in offsets)
                {
                    writeAddress16(s, 0xc000 + offset);
                }

                bank1 = s.ToArray();
            }

            // SPRITES (BANK 3)

            using (var s = new MemoryStream())
            {
                var offsets = new List<uint>(spriteIds.Count);

                foreach (int spriteId in spriteIds)
                {
                    writeAddress16(s, 0);
                }

                foreach (int spriteId in spriteIds)
                {
                    offsets.Add((uint)s.Position);

                    Sprite sprite = _gameData.m_sprites[spriteId];
                    s.WriteByte((byte)sprite.tileWidth);
                    s.WriteByte((byte)(sprite.tileHeight * 8));
                    s.WriteByte((byte)sprite.numFrames);

                    // Flags
                    // 0: Movement type, 0=H, 1=V
                    // 1-4: Custom movement ID (0-15), 0=auto, 15=static
                    // 5: Deadly
                    // 6: Generate Reverse
                    // 7: Reverse direction at start

                    byte flags = (byte)sprite.moveType;
                    if (sprite.generateReverse)
                    {
                        flags |= 1 << 6;
                    }

                    if (sprite.reverseDirection)
                    {
                        flags |= 1 << 7;
                    }

                    if (sprite.spriteType == SpriteType.Deadly)
                    {
                        flags |= 1 << 5;
                    }

                    flags &= 0b11100001;
                    flags |= (byte)(sprite.moveId << 1);

                    
                    s.WriteByte(flags);

                    for (int frame = 0; frame < sprite.numFrames; ++frame)
                    {
                        for (int y = 0; y < sprite.tileHeight*8; ++y)
                        {
                            for (int x = 0; x < sprite.tileWidth; ++x)
                            {
                                s.WriteByte(sprite.frames[frame, x, y]);
                            }
                        }

                        if (sprite.masks != null)
                        {
                            for (int y = 0; y < sprite.tileHeight * 8; ++y)
                            {
                                for (int x = 0; x < sprite.tileWidth; ++x)
                                {
                                    s.WriteByte(sprite.masks[frame, x, y]);
                                }
                            }
                        }
                    }
                }

                s.Seek(0, SeekOrigin.Begin);
                foreach (uint offset in offsets)
                {
                    writeAddress16(s, 0xc000 + offset);
                }

                bank3 = s.ToArray();
            }

            // STATIC GRAPHICS + AUDIO (BANK 4)

            using (var s = new MemoryStream())
            {
                writeAddress16(s, 0); // AUDIO TABLE PTR


                uint[] ptrs = new uint[_gameData.m_statics.Count];

                foreach (var sg in _gameData.m_statics)
                {
                    writeAddress16(s,0);
                }

                for (int i = 0; i < _gameData.m_statics.Count; ++i)
                {
                    ptrs[i] = (uint)(s.Position);
                    StaticGraphic sg = _gameData.m_statics[i];
                    Tile tile = sg.m_tile;

                    s.WriteByte((byte)tile.Width);
                    s.WriteByte((byte)tile.Height);
                    

                    for (int ty = 0; ty < tile.Height; ++ty)
                    {
                        for (int row = 0; row < 8; ++row)
                        {
                            for (int tx = 0; tx < tile.Width; ++tx)
                            {
                                CharacterCell cell = tile.getCell(tx, ty);
                                s.WriteByte(cell.rows[row]);
                            }
                        }
                    }

                    for (int ty = 0; ty < tile.Height; ++ty)
                    {
                        for (int tx = 0; tx < tile.Width; ++tx)
                        {
                            CharacterCell cell = tile.getCell(tx, ty);
                            s.WriteByte(cell.colour.asByte());
                        }
                    }
                }

                // Audio

                long audioTableOffset = s.Position;
                uint[] audioTable = new uint[_gameData.m_audioItems.Count];

                for (int i = 0; i < _gameData.m_audioItems.Count; ++i)
                {
                    writeAddress16(s, 0);
                }

                for (int i = 0; i < _gameData.m_audioItems.Count; ++i)
                {
                    AudioItem audioItem = _gameData.m_audioItems[i];
                    audioTable[i] = (uint)(0xc000 + s.Position);
                    AudioModule audioModule = AudioModule.Parse(audioItem.Contents);
                    byte[] audioBytes = audioModule.export(audioModule, audioTable[i]);
                    s.Write(audioBytes, 0, audioBytes.Length);
                }
                
                // Patch pointers

                s.Seek(0, SeekOrigin.Begin);
                writeAddress16(s, (uint)(0xc000 + audioTableOffset));
                foreach (uint offset in ptrs)
                {
                    writeAddress16(s, 0xc000 + offset);
                }

                s.Seek(audioTableOffset, SeekOrigin.Begin);
                foreach (var ptr in audioTable)
                {
                    writeAddress16(s, ptr);
                }
                
                bank4 = s.ToArray();
            }
            

            // Write files.

            byte[] file = File.ReadAllBytes(_template);

            /*

            27          - BANK 5    $4000
            16411       - BANK 2    $8000
            32795       - BANK 0    $d000
            49183       - BANK 1
            65567       - BANK 3
            81951       - BANK 4
            98335       - BANK 6
            114719      - BANK 7

            49179       - PC (word)
            49181       - 0x7ffd port

            */

            int sp = file[23] | (file[24] << 8);
            int pc = file[49179] | (file[49180] << 8);
            int port = file[49181];

            // Write player frames to display buffer.
            {
                byte[] playerFrames = buildPlayerFrames(_gameData.m_sprites[_gameData.m_playerSprite]);
                playerFrames.CopyTo(file, 27 + 0x2000);
            }

            bank0.CopyTo(file, 32795);
            _log.WriteLine("BANK 0: {0} bytes, {1}% free", bank0.Length, (int)(((float)(16384-bank0.Length)/(float)16384)*100));

            bank1.CopyTo(file, 49183);
            _log.WriteLine("BANK 1: {0} bytes, {1}% free", bank1.Length, (int)(((float)(16384-bank1.Length)/(float)16384)*100));

            bank3.CopyTo(file, 65567);
            _log.WriteLine("BANK 3: {0} bytes, {1}% free", bank3.Length, (int)(((float)(16384-bank3.Length)/(float)16384)*100));

            bank4.CopyTo(file, 81951);
            _log.WriteLine("BANK 4: {0} bytes, {1}% free", bank4.Length, (int)(((float)(16384-bank4.Length)/(float)16384)*100));

            bank6.CopyTo(file, 98335);
            _log.WriteLine("BANK 6: {0} bytes, {1}% free", bank6.Length, (int)(((float)(16384-bank6.Length)/(float)16384)*100));

            cs_custom.CopyTo(file, 14875 + 16 * 8);
            atari_cs_symbols.CopyTo(file, 14875 + 32 * 8);
            atari_cs_numbers.CopyTo(file, 14875 + 48 * 8);
            atari_cs_lower.CopyTo(file, 14875 + 97 * 8);
            atari_cs_caps.CopyTo(file, 14875 + 65 * 8);

            // Write note table to BANK 4 @ $ff00

            using (var s = new MemoryStream())
            {
                foreach (int note in AudioModule.s_noteTable)
                {
                    s.WriteByte((byte)(note & 0xff));
                    s.WriteByte((byte)((note >> 8) & 0xff));
                }

                byte[] notes = s.ToArray();
                notes.CopyTo(file, 81951 + (0xff00 - 0xc000));
            }
            
            File.WriteAllBytes(_filename, file);
        }

        
        
        public static void writeAddress16(Stream _stream, uint _address)
        {
            byte l = (byte)(_address & 0xff);
            byte h = (byte)((_address>>8) & 0xff);
            _stream.WriteByte(l);
            _stream.WriteByte(h);
        }

        
        private static byte[] cs_custom = {
            0xff,0x80,0x80,0x9f,0x90,0x90,0x90,0x90,
            0xff,0x00,0x00,0xff,0x00,0x00,0x00,0x00,
            0xff,0x01,0x01,0xf9,0x09,0x09,0x09,0x09,
            0x90,0x90,0x90,0x90,0x90,0x90,0x90,0x90,
            0x09,0x09,0x09,0x09,0x09,0x09,0x09,0x09,
            0x90,0x90,0x90,0x90,0x9f,0x80,0x80,0xff,
            0x00,0x00,0x00,0x00,0xff,0x00,0x00,0xff,
            0x09,0x09,0x09,0x09,0xf9,0x01,0x01,0xff,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
            0x00,0x00,0x00,0x00,0x00,0x18,0x18,0x00,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00
        };

        private static byte[] atari_cs_symbols = {
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
            0x00,0x18,0x18,0x18,0x18,0x00,0x18,0x00,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
            0x00,0x18,0x18,0x18,0x00,0x00,0x00,0x00,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
            0x00,0x66,0x3c,0xff,0x3c,0x66,0x00,0x00,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
            0x00,0x00,0x00,0x00,0x00,0x18,0x18,0x30,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
            0x00,0x00,0x00,0x00,0x00,0x18,0x18,0x00,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00
        };

        private static byte[] atari_cs_numbers = {
            0x00,0x3c,0x66,0x6e,0x76,0x66,0x3c,0x00,
            0x00,0x18,0x38,0x18,0x18,0x18,0x7e,0x00,
            0x00,0x3c,0x66,0x0c,0x18,0x30,0x7e,0x00,
            0x00,0x7e,0x0c,0x18,0x0c,0x66,0x3c,0x00,
            0x00,0x0c,0x1c,0x3c,0x6c,0x7e,0x0c,0x00,
            0x00,0x7e,0x60,0x7c,0x06,0x66,0x3c,0x00,
            0x00,0x3c,0x60,0x7c,0x66,0x66,0x3c,0x00,
            0x00,0x7e,0x06,0x0c,0x18,0x30,0x30,0x00,
            0x00,0x3c,0x66,0x3c,0x66,0x66,0x3c,0x00,
            0x00,0x3c,0x66,0x3e,0x06,0x0c,0x38,0x00
        };

        private static byte[] atari_cs_lower = {
            0x00,0x00,0x3c,0x06,0x3e,0x66,0x3e,0x00,    // A
            0x00,0x60,0x60,0x7c,0x66,0x66,0x7c,0x00,    // B
            0x00,0x00,0x3c,0x60,0x60,0x60,0x3c,0x00,    // C
            0x00,0x06,0x06,0x3e,0x66,0x66,0x3e,0x00,    // D
            0x00,0x00,0x3c,0x66,0x7e,0x60,0x3c,0x00,    // E
            0x00,0x0e,0x18,0x3e,0x18,0x18,0x18,0x00,    // F
            0x00,0x00,0x3e,0x66,0x66,0x3e,0x06,0x7c,    // G
            0x00,0x60,0x60,0x7c,0x66,0x66,0x66,0x00,    // H
            0x00,0x18,0x00,0x38,0x18,0x18,0x3c,0x00,    // I
            0x00,0x18,0x00,0x18,0x18,0x18,0x18,0x3c,    // J
            0x00,0x60,0x60,0x6c,0x78,0x6c,0x66,0x00,    // K
            0x00,0x38,0x18,0x18,0x18,0x18,0x3c,0x00,    // L
            0x00,0x00,0x66,0x7f,0x7f,0x6b,0x63,0x00,    // M
            0x00,0x00,0x78,0x66,0x66,0x66,0x66,0x00,    // N
            0x00,0x00,0x3c,0x66,0x66,0x66,0x3c,0x00,    // O
            0x00,0x00,0x7c,0x76,0x76,0x7c,0x60,0x60,    // P
            0x00,0x00,0x3e,0x66,0x66,0x3e,0x06,0x06,    // Q
            0x00,0x00,0x7c,0x66,0x60,0x60,0x60,0x00,    // R
            0x00,0x00,0x3e,0x60,0x3c,0x06,0x7c,0x00,    // S
            0x00,0x18,0x7e,0x18,0x18,0x18,0x0e,0x00,    // T
            0x00,0x00,0x66,0x66,0x66,0x66,0x3e,0x00,    // U
            0x00,0x00,0x66,0x66,0x66,0x3c,0x18,0x00,    // V
            0x00,0x00,0x63,0x6b,0x7f,0x3e,0x36,0x00,    // W
            0x00,0x00,0x66,0x3c,0x18,0x3c,0x66,0x00,    // X
            0x00,0x00,0x66,0x66,0x66,0x3e,0x0c,0x78,    // Y
            0x00,0x00,0x7e,0x0c,0x18,0x30,0x7e,0x00     // Z




        };

        private static byte[] atari_cs_caps = {
            0x00,0x18,0x3c,0x66,0x66,0x7e,0x66,0x00,    // A
            0x00,0x7c,0x66,0x7c,0x66,0x66,0x7c,0x00,    // B
            0x00,0x3c,0x66,0x60,0x60,0x66,0x3c,0x00,    // C
            0x00,0x78,0x6c,0x66,0x66,0x6c,0x78,0x00,    // D
            0x00,0x7e,0x60,0x7c,0x60,0x60,0x7e,0x00,    // E
            0x00,0x7e,0x60,0x7c,0x60,0x60,0x60,0x00,    // F
            0x00,0x3e,0x60,0x60,0x6e,0x66,0x3e,0x00,    // G
            0x00,0x66,0x66,0x7e,0x66,0x66,0x66,0x00,    // H
            0x00,0x7e,0x18,0x18,0x18,0x18,0x7e,0x00,    // I
            0x00,0x06,0x06,0x06,0x06,0x66,0x3c,0x00,    // J
            0x00,0x66,0x6c,0x78,0x78,0x6c,0x66,0x00,    // K
            0x00,0x60,0x60,0x60,0x60,0x60,0x7e,0x00,    // L
            0x00,0x63,0x77,0x7f,0x6b,0x63,0x63,0x00,    // M
            0x00,0x66,0x76,0x7e,0x7e,0x6e,0x66,0x00,    // N
            0x00,0x3c,0x66,0x66,0x66,0x66,0x3c,0x00,    // O
            0x00,0x7c,0x66,0x66,0x7c,0x60,0x60,0x00,    // P
            0x00,0x3c,0x66,0x66,0x66,0x6c,0x66,0x00,    // Q
            0x00,0x7c,0x66,0x66,0x7c,0x6c,0x66,0x00,    // R
            0x00,0x3c,0x60,0x3c,0x06,0x06,0x3c,0x00,    // S
            0x00,0x7e,0x18,0x18,0x18,0x18,0x18,0x00,    // T
            0x00,0x66,0x66,0x66,0x66,0x66,0x7e,0x00,    // U
            0x00,0x66,0x66,0x66,0x66,0x3c,0x18,0x00,    // V
            0x00,0x63,0x63,0x6b,0x7f,0x77,0x63,0x00,    // W
            0x00,0x66,0x66,0x3c,0x3c,0x66,0x66,0x00,    // X
            0x00,0x66,0x66,0x3c,0x18,0x18,0x18,0x00,    // Y
            0x00,0x7e,0x0c,0x18,0x30,0x60,0x7e,0x00     // Z




        };
    }
}
