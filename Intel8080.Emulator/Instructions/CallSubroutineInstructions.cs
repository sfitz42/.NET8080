namespace Intel8080.Emulator.Instructions
{
    public partial class DefaultInstructionSet : IInstructionSet
    {
        private void CALL(CPU cpu, ushort address)
        {
            PushStack(cpu, (ushort) (cpu.Registers.PC + 1));

            cpu.Registers.PC = address;
        }

        public virtual void CALL(CPU cpu)
        {
            var data = GetUshort(
                cpu.Memory[cpu.Registers.PC + 2],
                cpu.Memory[cpu.Registers.PC + 1]
            );

            CALL(cpu, data);
        }

        public virtual void CZ(CPU cpu)
        {
            if (cpu.Flags.Zero)
            {
                CALL(cpu);

                cpu.Cycles += 6;
            }
        }

        public virtual void CNZ(CPU cpu)
        {
            if (!cpu.Flags.Zero)
            {
                CALL(cpu);

                cpu.Cycles += 6;
            }
        }

        public virtual void RST_0(CPU cpu)
        {
            CALL(cpu, 0x00);
        }

        public virtual void RST_1(CPU cpu)
        {
            CALL(cpu, 0x08);
        }
    }
}