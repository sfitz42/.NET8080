namespace Intel8080.Emulator
{
    public static class InstructionSet
    {
        public static Instruction[] InstructionTable;

        static InstructionSet()
        {
            InstructionTable = new Instruction[0xFF];

            // 0x0X
            InstructionTable[0x00] = new Instruction("NOP", 1, 4, null, NOP);
        }

        // 0x00   - NOP
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None
        public static void NOP(CPU cpu, Instruction instruction)
        {
            cpu.Registers.PC += instruction.Length;
            cpu.Cycles += instruction.Cycles;
        }
    }
}