using System;

namespace Intel8080.Emulator
{
    public class Instruction
    {
        public string Mnenomic { get; set; } = null!;

        public ushort Length { get; set; }

        public int Cycles { get; set; }

        public int? CyclesBranch { get; set; }

        public Action<CPU, Instruction> Execute;

        public Instruction(string mnenomic, ushort length, int cycles, int? cyclesBranch, Action<CPU, Instruction> execute)
        {
            Mnenomic = mnenomic;
            Length = length;
            Cycles = cycles;
            CyclesBranch = cyclesBranch;
            Execute = execute;
        }
    }
}