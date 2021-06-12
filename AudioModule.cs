using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

/*
    EXPORT FORMAT
    -------------

    uint8       SPEED               b0-b2
                CHANNEL_MASK        b3-b5
    uint16      SAMPLES_PTR
    uint16      LINES_PTR
    uint16[]    PATTERN_PTRS
    
    SAMPLE[]
    ORNAMENT[]
    PATTERN[]
    CHANNEL[]

    SAMPLE FORMAT
    -------------

    uint8   SAMPLE_ID
    uint8   NUM_LINES
    uint8   LOOP_INDEX
    SAMPLE_LINE[]

    SAMPLE_LINE FORMAT
    ------------------

    uint8   FLAGS
    0:      ToneEnabled
    1:      NoiseEnabled
    2:      EnvelopeEnabled
    3:      ToneRelative
    4:      NoiseRelative

    uint16  TONE_VALUE
    uint8   NOISE_VALUE
    uint8   VOLUME_VALUE
    uint8   VOLUME_DELTA

    ORNAMENT FORMAT
    ---------------

    uint8 ORNAMENT_ID
    uint8 NUM_LINES
    uint8 LOOP_INDEX
    uin8[] LINES

    PATTERN FORMAT
    --------------

    uint8 NUM_LINES
    CHANNEL[] - laid out as ABC, dependent on enabled channels.
 */

namespace SpecEd
{
    public class AudioModule
    {
        public bool ChannelAEnabled { get; private set; }
        public bool ChannelBEnabled { get; private set; }
        public bool ChannelCEnabled { get; private set; }
        public List<int> PlayOrder { get; private set; }
        public int PlayOrderLoop { get; private set; }
        public string Title { get; private set; }
        public int NoteTable { get; private set; }
        public int Speed { get; private set; }
        public Pattern[] Patterns { get; private set; }
        public Sample[] Samples { get; private set; }
        public Ornament[] Ornaments { get; private set; }

        private readonly Dictionary<string, int> m_uniquePatterns = new Dictionary<string,int>();


        public byte[] export(AudioModule _module, uint _baseAddress)
        {
            var channelLookup = new Dictionary<string, int>();
            
            byte[] moduleBytes;

            uint[] patternTable = new uint[_module.Patterns.Length];
            uint[] sampleTable = new uint[_module.Samples.Length];
            uint[] ornamentTable = new uint[_module.Ornaments.Length];

            uint playOrderPtr;
            uint channelsPtr;

            // Build channel table
            byte[] channelData = null;
            using (var channelStr = new MemoryStream())
            {
                foreach (var pattern in _module.Patterns)
                {
                    foreach (var line in pattern.Lines)
                    {
                        for (int i = 0; i < 3; ++i)
                        {
                            Pattern.Line.Channel channel = null;
                            switch (i)
                            {
                                case 0: channel = line.ChannelA; break;
                                case 1: channel = line.ChannelB; break;
                                case 2: channel = line.ChannelC; break;
                            }

                            if (!channel.IsEmpty())
                            {
                                if (!channelLookup.ContainsKey(channel.ToString()))
                                {
                                    channelLookup.Add(channel.ToString(), channelLookup.Count);

                                    channelStr.WriteByte((byte)channel.Note);
                                    channelStr.WriteByte((byte)channel.Sample);
                                    channelStr.WriteByte((byte)channel.Ornament);
                                    channelStr.WriteByte((byte)channel.Volume);
                                }
                            }
                        }

                    }
                }
                channelData = channelStr.ToArray();
            }
                

            int sizeofHeader = 12;
            int dataOffset = (int)_baseAddress + sizeofHeader + patternTable.Length * 2 + sampleTable.Length * 2 + ornamentTable.Length * 2;
            
            using (var dataStr = new MemoryStream())
            {
                // Play order

                playOrderPtr = (uint)(dataStr.Position + dataOffset);
                foreach (var po in _module.PlayOrder)
                {
                    dataStr.WriteByte((byte)po);
                }

                // Samples

                for (int i = 0; i < _module.Samples.Length; ++i)
                {
                    var sample = _module.Samples[i];
                    sampleTable[i] = (uint)(dataStr.Position + dataOffset);

                    dataStr.WriteByte((byte)sample.Lines.Count);
                    dataStr.WriteByte((byte)sample.LoopIndex);

                    foreach (var line in sample.Lines)
                    {
                        int b = (line.ToneEnabled ?     1 : 0) |
                                (line.NoiseEnabled ?    8 : 0) |
                                (line.EnvelopeEnabled ? 4 : 0) |
                                (line.ToneRelative ?    2 : 0) |
                                (line.NoiseRelative ?   16 : 0);

                        dataStr.WriteByte((byte)b);
                        Exporter.writeAddress16(dataStr, (uint)line.ToneValue);
                        dataStr.WriteByte((byte)line.NoiseValue);
                        dataStr.WriteByte((byte)line.Volume);
                    }
                }

                // Ornaments

                for (int i = 0; i < _module.Ornaments.Length; ++i)
                {
                    var ornament = _module.Ornaments[i];
                    ornamentTable[i] = (uint)(dataStr.Position + dataOffset);

                    dataStr.WriteByte((byte)ornament.Values.Count());
                    dataStr.WriteByte((byte)ornament.LoopIndex);
                    foreach (var line in ornament.Values)
                    {
                        dataStr.WriteByte((byte)line);
                    }
                }

                // Patterns

                for (int patternIdx = 0; patternIdx < _module.Patterns.Length; ++patternIdx)
                {
                    Pattern pattern = _module.Patterns[patternIdx];
                    patternTable[patternIdx] = (uint)(dataStr.Position + dataOffset);

                    dataStr.WriteByte((byte)pattern.Lines.Count());
                    foreach (var line in pattern.Lines)
                    {
                        for (int i = 0; i < 3; ++i)
                        {
                            Pattern.Line.Channel channel = null;
                            switch (i)
                            {
                                case 0:
                                    if (ChannelAEnabled)
                                    {
                                        channel = line.ChannelA;
                                    }
                                    break;
                                case 1:
                                    if (ChannelBEnabled)
                                    {
                                        channel = line.ChannelB;
                                    }
                                    break;
                                case 2:
                                    if (ChannelCEnabled)
                                    {
                                        channel = line.ChannelC;
                                    }
                                    break;
                            }

                            if (channel != null)
                            {
                                byte chByte = 0;
                                if (!channel.IsEmpty())
                                {
                                    chByte = (byte)(channelLookup[channel.ToString()] + 1);
                                }
                                dataStr.WriteByte(chByte);
                            }
                        }
                    }
                }

                // Channels

                channelsPtr = (uint)(dataStr.Position + dataOffset);
                dataStr.Write(channelData, 0, channelData.Length);

                using (var s = new MemoryStream())
                {
                    s.WriteByte((byte)_module.Speed);
                    
                    int moduleFlags = (_module.ChannelAEnabled ? 1 << 0 : 0) |
                                      (_module.ChannelBEnabled ? 1 << 1 : 0) |
                                      (_module.ChannelCEnabled ? 1 << 2 : 0);
                    s.WriteByte((byte)moduleFlags);

                    s.WriteByte((byte)_module.PlayOrder.Count);
                    s.WriteByte((byte)_module.PlayOrderLoop);

                    Exporter.writeAddress16(s, playOrderPtr);
                    
                    int ptr = (int)_baseAddress + sizeofHeader + patternTable.Length * 2;

                    Exporter.writeAddress16(s, (uint)ptr); // Samples ptr
                    ptr += sampleTable.Length * 2;

                    Exporter.writeAddress16(s, (uint)ptr); // Ornaments ptr
                    ptr += ornamentTable.Length * 2;

                    Exporter.writeAddress16(s, channelsPtr);

                    foreach (var addr in patternTable)
                    {
                        Exporter.writeAddress16(s, addr);
                    }

                    foreach (var addr in sampleTable)
                    {
                        Exporter.writeAddress16(s, addr);
                    }

                    foreach (var addr in ornamentTable)
                    {
                        Exporter.writeAddress16(s, addr);
                    }

                    dataStr.Seek(0, SeekOrigin.Begin);
                    dataStr.CopyTo(s);
                    moduleBytes = s.ToArray();
                }
            }

            return moduleBytes;
        }

        public static AudioModule Parse(string _audioString)
        {
            AudioModule module = new AudioModule();

            var samples = new Dictionary<int, Sample>();
            var ornaments = new Dictionary<int, Ornament>();
            var patterns = new Dictionary<int, Pattern>();

            using (var reader = new StringReader(_audioString))
            {
                String line;
                while (!String.IsNullOrWhiteSpace(line = reader.ReadLine()))
                {
                    if (line[0] != '[')
                    {
                        throw new FormatException("Invalid type token");
                    }

                    if (line[line.Length - 1] != ']')
                    {
                        throw new FormatException("Invalid type token");
                    }

                    line = line.Substring(1, line.Length - 2);
                    if (line == "Module")
                    {
                        module.ParseHeader(reader);
                    }
                    else if (line.StartsWith("Sample"))
                    {
                        int idx = int.Parse(line.Substring(6));
                        Sample sample = Sample.Parse(reader);
                        samples.Add(idx, sample);
                    }
                    else if (line.StartsWith("Ornament"))
                    {
                        int idx = int.Parse(line.Substring(8));
                        Ornament ornament = Ornament.Parse(reader);
                        ornaments.Add(idx, ornament);
                    }
                    else if (line.StartsWith("Pattern"))
                    {
                        int idx = int.Parse(line.Substring(7));
                        Pattern pattern = Pattern.Parse(reader);
                        patterns.Add(idx, pattern);
                    }
                    else
                    {
                        throw new FormatException("Invalid audio file.");
                    }
                }
            }

            // Remap patterns
            {
                var patternLookup = new Dictionary<int, int>();
                var modulePatterns = new List<Pattern>();
                for (int i = 0; i < module.PlayOrder.Count; ++i)
                {
                    int patternId = module.PlayOrder[i];
                    int remapId;
                    if (!patternLookup.TryGetValue(patternId, out remapId))
                    {
                        remapId = modulePatterns.Count;
                        patternLookup.Add(patternId, remapId);
                        modulePatterns.Add(patterns[patternId]);
                    }
                    module.PlayOrder[i] = remapId;
                }
                module.Patterns = modulePatterns.ToArray();
            }

            // Compress samples and ornaments + remap channels
            {
                var uniqueSamples = new List<Sample>();
                var sampleRemap = new Dictionary<int, int>();
                var uniqueOrnaments = new List<Ornament>();
                var ornamentRemap = new Dictionary<int, int>();

                foreach (var pattern in module.Patterns)
                {
                    foreach (var line in pattern.Lines)
                    {
                        for (int i = 0; i < 3; ++i)
                        {
                            Pattern.Line.Channel channel = line[i];

                            if (channel.Sample > 0)
                            {
                                int sampleIdx = 0;
                                if (!sampleRemap.TryGetValue(channel.Sample, out sampleIdx))
                                {
                                    sampleIdx = uniqueSamples.Count + 1;
                                    sampleRemap.Add(channel.Sample, sampleIdx);
                                    uniqueSamples.Add(samples[channel.Sample]);
                                }
                                channel.Sample = sampleIdx;
                            }

                            if (channel.Ornament > 0)
                            {
                                int ornamentIdx = 0;
                                if (!ornamentRemap.TryGetValue(channel.Ornament, out ornamentIdx))
                                {
                                    ornamentIdx = uniqueOrnaments.Count + 1;
                                    ornamentRemap.Add(channel.Ornament, ornamentIdx);
                                    uniqueOrnaments.Add(ornaments[channel.Ornament]);
                                }
                                channel.Ornament = ornamentIdx;
                            }
                        }
                    }
                }

                module.Samples = uniqueSamples.ToArray();
                module.Ornaments = uniqueOrnaments.ToArray();
            }
            
            return module;
        }

        public AudioModule()
        {
            PlayOrder = new List<int>();
        }

        private void ParseHeader(StringReader _reader)
        {
            String lineTxt;
            while (!String.IsNullOrWhiteSpace(lineTxt = _reader.ReadLine()))
            {
                string[] tokens = lineTxt.Split('=');
                if (tokens.Length == 2)
                {
                    string key = tokens[0];
                    string val = tokens[1];

                    if (key == "Title")
                    {
                        Title = val;
                    }
                    else if (key == "NoteTable")
                    {
                        NoteTable = int.Parse(val);
                    }
                    else if (key == "Speed")
                    {
                        Speed = int.Parse(val);
                    }
                    else if (key == "Channels")
                    {
                        ChannelAEnabled = val.Contains("A");
                        ChannelBEnabled = val.Contains("B");
                        ChannelCEnabled = val.Contains("C");
                    }
                    else if (key == "PlayOrder")
                    {
                        string[] orderTokens = val.Split(',');
                        for (int i = 0; i < orderTokens.Length; ++i)
                        {
                            string s = orderTokens[i];
                            if (s[0] == 'L')
                            {
                                PlayOrderLoop = i;
                                s = s.Substring(1);
                            }
                            PlayOrder.Add(int.Parse(s));
                        }
                    }
                }
            }
        }

        public class Sample
        {
            private List<Line> m_lines = new List<Line>();

            public List<Line> Lines { get => m_lines; }
            public int LoopIndex { get; private set; }

            public class Line
            {
                public bool ToneEnabled { get; private set; }
                public bool NoiseEnabled { get; private set; }
                public bool EnvelopeEnabled { get; private set; }
                public bool ToneRelative { get; private set; }
                public bool NoiseRelative { get; private set; }
                public int ToneValue { get; private set; }
                public int NoiseValue { get; private set; }
                public int Volume { get; private set; }
                public bool IsLoopStart { get; private set; }

                public void Parse(string _line)
                {
                    string[] tokens = _line.Split(' ');
                    if (tokens.Length != 4 && tokens.Length != 5) {
                        throw new FormatException("Incorrect number of tokens in sample line.");
                    }

                    ToneEnabled = tokens[0][0] == 'T';
                    NoiseEnabled = tokens[0][1] == 'N';
                    EnvelopeEnabled = tokens[0][2] == 'E';

                    ToneValue = int.Parse(tokens[1].Substring(1, 3), NumberStyles.HexNumber);
                    if (tokens[1][0] == '-')
                    {
                        ToneValue = -ToneValue;
                    }
                    ToneRelative = tokens[1][4] == '^';

                    NoiseValue = int.Parse(tokens[2].Substring(1, 2), NumberStyles.HexNumber);
                    if (tokens[2][0] == '-')
                    {
                        NoiseValue = -NoiseValue;
                    }
                    NoiseRelative = tokens[2][3] == '^';

                    Volume = int.Parse(tokens[3].Substring(0,1), NumberStyles.HexNumber);
                    char c = tokens[3][1];
                    if (c == '+')
                    {
                        Volume += 16;
                    }
                    else if (c == '-')
                    {
                        Volume += 32;
                    }

                    if (tokens.Length == 5)
                    {
                        IsLoopStart = tokens[4] == "L";
                    }
                }
            }

            public static Sample Parse(StringReader _reader)
            {
                Sample sample = new Sample();

                string lineTxt;
                int lineIdx = 0;
                while (!String.IsNullOrWhiteSpace(lineTxt = _reader.ReadLine()))
                {
                    Line line = new Line();
                    line.Parse(lineTxt);
                    sample.m_lines.Add(line);
                    if (line.IsLoopStart)
                    {
                        sample.LoopIndex = lineIdx;
                    }
                    ++lineIdx;
                }

                return sample;
            }
        }

        public class Ornament
        {
            private List<int> m_values = new List<int>();
            private int m_loopIndex;

            public IEnumerable<int> Values { get => m_values; }
            public int LoopIndex { get => m_loopIndex; }

            public bool IsEmpty()
            {
                return m_values.Count == 1 && m_values[0] == 0;
            }

            public static Ornament Parse(StringReader _reader)
            {
                Ornament ornament = new Ornament();

                string line;
                while (!String.IsNullOrWhiteSpace(line = _reader.ReadLine()))
                {
                    string[] tokens = line.Split(',');
                    for (int i = 0; i < tokens.Length; ++i)
                    {
                        string t = tokens[i];
                        if (t[0] == 'L')
                        {
                            ornament.m_loopIndex = i;
                            t = t.Substring(1);
                        }

                        ornament.m_values.Add(int.Parse(t));
                    }
                }

                return ornament;
            }
        }

        public class Pattern
        {
            public Pattern()
            {
            }

            public AudioModule Module { get; private set; }

            private List<Line> m_lines = new List<Line>();

            public static Pattern Parse(StringReader _reader)
            {
                Pattern pattern = new Pattern();

                string lineTxt;
                while (!String.IsNullOrWhiteSpace(lineTxt = _reader.ReadLine()))
                {
                    Line line = new Line();
                    line.Parse(lineTxt);
                    pattern.m_lines.Add(line);
                }

                return pattern;
            }

            public IEnumerable<Line> Lines { get => m_lines; }

            public class Line
            {
                public Channel ChannelA { get; private set; }
                public Channel ChannelB { get; private set; }
                public Channel ChannelC { get; private set; }

                public Channel this[int i]
                {
                    get
                    {
                        switch (i)
                        {
                            case 0:
                                return ChannelA;
                            case 1:
                                return ChannelB;
                            case 2:
                                return ChannelC;
                            default:
                                throw new Exception("Invalid index");
                        }
                    }
                }

                public Line()
                {
                    ChannelA = new Channel();
                    ChannelB = new Channel();
                    ChannelC = new Channel();
                }

                public void Parse(string _line)
                {
                    // ....|..|G-3 1.A. ....|--- .... ....|--- .... ....

                    string[] tokens = _line.Split('|');
                    ChannelA.Parse(tokens[2]);
                    ChannelB.Parse(tokens[3]);
                    ChannelC.Parse(tokens[4]);
                }

                public class Channel
                {
                    public int Note { get; set; }
                    public int Sample { get; set; }
                    public int Ornament { get; set; }
                    public int Volume { get; set; }
                    private string m_text;

                    public override string ToString()
                    {
                        return m_text;
                    }

                    public void Parse(string _data)
                    {
                        m_text = string.Copy(_data);

                        char c = _data[0];
                        if (c == 'R')
                        {
                            Note = 255;
                        }
                        else if (c != '-')
                        {
                            Note = noteToValue(_data[0]);
                            if (_data[1] == '#')
                            {
                                ++Note;
                            }
                            int octave = int.Parse(_data[2].ToString());
                            Note = -8 + octave * 12 + Note;
                        }

                        c = _data[4];
                        if (c != '.')
                        {
                            Sample = int.Parse(c.ToString(), NumberStyles.HexNumber);
                        }

                        c = _data[6];
                        if (c != '.')
                        {
                            Ornament = int.Parse(c.ToString(), NumberStyles.HexNumber);
                        }

                        c = _data[7];
                        if (c != '.')
                        {
                            Volume = int.Parse(c.ToString(), NumberStyles.HexNumber);
                        }
                    }

                    public bool IsEmpty()
                    {
                        return Note == 0 && Sample == 0 && Ornament == 0 && Volume == 0;
                    }

                    private int noteToValue(char c)
                    {
                        switch (c)
                        {
                            case 'C': return 0;
                            case 'D': return 2;
                            case 'E': return 4;
                            case 'F': return 5;
                            case 'G': return 7;
                            case 'A': return 9;
                            case 'B': return 11;
                        }

                        throw new FormatException("Invalid note.");
                    }
                }
            }
        }
        
        public static readonly int[] s_noteTable =
        {
            4030,3804,3591,3389,3199,3019,2850,2690,2539,2397,2262,2135,2015,
            1902,1795,1695,1599,1510,1425,1345,1270,1198,1131,1068,1008,951,
            898,847,800,755,712,673,635,599,566,534,504,476,449,424,400,377,
            356,336,317,300,283,267,252,238,224,212,200,189,178,168,159,150,
            141,133,126,119,112,106,100,94,89,79,75,71,67,63,59,56,53,50,47,45,42,
            40,37,35,33,31,30,28,26,25,24,22,21,20,19,18,17,16,15,14,13,12,12,11,11,10,9,9,8,8,7,7
        };
    }
}
