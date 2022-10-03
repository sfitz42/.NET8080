using Intel8080.Emulator.Instructions;
using Moq;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class JumpInstructionTests
    {
        private readonly CPU _cpu;
        private readonly Mock<IMemory> _memory;

        public JumpInstructionTests()
        {
            _memory = new Mock<IMemory>();

            _cpu = new CPU(_memory.Object);

            _cpu.Registers.PC = 1;
        }

        [Fact]
        public void JMP_ShouldSetPCToJumpAddr()
        {
            // Arrange
            _memory.Setup(x => x[0x0001]).Returns(0x50);
            _memory.Setup(x => x[0x0002]).Returns(0x00);

            // Act
            DefaultInstructionSet.JMP(_cpu);

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
            DefaultInstructionSet.JNZ(_cpu);

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
            DefaultInstructionSet.JNZ(_cpu);

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
            DefaultInstructionSet.JZ(_cpu);

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
            DefaultInstructionSet.JZ(_cpu);

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
            DefaultInstructionSet.JNC(_cpu);

            // Assert
            Assert.Equal(0x0003, _cpu.Registers.PC);
        }

        [Fact]
        public void JNC_ShouldJumpIfCarryFlagIsFalse()
        {
            // Arrange
            _memory.Setup(x => x[0x0001]).Returns(0x50);
            _memory.Setup(x => x[0x0002]).Returns(0x00);

            _cpu.Flags.Carry = false;

            // Act
            DefaultInstructionSet.JNC(_cpu);

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
            DefaultInstructionSet.JC(_cpu);

            // Assert
            Assert.Equal(0x0003, _cpu.Registers.PC);
        }

        [Fact]
        public void JC_ShouldJumpIfCarryFlagSet()
        {
            // Arrange
            _memory.Setup(x => x[0x0001]).Returns(0x50);
            _memory.Setup(x => x[0x0002]).Returns(0x00);

            _cpu.Flags.Carry = true;

            // Act
            DefaultInstructionSet.JC(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
        }

        [Fact]
        public void JPO_ShouldNotJumpIfParityEven()
        {
            // Arrange
            _memory.Setup(x => x[0x0001]).Returns(0x50);
            _memory.Setup(x => x[0x0002]).Returns(0x00);

            _cpu.Flags.Parity = true;

            // Act
            DefaultInstructionSet.JPO(_cpu);

            // Assert
            Assert.Equal(0x0003, _cpu.Registers.PC);
        }

        [Fact]
        public void JPO_ShouldJumpIfParityOdd()
        {
            // Arrange
            _memory.Setup(x => x[0x0001]).Returns(0x50);
            _memory.Setup(x => x[0x0002]).Returns(0x00);

            _cpu.Flags.Parity = false;

            // Act
            DefaultInstructionSet.JPO(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
        }

        [Fact]
        public void JPE_ShouldNotJumpIfParityOdd()
        {
            // Arrange
            _memory.Setup(x => x[0x0001]).Returns(0x50);
            _memory.Setup(x => x[0x0002]).Returns(0x00);

            _cpu.Flags.Parity = false;

            // Act
            DefaultInstructionSet.JPE(_cpu);

            // Assert
            Assert.Equal(0x0003, _cpu.Registers.PC);
        }

        [Fact]
        public void JPE_ShouldJumpIfParityEven()
        {
            // Arrange
            _memory.Setup(x => x[0x0001]).Returns(0x50);
            _memory.Setup(x => x[0x0002]).Returns(0x00);

            _cpu.Flags.Parity = true;

            // Act
            DefaultInstructionSet.JPE(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
        }

        [Fact]
        public void JP_ShouldNotJumpIfSignFlagSet()
        {
            // Arrange
            _memory.Setup(x => x[0x0001]).Returns(0x50);
            _memory.Setup(x => x[0x0002]).Returns(0x00);

            _cpu.Flags.Sign = true;

            // Act
            DefaultInstructionSet.JP(_cpu);

            // Assert
            Assert.Equal(0x0003, _cpu.Registers.PC);
        }

        [Fact]
        public void JP_ShouldJumpIfSignFlagReset()
        {
            // Arrange
            _memory.Setup(x => x[0x0001]).Returns(0x50);
            _memory.Setup(x => x[0x0002]).Returns(0x00);

            _cpu.Flags.Sign = false;

            // Act
            DefaultInstructionSet.JP(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
        }

        [Fact]
        public void JM_ShouldNotJumpIfSignFlagReset()
        {
            // Arrange
            _memory.Setup(x => x[0x0001]).Returns(0x50);
            _memory.Setup(x => x[0x0002]).Returns(0x00);

            _cpu.Flags.Sign = false;

            // Act
            DefaultInstructionSet.JM(_cpu);

            // Assert
            Assert.Equal(0x0003, _cpu.Registers.PC);
        }

        [Fact]
        public void JM_ShouldJumpIfSignFlagSet()
        {
            // Arrange
            _memory.Setup(x => x[0x0001]).Returns(0x50);
            _memory.Setup(x => x[0x0002]).Returns(0x00);

            _cpu.Flags.Sign = true;

            // Act
            DefaultInstructionSet.JM(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
        }

        [Fact]
        public void PCHL_ShouldChangePCToHL()
        {
            // Arrange
            _cpu.Registers.HL = 0x413E;

            // Act
            DefaultInstructionSet.PCHL(_cpu);

            // Assert
            Assert.Equal(0x413E, _cpu.Registers.PC);
        }
    }
}