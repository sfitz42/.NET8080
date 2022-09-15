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

        public virtual void JZ(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (cpu.Flags.Zero)
                JMP(cpu, location);
        }

        public virtual void JNZ(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (!cpu.Flags.Zero)
                JMP(cpu, location);
        }
    }
}