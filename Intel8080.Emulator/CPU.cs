using System;
using Intel8080.Emulator.Instructions;
using Intel8080.Emulator.IO;

namespace Intel8080.Emulator
{
    public class CPU
    {
        public IMemory Memory { get; }

        public Registers Registers { get; }

        public Flags Flags { get; }

        public IIOController IOController { get; }

        public long Cycles { get; set; } = 0;

        public bool Halted { get; set; }

        public bool Paused { get; set; }

        public bool InterruptEnabled { get; set; } = false;

        private readonly Action<CPU>[] _instructionSet = DefaultInstructionSet.Actions;

        private byte? _interrupt = null;

        public CPU(IMemory memory)
        {
            Memory = memory;
            Registers = new Registers();
            Flags = new Flags();
            IOController = new DefaultIOController();
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
            byte opcode;

            if (InterruptEnabled && _interrupt != null)
            {
                opcode = _interrupt.Value;

                InterruptEnabled = false;
                _interrupt = null;
            }
            else
            {
                opcode = ReadNextByte();
            }

            _instructionSet[opcode](this);

            Cycles += OpcodeTable.Opcodes[opcode].Cycles;
        }

        public void Reset()
        {
            Registers.Clear();
            Flags.Clear();
        }

        public void RaiseInterrupt(byte opcode)
        {
            _interrupt = opcode;
        }

        public State GetState() => new State(this);

        public void SetState(State state)
        {
            Registers.SetValues(state.Registers);

            Flags.F = state.Flags;

            Cycles = state.Cycles;
            Halted = state.Halted;
            InterruptEnabled = state.InterruptEnabled;
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