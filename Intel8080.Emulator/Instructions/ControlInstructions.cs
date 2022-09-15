namespace Intel8080.Emulator.Instructions
{
    public partial class DefaultInstructionSet : IInstructionSet
    {
        // 0x00   - NOP
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None
        public virtual void NOP(CPU cpu)
        {
            return;
        }

        // 0x76   - HLT
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public virtual void HLT(CPU cpu)
        {
            cpu.Halted = true;
        }
    }
}