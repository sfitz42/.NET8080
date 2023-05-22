using Intel8080.Emulator;
using System.IO;

namespace Intel8080.TestRoms
{
    internal class MainMemory : IMemory
    {
        private readonly byte[] _memory;

        public byte this[int index] { get => _memory[index]; set => _memory[index] = value; }

        public MainMemory(int size)
        {
            _memory = new byte[size];
        }

        public void LoadRom(string path, int offset)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                fs.Read(_memory, offset, (int) fs.Length);
            }
        }

        public byte[] Copy()
        {
            throw new System.NotImplementedException();
        }
    }
}
