using Intel8080.Emulator.Instructions;

namespace Intel8080.Emulator
{
    public class CPU
    {
        public IMemory Memory { get; }

        public Registers Registers { get; }

        public IInstructionSet InstructionSet { get; }

        public Flags Flags { get; }

        public int Cycles { get; set; } = 0;

        public bool Halted { get; set; }

        public CPU(IMemory memory, IInstructionSet instructionSet)
        {
            Memory = memory;
            InstructionSet = instructionSet;
            Registers = new Registers();
            Flags = new Flags();
        }

        public CPU(IMemory memory)
        {
            Memory = memory;
            InstructionSet = new DefaultInstructionSet();
            Registers = new Registers();
            Flags = new Flags();
        }

        public void Run()
        {
            while (!Halted)
            {
                Step();
            }
        }
        
        public void Step()
        {
            var opcode = Memory[Registers.PC];

            InstructionSet[Memory[Registers.PC]](this);

            Registers.PC += OpcodeTable.Opcodes[opcode].Length;
            Cycles += OpcodeTable.Opcodes[opcode].Cycles;
        }
    }
}