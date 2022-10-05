namespace Intel8080.Emulator.Instructions
{
    public static partial class DefaultInstructionSet
    {
        // 0x32   - STA a16
        // Bytes  - 3
        // Cycles - 13
        // Flags  - None
        public static void STA(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            cpu.Memory[location] = cpu.Registers.A;
        }

        // 0x3A   - LDA a16
        // Bytes  - 3
        // Cycles - 13
        // Flags  - C
        public static void LDA(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            cpu.Registers.A = cpu.Memory[location];
        }

        // 0x22   - SHLD a16
        // Bytes  - 3
        // Cycles - 16
        // Flags  - None
        public static void SHLD(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            cpu.Memory[location] = cpu.Registers.L;
            cpu.Memory[location + 1] = cpu.Registers.H;
        }

        // 0x2A   - LHLD a16
        // Bytes  - 3
        // Cycles - 16
        // Flags  - None
        public static void LHLD(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            cpu.Registers.L = cpu.Memory[location];
            cpu.Registers.H = cpu.Memory[location + 1];
        }
    }
}