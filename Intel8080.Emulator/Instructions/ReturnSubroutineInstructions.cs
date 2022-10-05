namespace Intel8080.Emulator.Instructions
{
    public static partial class DefaultInstructionSet
    {
        public static void RET(CPU cpu)
        {
            cpu.Registers.PC = PopStack(cpu);
        }

        public static void RZ(CPU cpu)
        {
            if (cpu.Flags.Zero)
            {
                RET(cpu);

                cpu.Cycles += 6;
            }
        }

        public static void RNZ(CPU cpu)
        {
            if (!cpu.Flags.Zero)
            {
                RET(cpu);

                cpu.Cycles += 6;
            }
        }

        public static void RNC(CPU cpu)
        {
            if (!cpu.Flags.Carry)
            {
                RET(cpu);

                cpu.Cycles += 6;
            }
        }

        public static void RC(CPU cpu)
        {
            if (cpu.Flags.Carry)
            {
                RET(cpu);

                cpu.Cycles += 6;
            }
        }

        public static void RPO(CPU cpu)
        {
            if (!cpu.Flags.Parity)
            {
                RET(cpu);

                cpu.Cycles += 6;
            }
        }

        public static void RPE(CPU cpu)
        {
            if (cpu.Flags.Parity)
            {
                RET(cpu);

                cpu.Cycles += 6;
            }
        }

        public static void RP(CPU cpu)
        {
            if (!cpu.Flags.Sign)
            {
                RET(cpu);

                cpu.Cycles += 6;
            }
        }

        public static void RM(CPU cpu)
        {
            if (cpu.Flags.Sign)
            {
                RET(cpu);

                cpu.Cycles += 6;
            }
        }
    }
}