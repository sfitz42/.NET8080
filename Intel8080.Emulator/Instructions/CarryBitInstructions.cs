namespace Intel8080.Emulator.Instructions
{
    public partial class DefaultInstructionSet : IInstructionSet
    {
        // 0x37   - STC
        // Bytes  - 1
        // Cycles - 4
        // Flags  - C
        public virtual void STC(CPU cpu)
        {
            cpu.Flags.Carry = true;
        }

        // 0x3F   - CMC
        // Bytes  - 1
        // Cycles - 4
        // Flags  - C
        public virtual void CMC(CPU cpu)
        {
            cpu.Flags.Carry = !cpu.Flags.Carry;
        }
    }
}