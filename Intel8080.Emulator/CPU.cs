namespace Intel8080.Emulator
{
    public class CPU
    {
        public IMemory Memory { get; }

        public Registers Registers { get; }

        public Flags Flags { get; }

        public int Cycles { get; set; } = 0;

        public CPU(IMemory memory)
        {
            Memory = memory;
            Registers = new Registers();
            Flags = new Flags();
        }

        public void Run()
        {
            InstructionSet.OpcodeActions[Memory[Registers.PC]](this);
        }
    }
}