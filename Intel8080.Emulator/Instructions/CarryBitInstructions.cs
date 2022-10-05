namespace Intel8080.Emulator.Instructions
{
    public static partial class DefaultInstructionSet
    {
        // 0x37   - STC
        // Bytes  - 1
        // Cycles - 4
        // Flags  - C
        public static void STC(CPU cpu)
        {
            cpu.Flags.Carry = true;
        }

        // 0x3F   - CMC
        // Bytes  - 1
        // Cycles - 4
        // Flags  - C
        public static void CMC(CPU cpu)
        {
            cpu.Flags.Carry = !cpu.Flags.Carry;
        }
    }
}