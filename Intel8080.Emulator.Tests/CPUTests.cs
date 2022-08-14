using Moq;
using Xunit;

namespace Intel8080.Emulator.Tests
{
    public class CPUTests
    {
        private readonly CPU _cpu;
        private readonly Mock<DefaultInstructionSet> _instructionSet;
        private readonly Mock<IMemory> _memory;

        public CPUTests()
        {
            _memory = new Mock<IMemory>();
            _instructionSet = new Mock<DefaultInstructionSet>();

            _cpu = new CPU(_memory.Object, _instructionSet.Object);
        }
    }
}