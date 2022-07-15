namespace Intel8080.Emulator
{
    public class CPU
    {
        public byte[] Memory { get; set; }

        public Registers Registers { get; set; }

        public int Cycles { get; set; } = 0;

        public CPU(int _memSize)
        {
            Memory = new byte[_memSize];
            Registers = new Registers();
        }

        public void Run()
        {
            var op = InstructionSet.InstructionTable[Memory[Registers.PC]];

            op.Execute(this, op);
        }
    }
}