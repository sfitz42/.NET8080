namespace Intel8080.Emulator.Instructions
{
    public partial class DefaultInstructionSet : IInstructionSet
    {
        public virtual void JMP(CPU cpu)
        {
            var data = GetUshort(
                cpu.Memory[cpu.Registers.PC + 2],
                cpu.Memory[cpu.Registers.PC + 1]
            );

            cpu.Registers.PC = data;
        }

        public virtual void JZ(CPU cpu)
        {
            if (cpu.Flags.Zero)
                JMP(cpu);
        }

        public virtual void JNZ(CPU cpu)
        {
            if (!cpu.Flags.Zero)
                JMP(cpu);
        }
    }
}