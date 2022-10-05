using Intel8080.Emulator.Instructions;
using Moq;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class ReturnInstructionTests
    {
        private readonly CPU _cpu;
        private readonly Mock<IMemory> _memory;

        public ReturnInstructionTests()
        {
            _memory = new Mock<IMemory>();

            _cpu = new CPU(_memory.Object);
        }

        [Fact]
        public void RET_ShouldReturnFromSubroutine()
        {
            // Arrange
            _memory.Setup(x => x[0x0010]).Returns(0x50);
            _memory.Setup(x => x[0x0011]).Returns(0x00);

            _cpu.Registers.SP = 0x0010;

            // Act
            DefaultInstructionSet.RET(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
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
            DefaultInstructionSet.RNZ(_cpu);

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
            DefaultInstructionSet.RNZ(_cpu);

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
            DefaultInstructionSet.RZ(_cpu);

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
            DefaultInstructionSet.RZ(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
        }

        [Fact]
        public void RNC_ShouldNotReturnIfCarryFlagSet()
        {
            // Arrange
            _memory.Setup(x => x[0x0010]).Returns(0x50);
            _memory.Setup(x => x[0x0011]).Returns(0x00);

            _cpu.Registers.SP = 0x0010;

            _cpu.Flags.Carry = true;

            // Act
            DefaultInstructionSet.RNC(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.PC);
        }

        [Fact]
        public void RNC_ShouldReturnIfCarryFlagFalse()
        {
            // Arrange
            _memory.Setup(x => x[0x0010]).Returns(0x50);
            _memory.Setup(x => x[0x0011]).Returns(0x00);

            _cpu.Registers.SP = 0x0010;

            _cpu.Flags.Carry = false;

            // Act
            DefaultInstructionSet.RNC(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
        }

        [Fact]
        public void RC_ShouldNotReturnIfCarryFlagFalse()
        {
            // Arrange
            _memory.Setup(x => x[0x0010]).Returns(0x50);
            _memory.Setup(x => x[0x0011]).Returns(0x00);

            _cpu.Registers.SP = 0x0010;

            _cpu.Flags.Carry = false;

            // Act
            DefaultInstructionSet.RC(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.PC);
        }

        [Fact]
        public void RC_ShouldReturnIfCarryFlagSet()
        {
            // Arrange
            _memory.Setup(x => x[0x0010]).Returns(0x50);
            _memory.Setup(x => x[0x0011]).Returns(0x00);

            _cpu.Registers.SP = 0x0010;

            _cpu.Flags.Carry = true;

            // Act
            DefaultInstructionSet.RC(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
        }

        [Fact]
        public void RPO_ShouldNotReturnIfParityEven()
        {
            // Arrange
            _memory.Setup(x => x[0x0010]).Returns(0x50);
            _memory.Setup(x => x[0x0011]).Returns(0x00);

            _cpu.Registers.SP = 0x0010;

            _cpu.Flags.Parity = true;

            // Act
            DefaultInstructionSet.RPO(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.PC);
        }

        [Fact]
        public void RPO_ShouldReturnIfParityOdd()
        {
            // Arrange
            _memory.Setup(x => x[0x0010]).Returns(0x50);
            _memory.Setup(x => x[0x0011]).Returns(0x00);

            _cpu.Registers.SP = 0x0010;

            _cpu.Flags.Parity = false;

            // Act
            DefaultInstructionSet.RPO(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
        }

        [Fact]
        public void RPE_ShouldNotReturnIfParityOdd()
        {
            // Arrange
            _memory.Setup(x => x[0x0010]).Returns(0x50);
            _memory.Setup(x => x[0x0011]).Returns(0x00);

            _cpu.Registers.SP = 0x0010;

            _cpu.Flags.Parity = false;

            // Act
            DefaultInstructionSet.RPE(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.PC);
        }

        [Fact]
        public void RPE_ShouldReturnIfParityEven()
        {
            // Arrange
            _memory.Setup(x => x[0x0010]).Returns(0x50);
            _memory.Setup(x => x[0x0011]).Returns(0x00);

            _cpu.Registers.SP = 0x0010;

            _cpu.Flags.Parity = true;

            // Act
            DefaultInstructionSet.RPE(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
        }

        [Fact]
        public void RP_ShouldNotReturnIfSignFlagIsSet()
        {
            // Arrange
            _memory.Setup(x => x[0x0010]).Returns(0x50);
            _memory.Setup(x => x[0x0011]).Returns(0x00);

            _cpu.Registers.SP = 0x0010;

            _cpu.Flags.Sign = true;

            // Act
            DefaultInstructionSet.RP(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.PC);
        }

        [Fact]
        public void RP_ShouldReturnIfSignFlagReset()
        {
            // Arrange
            _memory.Setup(x => x[0x0010]).Returns(0x50);
            _memory.Setup(x => x[0x0011]).Returns(0x00);

            _cpu.Registers.SP = 0x0010;

            _cpu.Flags.Sign = false;

            // Act
            DefaultInstructionSet.RP(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
        }

        [Fact]
        public void RM_ShouldNotReturnIfSignFlagReset()
        {
            // Arrange
            _memory.Setup(x => x[0x0010]).Returns(0x50);
            _memory.Setup(x => x[0x0011]).Returns(0x00);

            _cpu.Registers.SP = 0x0010;

            _cpu.Flags.Sign = false;

            // Act
            DefaultInstructionSet.RM(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.PC);
        }

        [Fact]
        public void RM_ShouldReturnIfSignFlagSet()
        {
            // Arrange
            _memory.Setup(x => x[0x0010]).Returns(0x50);
            _memory.Setup(x => x[0x0011]).Returns(0x00);

            _cpu.Registers.SP = 0x0010;

            _cpu.Flags.Sign = true;

            // Act
            DefaultInstructionSet.RM(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
        }
    }
}