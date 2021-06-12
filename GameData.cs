using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace SpecEd
{
    public class StringTableItem
    {
        public String ID { get; set; }
        public String Value { get; set; }
    }

    public enum SpriteType
    {
        Deadly,
        Elevator
    }

    public class Sprite
    {
        public int tileWidth;
        public int tileHeight;
        public int numFrames;
        public int moveType;
        public int moveId;
        public bool generateReverse;
        public bool reverseDirection;
        public SpriteType spriteType;
        public byte[,,] frames;
        public byte[,,] masks;
    }

    public class SpriteInstance
    {
        public int spriteId;
        public int startX;
        public int startY;
        public int deltaMin;
        public int deltaMax;
        public int speed;
        public int colour;
        public string evaluator;
    }

    public enum BlockType
    {
        None,
        Platform,
        Wall,
        Deadly,
        Collectable,
        Info,
        Empty,
        Switch,
        Goodie
    }

    public enum SwitchType
    {
        None,
        Toggle,
        Single,
        Pressure
    }

    public class Tile
    {
        public int Width;
        public int Height;
        public BlockType BlockType;
        public SwitchType SwitchType;
        public CharacterCell[] Cells;

        public Tile()
        { }

        public Tile(int _w, int _h)
        {
            Width = _w;
            Height = _h;
            Cells = new CharacterCell[Width * Height];
            for (int i = 0; i < Cells.Length; ++i)
            {
                Cells[i] = new CharacterCell();
            }
        }

        public CharacterCell getCell(int _x, int _y)
        {
            if (_x < 0 || _x >= Width || _y < 0 || _y >= Height)
            {
                return null;
            }
            return Cells[_y * Width + _x];
        }

        public Tile deepCopy()
        {
            Tile tile = new Tile();
            tile.Width = Width;
            tile.Height = Height;
            tile.BlockType = BlockType;
            tile.SwitchType = SwitchType;

            tile.Cells = new CharacterCell[Width * Height];
            for (int i = 0; i < Cells.Length; ++i)
            {
                tile.Cells[i] = Cells[i].deepCopy();
            }

            return tile;
        }

        public void deepCopy(Tile _rhs)
        {
            Width = _rhs.Width;
            Height = _rhs.Height;
            BlockType = _rhs.BlockType;
            SwitchType = _rhs.SwitchType;

            Cells = new CharacterCell[Width * Height];
            for (int i = 0; i < Cells.Length; ++i)
            {
                Cells[i] = _rhs.Cells[i].deepCopy();
            }
        }
    }

    public class CharacterCell
    {
        public byte[] rows = new byte[8];
        public ColourAttribute colour = new ColourAttribute();
        public int properties;


        public CharacterCell()
        {
            for (int i = 0; i < rows.Length; ++i)
            {
                rows[i] = 0;
            }
        }

        public CharacterCell deepCopy()
        {
            CharacterCell cell = new CharacterCell();
            cell.colour = colour.deepCopy();
            for (int i = 0; i < rows.Length; ++i)
            {
                cell.rows[i] = rows[i];
            }
            return cell;
        }
    }

    public class TileInstance
    {
        public int tileId;
        public int x;
        public int y;
        public int repeatX;
        public int repeatY;
        public string name; // should be globally unique.
    }

    public class Room
    {
        public readonly static int Width = 32;
        public readonly static int Height = 20;

        public List<TileInstance> m_tileInstances = new List<TileInstance>();
        public Dictionary<int, SpriteInstance> m_spriteInstances = new Dictionary<int, SpriteInstance>();
        public String m_title = "<unnamed>";
        public String m_infoID;
    }

    public class StaticGraphic
    {
        public Tile m_tile;
        public String m_name;

        public StaticGraphic()
        {
            m_name = "<unnamed>";
        }

        public override string ToString()
        {
            return m_name;
        }
    }

    public class AudioItem
    {
        public string Title;
        public string Contents;
        public override string ToString()
        {
            return Title;
        }
    }
    
    public class GameData
    {
        public static readonly uint NumRoomsX = 32;
        public static readonly uint NumRoomsY = 8;

        private static GameData s_instance;
        public static GameData get()
        {
            return s_instance;
        }

        public class TileEventArgs : EventArgs
        {
            public int TileId { get; private set; }
            public Tile Tile { get; private set; }

            public TileEventArgs(int _tileId, Tile _tile)
            {
                TileId = _tileId;
                Tile = _tile;
            }
        }

        public class SpriteEventArgs : EventArgs
        {
            public int SpriteId { get; private set; }
            public Sprite Sprite { get; private set; }

            public SpriteEventArgs(int _spriteId, Sprite _sprite)
            {
                SpriteId = _spriteId;
                Sprite = _sprite;
            }
        }

        public int m_nextTileID = 1;
        public int m_nextSpriteId = 1;
        public int m_playerSprite = -1;
        public int m_nextSpriteInstanceId = 1;

        public event EventHandler<TileEventArgs> TileAdded;
        public event EventHandler<TileEventArgs> TileRemoved;
        public event EventHandler<SpriteEventArgs> SpriteAdded;
        public event EventHandler<SpriteEventArgs> SpriteRemoved;
        public event EventHandler PlayerSpriteChanged;

        public Dictionary<uint, Room> m_rooms = new Dictionary<uint, Room>();
        public Dictionary<int, Tile> m_tiles = new Dictionary<int, Tile>();
        public Dictionary<int, Sprite> m_sprites = new Dictionary<int, Sprite>();
        public List<StaticGraphic> m_statics = new List<StaticGraphic>();
        public List<AudioItem> m_audioItems = new List<AudioItem>();
        public BindingList<StringTableItem> m_strings = new BindingList<StringTableItem>();

        public GameData()
        {
            s_instance = this;
        }

        public void save( string _filename )
        {
            string output = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(_filename, output);
        }

        public void addStatic( StaticGraphic _static )
        {
            m_statics.Add(_static);
        }

        public void deleteStatic(StaticGraphic _static)
        {
            m_statics.Remove(_static);
        }

        public void addTile( Tile _tile )
        {
            int tileId = m_nextTileID++;
            m_tiles.Add(tileId, _tile);
            OnTileAdded(tileId, _tile);
        }

        public void removeTile( int _tileId )
        {
            if (m_tiles.ContainsKey(_tileId))
            {
                Tile tile = m_tiles[_tileId];
                m_tiles.Remove(_tileId);
                OnTileRemoved(_tileId, tile);
            }
        }

        protected virtual void OnTileAdded( int tileId, Tile _tile )
        {
            TileAdded?.Invoke(this, new TileEventArgs(tileId, _tile));
        }

        protected virtual void OnTileRemoved(int tileId, Tile _tile)
        {
            TileAdded?.Invoke(this, new TileEventArgs(tileId, _tile));
        }

        public Room getRoom(uint _x, uint _y, bool _createIfEmpty)
        {
            uint hash = getRoomHash(_x, _y);
            Room room;
            m_rooms.TryGetValue(hash, out room);
            if (room == null && _createIfEmpty)
            {
                room = new Room();
                m_rooms.Add(hash, room);
            }

            return room;
        }

        public static uint getRoomHash(uint _x, uint _y)
        {
            return ((_x & (NumRoomsX-1)) << 3) | (_y & (NumRoomsY-1));
        }

        public static Point getRoomLocation(uint _hash)
        {
            return new Point(
                (int)((_hash >> 3) & (NumRoomsX - 1)),
                (int)(_hash & (NumRoomsY - 1)));
        }

        public int addSprite(int _tileWidth, int _tileHeight, int _nFrames, int _movementType, SpriteType _spriteType)
        {
            int spriteId = m_nextSpriteId++;
            Sprite sprite = new Sprite();
            sprite.tileWidth = _tileWidth;
            sprite.tileHeight = _tileHeight;
            sprite.numFrames = _nFrames;
            sprite.moveType = _movementType;
            sprite.spriteType = _spriteType;
            sprite.frames = new byte[_nFrames, _tileWidth, _tileHeight*8];
            m_sprites.Add(spriteId, sprite);
            OnSpriteAdded(spriteId, sprite);
            return spriteId;
        }

        public int addSpriteInstance(Room _room, SpriteInstance _instance)
        {
            int instanceId = m_nextSpriteInstanceId++;
            _room.m_spriteInstances.Add(instanceId, _instance);
            return instanceId;
        }

        public void setPlayerSprite(int _spriteId)
        {
            m_playerSprite = _spriteId;
            OnPlayerSpriteChanged();
        }

        protected virtual void OnSpriteAdded(int _spriteId, Sprite _sprite)
        {
            SpriteAdded?.Invoke(this, new SpriteEventArgs(_spriteId, _sprite));
        }

        protected virtual void OnSpriteRemoved(int _spriteId, Sprite _sprite)
        {
            SpriteAdded?.Invoke(this, new SpriteEventArgs(_spriteId, _sprite));
        }

        protected virtual void OnPlayerSpriteChanged()
        {
            PlayerSpriteChanged?.Invoke(this, EventArgs.Empty);
        }

        public void deleteTile(int _tileId)
        {
            foreach (var room in m_rooms.Values)
            {
                room.m_tileInstances = room.m_tileInstances.Where(instance => instance.tileId != _tileId).ToList();
            }

            m_tiles.Remove(_tileId);
        }

        public void deleteSprite(int _spriteId)
        {
            foreach (var room in m_rooms.Values)
            {
                var toRemove = room.m_spriteInstances.Where(instance => instance.Value.spriteId == _spriteId).Select(instance => instance.Key).ToList();
                foreach (var id in toRemove)
                {
                    room.m_spriteInstances.Remove(id);
                }
            }

            m_sprites.Remove(_spriteId);
        }

        public TileInstance getTileInstanceInCell(Room _room, int _cx, int _cy)
        {
            foreach (var ti in _room.m_tileInstances)
            {
                var tile = m_tiles[ti.tileId];
                int x2 = ti.x + ((ti.repeatX + 1) * tile.Width);
                int y2 = ti.y + ((ti.repeatY + 1) * tile.Height);

                if (_cx >= ti.x && _cx < x2 && _cy >= ti.y && _cy < y2)
                {
                    return ti;
                }
            }

            return null;
        }
    }
}
