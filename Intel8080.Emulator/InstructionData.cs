using System;

namespace Intel8080.Emulator
{
    public class Opcode
    {
        public string Mnenomic { get; set; } = null!;

        public ushort Length { get; set; }

        public int Cycles { get; set; }

        public int? CyclesBranch { get; set; }

        public Opcode(string mnenomic, ushort length, int cycles, int? cyclesBranch)
        {
            Mnenomic = mnenomic;
            Length = length;
            Cycles = cycles;
            CyclesBranch = cyclesBranch;
        }
    }
}