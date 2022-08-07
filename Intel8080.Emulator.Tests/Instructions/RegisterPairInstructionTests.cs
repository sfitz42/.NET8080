using Moq;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class RegisterPairInstructionTests
    {
        private readonly CPU _cpu;
        private readonly Mock<IMemory> _memory;

        public RegisterPairInstructionTests()
        {
            _memory = new Mock<IMemory>();

            _cpu = new CPU(_memory.Object);
        }

        [Fact]
        public void INX_B_ShouldIncrementByOne()
        {
            // Arrange
            _cpu.Registers.BC = 0x1234;

            // Act
            InstructionSet.INX_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x1235, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void INX_B_ShouldBeSetToZeroIfOverflow()
        {
            // Arrange
            _cpu.Registers.BC = 0xFFFF;

            // Act
            InstructionSet.INX_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void INX_D_ShouldIncrementByOne()
        {
            // Arrange
            _cpu.Registers.DE = 0x1234;

            // Act
            InstructionSet.INX_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x1235, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void INX_D_ShouldBeSetToZeroIfOverflow()
        {
            // Arrange
            _cpu.Registers.DE = 0xFFFF;

            // Act
            InstructionSet.INX_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void INX_H_ShouldIncrementByOne()
        {
            // Arrange
            _cpu.Registers.HL = 0x1234;

            // Act
            InstructionSet.INX_H(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x1235, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void INX_H_ShouldBeSetToZeroIfOverflow()
        {
            // Arrange
            _cpu.Registers.HL = 0xFFFF;

            // Act
            InstructionSet.INX_H(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void DCX_B_ShouldIncrementByOne()
        {
            // Arrange
            _cpu.Registers.BC = 0x1234;

            // Act
            InstructionSet.DCX_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x1233, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void DCX_B_ShouldBeSetToMaxIfUnderflow()
        {
            // Arrange
            _cpu.Registers.BC = 0x0000;

            // Act
            InstructionSet.DCX_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0xFFFF, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void DCX_D_ShouldIncrementByOne()
        {
            // Arrange
            _cpu.Registers.DE = 0x1234;

            // Act
            InstructionSet.DCX_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x1233, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void DCX_D_ShouldBeSetToMaxIfUnderflow()
        {
            // Arrange
            _cpu.Registers.DE = 0x0000;

            // Act
            InstructionSet.DCX_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0xFFFF, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void DCX_H_ShouldIncrementByOne()
        {
            // Arrange
            _cpu.Registers.HL = 0x1234;

            // Act
            InstructionSet.DCX_H(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x1233, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void DCX_H_ShouldBeSetToMaxIfUnderflow()
        {
            // Arrange
            _cpu.Registers.HL = 0x0000;

            // Act
            InstructionSet.DCX_H(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0xFFFF, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void DAD_B_ShouldAddBCToHL()
        {
            // Arrange
            _cpu.Registers.BC = 0x339F;
            _cpu.Registers.HL = 0xA17B;

            // Act
            InstructionSet.DAD_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x339F, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0xD51A, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Carry);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void DAD_B_ShouldSetCarryFlag()
        {
            // Arrange
            _cpu.Registers.BC = 0x0001;
            _cpu.Registers.HL = 0xFFFF;

            // Act
            InstructionSet.DAD_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0001, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Carry);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void DAD_D_ShouldAddBCToHL()
        {
            // Arrange
            _cpu.Registers.DE = 0x339F;
            _cpu.Registers.HL = 0xA17B;

            // Act
            InstructionSet.DAD_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x339F, _cpu.Registers.DE);
            Assert.Equal(0xD51A, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Carry);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void DAD_D_ShouldSetCarryFlag()
        {
            // Arrange
            _cpu.Registers.DE = 0x0001;
            _cpu.Registers.HL = 0xFFFF;

            // Act
            InstructionSet.DAD_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0001, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Carry);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void DAD_H_ShouldAddBCToHL()
        {
            // Arrange
            _cpu.Registers.HL = 0x339F;

            // Act
            InstructionSet.DAD_H(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x673E, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Carry);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void DAD_H_ShouldSetCarryFlag()
        {
            // Arrange
            _cpu.Registers.HL = 0xFFFF;

            // Act
            InstructionSet.DAD_H(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0xFFFE, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Carry);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }
    }
}