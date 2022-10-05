namespace Intel8080.Emulator.Instructions
{
    public static partial class DefaultInstructionSet
    {
        private static void JMP(CPU cpu, ushort address)
        {
            cpu.Registers.PC = address;
        }

        public static void JMP(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            JMP(cpu, location);
        }

        public static void JNZ(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (!cpu.Flags.Zero)
                JMP(cpu, location);
        }

        public static void JZ(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (cpu.Flags.Zero)
                JMP(cpu, location);
        }

        public static void JNC(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (!cpu.Flags.Carry)
                JMP(cpu, location);
        }

        public static void JC(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (cpu.Flags.Carry)
                JMP(cpu, location);
        }

        public static void JPO(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (!cpu.Flags.Parity)
                JMP(cpu, location);
        }

        public static void JPE(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (cpu.Flags.Parity)
                JMP(cpu, location);
        }

        public static void JP(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (!cpu.Flags.Sign)
                JMP(cpu, location);
        }

        public static void JM(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (cpu.Flags.Sign)
                JMP(cpu, location);
        }

        public static void PCHL(CPU cpu)
        {
            cpu.Registers.PC = cpu.Registers.HL;
        }
    }
}