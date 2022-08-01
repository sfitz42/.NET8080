namespace Intel8080.Emulator
{
    public class Registers
    {
        public byte A { get; set; } = 0x00;

        // Flag register default value - Bit position 2 is always 1
        public byte F { get; set; } = 0x00;

        public ushort BC { get; set; } = 0x00;
        public byte B { get { return (byte)((BC & 0xFF00) >> 8); } set { BC &= 0x00FF; BC |= (ushort)(value << 8); } }
        public byte C { get { return (byte)(BC & 0x00FF); } set { BC &= 0xFF00; BC |= value; } }

        public ushort DE { get; set; } = 0x00;
        public byte D { get { return (byte)((DE & 0xFF00) >> 8); } set { DE &= 0x00FF; DE |= (ushort)(value << 8); } }
        public byte E { get { return (byte)(DE & 0x00FF); } set { DE &= 0xFF00; DE |= value; } }

        public ushort HL { get; set; } = 0x00;
        public byte H { get { return (byte)((HL & 0xFF00) >> 8); } set { HL &= 0x00FF; HL |= (ushort)(value << 8); } }
        public byte L { get { return (byte)(HL & 0x00FF); } set { HL &= 0xFF00; HL |= value; } }

        public ushort SP { get; set; } = 0x00;
        public ushort PC { get; set; } = 0x00;

        public readonly Flags Flags;

        public Registers()
        {
            Flags = new Flags(this);    
        }
    }
}