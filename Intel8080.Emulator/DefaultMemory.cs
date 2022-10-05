namespace Intel8080.Emulator
{
    public class DefaultMemory : IMemory
    {
        private readonly byte[] _memory;

        public byte this[int index] { get => _memory[index]; set => _memory[index] = value; }

        public DefaultMemory(int size)
        {
            _memory = new byte[size];
        }
    }
}