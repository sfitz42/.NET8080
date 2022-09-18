namespace Intel8080.Emulator.Instructions
{
    public partial class DefaultInstructionSet : IInstructionSet
    {
        public virtual void RET(CPU cpu)
        {
            cpu.Registers.PC = PopStack(cpu);
        }

        public virtual void RZ(CPU cpu)
        {
            if (cpu.Flags.Zero)
            {
                RET(cpu);

                cpu.Cycles += 6;
            }
        }

        public virtual void RNZ(CPU cpu)
        {
            if (!cpu.Flags.Zero)
            {
                RET(cpu);

                cpu.Cycles += 6;
            }
        }

        public virtual void RNC(CPU cpu)
        {
            if (!cpu.Flags.Carry)
            {
                RET(cpu);

                cpu.Cycles += 6;
            }
        }

        public virtual void RC(CPU cpu)
        {
            if (cpu.Flags.Carry)
            {
                RET(cpu);

                cpu.Cycles += 6;
            }
        }

        public virtual void RPO(CPU cpu)
        {
            if (!cpu.Flags.Parity)
            {
                RET(cpu);

                cpu.Cycles += 6;
            }
        }

        public virtual void RPE(CPU cpu)
        {
            if (cpu.Flags.Parity)
            {
                RET(cpu);

                cpu.Cycles += 6;
            }
        }
    }
}