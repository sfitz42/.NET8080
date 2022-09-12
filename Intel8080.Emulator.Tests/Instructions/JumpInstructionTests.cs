using Intel8080.Emulator.Instructions;
using Moq;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class JumpInstructionTests
    {
        private readonly CPU _cpu;
        private readonly IInstructionSet _instructionSet;
        private readonly Mock<IMemory> _memory;

        public JumpInstructionTests()
        {
            _memory = new Mock<IMemory>();
            _instructionSet = new DefaultInstructionSet();

            _cpu = new CPU(_memory.Object, _instructionSet);
        }

        [Fact]
        public void JNZ_ShouldNotJumpIfZeroFlagIsSet()
        {
            // Arrange
            _memory.Setup(x => x[0x0001]).Returns(0x50);
            _memory.Setup(x => x[0x0002]).Returns(0x00);

            _cpu.Flags.Zero = true;

            // Act
            _instructionSet.JNZ(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.PC);
        }

        [Fact]
        public void JNZ_ShouldJumpIfZeroFlagIsFalse()
        {
            // Arrange
            _memory.Setup(x => x[0x0001]).Returns(0x50);
            _memory.Setup(x => x[0x0002]).Returns(0x00);

            _cpu.Flags.Zero = false;

            // Act
            _instructionSet.JNZ(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
        }

        [Fact]
        public void JMP_ShouldSetPCToJumpAddr()
        {
            // Arrange
            _memory.Setup(x => x[0x0001]).Returns(0x50);
            _memory.Setup(x => x[0x0002]).Returns(0x00);

            // Act
            _instructionSet.JMP(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
        }

        [Fact]
        public void JZ_ShouldNotJumpIfZeroFlagFalse()
        {
            // Arrange
            _memory.Setup(x => x[0x0001]).Returns(0x50);
            _memory.Setup(x => x[0x0002]).Returns(0x00);

            _cpu.Flags.Zero = false;

            // Act
            _instructionSet.JZ(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.PC);
        }

        [Fact]
        public void JNZ_ShouldJumpIfZeroFlagSet()
        {
            // Arrange
            _memory.Setup(x => x[0x0001]).Returns(0x50);
            _memory.Setup(x => x[0x0002]).Returns(0x00);

            _cpu.Flags.Zero = true;

            // Act
            _instructionSet.JZ(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
        }
    }
}