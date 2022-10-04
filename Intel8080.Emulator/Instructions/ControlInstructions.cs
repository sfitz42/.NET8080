namespace Intel8080.Emulator.Instructions
{
    public static partial class DefaultInstructionSet
    {
        // 0x00   - NOP
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None
        public static void NOP(CPU cpu)
        {
            return;
        }

        // 0x76   - HLT
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public static void HLT(CPU cpu)
        {
            cpu.Halted = true;
        }

        public static void OUT(CPU cpu)
        {
            var device = cpu.IOController.GetOutputDevice(cpu.ReadNextByte());

            device.Write(cpu.Registers.A);
        }

        public static void IN(CPU cpu)
        {
            var device = cpu.IOController.GetInputDevice(cpu.ReadNextByte());

            cpu.Registers.A = device.Read();
        }

        public static void DI(CPU cpu)
        {
            cpu.InterruptEnabled = false;
        }

        public static void EI(CPU cpu)
        {
            cpu.InterruptEnabled = true;
        }
    }
}