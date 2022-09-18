namespace Intel8080.Emulator.Instructions
{
    public partial class DefaultInstructionSet : IInstructionSet
    {
        private void JMP(CPU cpu, ushort address)
        {
            cpu.Registers.PC = address;
        }

        public virtual void JMP(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            JMP(cpu, location);
        }

        public virtual void JNZ(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (!cpu.Flags.Zero)
                JMP(cpu, location);
        }

        public virtual void JZ(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (cpu.Flags.Zero)
                JMP(cpu, location);
        }

        public virtual void JNC(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (!cpu.Flags.Carry)
                JMP(cpu, location);
        }

        public virtual void JC(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (cpu.Flags.Carry)
                JMP(cpu, location);
        }

        public virtual void JPO(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (!cpu.Flags.Parity)
                JMP(cpu, location);
        }

        public virtual void JPE(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (cpu.Flags.Parity)
                JMP(cpu, location);
        }

        public virtual void PCHL(CPU cpu)
        {
            cpu.Registers.PC = cpu.Registers.HL;
        }
    }
}