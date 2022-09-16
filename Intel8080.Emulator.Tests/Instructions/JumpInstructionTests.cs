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

            _cpu.Registers.PC = 1;
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
        public void JNZ_ShouldNotJumpIfZeroFlagIsSet()
        {
            // Arrange
            _memory.Setup(x => x[0x0001]).Returns(0x50);
            _memory.Setup(x => x[0x0002]).Returns(0x00);

            _cpu.Flags.Zero = true;

            // Act
            _instructionSet.JNZ(_cpu);

            // Assert
            Assert.Equal(0x0003, _cpu.Registers.PC);
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
        public void JZ_ShouldNotJumpIfZeroFlagFalse()
        {
            // Arrange
            _memory.Setup(x => x[0x0001]).Returns(0x50);
            _memory.Setup(x => x[0x0002]).Returns(0x00);

            _cpu.Flags.Zero = false;

            // Act
            _instructionSet.JZ(_cpu);

            // Assert
            Assert.Equal(0x0003, _cpu.Registers.PC);
        }

        [Fact]
        public void JZ_ShouldJumpIfZeroFlagSet()
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

        [Fact]
        public void JNC_ShouldNotJumpIfCarryFlagIsSet()
        {
            // Arrange
            _memory.Setup(x => x[0x0001]).Returns(0x50);
            _memory.Setup(x => x[0x0002]).Returns(0x00);

            _cpu.Flags.Carry = true;

            // Act
            _instructionSet.JNC(_cpu);

            // Assert
            Assert.Equal(0x0003, _cpu.Registers.PC);
        }

        [Fact]
        public void JNC_ShouldJumpIfCarryFlagIsFalse()
        {
            // Arrange
            _memory.Setup(x => x[0x0001]).Returns(0x50);
            _memory.Setup(x => x[0x0002]).Returns(0x00);

            _cpu.Flags.Zero = false;

            // Act
            _instructionSet.JNC(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
        }

        [Fact]
        public void JC_ShouldNotJumpIfCarryFlagFalse()
        {
            // Arrange
            _memory.Setup(x => x[0x0001]).Returns(0x50);
            _memory.Setup(x => x[0x0002]).Returns(0x00);

            _cpu.Flags.Carry = false;

            // Act
            _instructionSet.JC(_cpu);

            // Assert
            Assert.Equal(0x0003, _cpu.Registers.PC);
        }

        [Fact]
        public void JZ_ShouldJumpIfCarryFlagSet()
        {
            // Arrange
            _memory.Setup(x => x[0x0001]).Returns(0x50);
            _memory.Setup(x => x[0x0002]).Returns(0x00);

            _cpu.Flags.Carry = true;

            // Act
            _instructionSet.JC(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
        }
    }
}