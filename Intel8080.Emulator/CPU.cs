using System.Linq;
using Intel8080.Emulator.Instructions;

namespace Intel8080.Emulator
{
    public class CPU
    {
        public IMemory Memory { get; }

        public Registers Registers { get; }

        public IInstructionSet InstructionSet { get; }

        public Port[] Ports { get; } = null!;

        public Flags Flags { get; }

        public int Cycles { get; set; } = 0;

        public bool Halted { get; set; }

        public bool InterruptEnabled { get; set; } = true;

        public CPU(IMemory memory, int availablePorts, IInstructionSet instructionSet)
        {
            Memory = memory;
            Ports = Enumerable.Range(0, availablePorts).Select(p => new Port()).ToArray();
            InstructionSet = instructionSet;
            Registers = new Registers();
            Flags = new Flags();
        }

        public CPU(IMemory memory, IInstructionSet instructionSet)
        {
            Memory = memory;
            InstructionSet = instructionSet;
            Registers = new Registers();
            Flags = new Flags();
        }

        public CPU(IMemory memory, int availablePorts)
        {
            Memory = memory;
            InstructionSet = new DefaultInstructionSet();
            Ports = Enumerable.Range(0, availablePorts).Select(p => new Port()).ToArray();
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
            var opcode = ReadNextByte();

            InstructionSet[opcode](this);

            Cycles += OpcodeTable.Opcodes[opcode].Cycles;
        }

        public void Reset()
        {
            Registers.BC = 0;
            Registers.DE = 0;
            Registers.HL = 0;
            Registers.PC = 0;
            Registers.SP = 0;

            Flags.Clear();
        }

        internal byte ReadByte(int address)
        {
            return Memory[address];
        }

        internal ushort ReadUshort(int address)
        {
            var a = ReadByte(address + 1);
            var b = ReadByte(address);

            return (ushort)((a << 8) | b);
        }

        internal byte ReadNextByte()
        {
            return ReadByte(Registers.PC++);
        }

        internal ushort ReadNextUshort()
        {
            var res = ReadUshort(Registers.PC);

            Registers.PC += 2;

            return res;
        }
    }
}