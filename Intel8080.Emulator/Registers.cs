using System.Runtime.InteropServices;

namespace Intel8080.Emulator
{
    [StructLayout(LayoutKind.Explicit)]
    public class Registers
    {
        [FieldOffset(0)]
        public byte A = 0x00;

        [FieldOffset(1)]
        public ushort BC = 0x0000;
        [FieldOffset(2)]
        public byte B;
        [FieldOffset(1)]
        public byte C;

        [FieldOffset(3)]
        public ushort DE = 0x0000;
        [FieldOffset(4)]
        public byte D;
        [FieldOffset(3)]
        public byte E;

        [FieldOffset(5)]
        public ushort HL = 0x0000;
        [FieldOffset(6)]
        public byte H;
        [FieldOffset(5)]
        public byte L;

        [FieldOffset(7)]
        public ushort SP = 0x0000;
        
        [FieldOffset(9)]
        public ushort PC = 0x0000;
    }
}