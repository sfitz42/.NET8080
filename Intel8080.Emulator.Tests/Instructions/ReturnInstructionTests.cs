using Moq;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class ReturnInstructionTests
    {
        private readonly CPU _cpu;
        private readonly IInstructionSet _instructionSet;
        private readonly Mock<IMemory> _memory;

        public ReturnInstructionTests()
        {
            _memory = new Mock<IMemory>();
            _instructionSet = new DefaultInstructionSet();

            _cpu = new CPU(_memory.Object, _instructionSet);
        }

        [Fact]
        public void RNZ_ShouldNotReturnIfZeroFlagSet()
        {
            // Arrange
            _memory.Setup(x => x[0x0010]).Returns(0x50);
            _memory.Setup(x => x[0x0011]).Returns(0x00);

            _cpu.Registers.SP = 0x0010;

            _cpu.Flags.Zero = true;

            // Act
            _instructionSet.RNZ(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.PC);
        }

        [Fact]
        public void RNZ_ShouldReturnIfZeroFlagFalse()
        {
            // Arrange
            _memory.Setup(x => x[0x0010]).Returns(0x50);
            _memory.Setup(x => x[0x0011]).Returns(0x00);

            _cpu.Registers.SP = 0x0010;

            _cpu.Flags.Zero = false;

            // Act
            _instructionSet.RNZ(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
        }

        [Fact]
        public void RZ_ShouldNotReturnIfZeroFlagFalse()
        {
            // Arrange
            _memory.Setup(x => x[0x0010]).Returns(0x50);
            _memory.Setup(x => x[0x0011]).Returns(0x00);

            _cpu.Registers.SP = 0x0010;

            _cpu.Flags.Zero = false;

            // Act
            _instructionSet.RZ(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.PC);
        }

        [Fact]
        public void RZ_ShouldReturnIfZeroFlagSet()
        {
            // Arrange
            _memory.Setup(x => x[0x0010]).Returns(0x50);
            _memory.Setup(x => x[0x0011]).Returns(0x00);

            _cpu.Registers.SP = 0x0010;

            _cpu.Flags.Zero = true;

            // Act
            _instructionSet.RZ(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
        }

        [Fact]
        public void RET_ShouldReturnFromSubroutine()
        {
            // Arrange
            _memory.Setup(x => x[0x0010]).Returns(0x50);
            _memory.Setup(x => x[0x0011]).Returns(0x00);

            _cpu.Registers.SP = 0x0010;

            // Act
            _instructionSet.RET(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
        }
    }
}