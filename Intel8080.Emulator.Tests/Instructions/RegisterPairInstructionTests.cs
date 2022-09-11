using Moq;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class RegisterPairInstructionTests
    {
        private readonly CPU _cpu;
        private readonly IInstructionSet _instructionSet;
        private readonly Mock<IMemory> _memory;

        public RegisterPairInstructionTests()
        {
            _memory = new Mock<IMemory>();
            _instructionSet = new DefaultInstructionSet();
            _cpu = new CPU(_memory.Object, _instructionSet);
        }

        [Fact]
        public void INX_B_ShouldIncrementByOne()
        {
            // Arrange
            _cpu.Registers.BC = 0x1234;

            // Act
            _instructionSet.INX_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x1235, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void INX_B_ShouldBeSetToZeroIfOverflow()
        {
            // Arrange
            _cpu.Registers.BC = 0xFFFF;

            // Act
            _instructionSet.INX_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void INX_D_ShouldIncrementByOne()
        {
            // Arrange
            _cpu.Registers.DE = 0x1234;

            // Act
            _instructionSet.INX_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x1235, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void INX_D_ShouldBeSetToZeroIfOverflow()
        {
            // Arrange
            _cpu.Registers.DE = 0xFFFF;

            // Act
            _instructionSet.INX_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void INX_H_ShouldIncrementByOne()
        {
            // Arrange
            _cpu.Registers.HL = 0x1234;

            // Act
            _instructionSet.INX_H(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x1235, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void INX_H_ShouldBeSetToZeroIfOverflow()
        {
            // Arrange
            _cpu.Registers.HL = 0xFFFF;

            // Act
            _instructionSet.INX_H(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void INX_SP_ShouldIncrementByOne()
        {
            // Arrange
            _cpu.Registers.SP = 0x1234;

            // Act
            _instructionSet.INX_SP(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x1235, _cpu.Registers.SP);
        }

        [Fact]
        public void INX_SP_ShouldBeSetToZeroIfOverflow()
        {
            // Arrange
            _cpu.Registers.SP = 0xFFFF;

            // Act
            _instructionSet.INX_SP(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void DCX_B_ShouldIncrementByOne()
        {
            // Arrange
            _cpu.Registers.BC = 0x1234;

            // Act
            _instructionSet.DCX_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x1233, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void DCX_B_ShouldBeSetToMaxIfUnderflow()
        {
            // Arrange
            _cpu.Registers.BC = 0x0000;

            // Act
            _instructionSet.DCX_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0xFFFF, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void DCX_D_ShouldIncrementByOne()
        {
            // Arrange
            _cpu.Registers.DE = 0x1234;

            // Act
            _instructionSet.DCX_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x1233, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void DCX_D_ShouldBeSetToMaxIfUnderflow()
        {
            // Arrange
            _cpu.Registers.DE = 0x0000;

            // Act
            _instructionSet.DCX_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0xFFFF, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void DCX_H_ShouldIncrementByOne()
        {
            // Arrange
            _cpu.Registers.HL = 0x1234;

            // Act
            _instructionSet.DCX_H(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x1233, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void DCX_H_ShouldBeSetToMaxIfUnderflow()
        {
            // Arrange
            _cpu.Registers.HL = 0x0000;

            // Act
            _instructionSet.DCX_H(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0xFFFF, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void DCX_SP_ShouldDecrementByOne()
        {
            // Arrange
            _cpu.Registers.SP = 0x1234;

            // Act
            _instructionSet.DCX_SP(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x1233, _cpu.Registers.SP);
        }

        [Fact]
        public void DCX_SP_ShouldBeSetToMaxIfUnderflow()
        {
            // Arrange
            _cpu.Registers.SP = 0x0000;

            // Act
            _instructionSet.DCX_SP(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0xFFFF, _cpu.Registers.SP);
        }

        [Fact]
        public void DAD_B_ShouldAddBCToHL()
        {
            // Arrange
            _cpu.Registers.BC = 0x339F;
            _cpu.Registers.HL = 0xA17B;

            // Act
            _instructionSet.DAD_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x339F, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0xD51A, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void DAD_B_ShouldSetCarryFlag()
        {
            // Arrange
            _cpu.Registers.BC = 0x0001;
            _cpu.Registers.HL = 0xFFFF;

            // Act
            _instructionSet.DAD_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0001, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Carry);
        }

        [Fact]
        public void DAD_D_ShouldAddDEToHL()
        {
            // Arrange
            _cpu.Registers.DE = 0x339F;
            _cpu.Registers.HL = 0xA17B;

            // Act
            _instructionSet.DAD_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x339F, _cpu.Registers.DE);
            Assert.Equal(0xD51A, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void DAD_D_ShouldSetCarryFlag()
        {
            // Arrange
            _cpu.Registers.DE = 0x0001;
            _cpu.Registers.HL = 0xFFFF;

            // Act
            _instructionSet.DAD_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0001, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Carry);
        }

        [Fact]
        public void DAD_H_ShouldAddHLToHL()
        {
            // Arrange
            _cpu.Registers.HL = 0x339F;

            // Act
            _instructionSet.DAD_H(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x673E, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void DAD_H_ShouldSetCarryFlag()
        {
            // Arrange
            _cpu.Registers.HL = 0xFFFF;

            // Act
            _instructionSet.DAD_H(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0xFFFE, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Carry);
        }

        [Fact]
        public void DAD_SP_ShouldAddSPToHL()
        {
            // Arrange
            _cpu.Registers.HL = 0x339F;
            _cpu.Registers.SP = 0xA17B;

            // Act
            _instructionSet.DAD_SP(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0xD51A, _cpu.Registers.HL);
            Assert.Equal(0xA17B, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void DAD_SP_ShouldSetCarryFlag()
        {
            // Arrange
            _cpu.Registers.HL = 0xFFFF;
            _cpu.Registers.SP = 0x0001;

            // Act
            _instructionSet.DAD_SP(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0001, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Carry);
        }

        [Fact]
        public void POP_B_ShouldPopStackIntoBC()
        {
            // Arrange
            _memory.Setup(x => x[0x0010]).Returns(0xFF);
            _memory.Setup(x => x[0x0011]).Returns(0xFE);

            _cpu.Registers.SP = 0x0010;

            // Act
            _instructionSet.POP_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0xFEFF, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0012, _cpu.Registers.SP);
        }

        [Fact]
        public void PUSH_B_ShouldPushBCToStack()
        {
            // Arrange
            var memory = new DefaultMemory(0x100);
            var cpu = new CPU(memory, _instructionSet);
            
            cpu.Registers.BC = 0xFEFF;

            cpu.Registers.SP = 0x0012;

            // Act
            _instructionSet.PUSH_B(cpu);

            // Assert
            Assert.Equal(0x00, cpu.Registers.A);
            Assert.Equal(0xFEFF, cpu.Registers.BC);
            Assert.Equal(0x0000, cpu.Registers.DE);
            Assert.Equal(0x0000, cpu.Registers.HL);
            Assert.Equal(0x0010, cpu.Registers.SP);

            Assert.Equal(0xFF, cpu.Memory[0x0012]);
            Assert.Equal(0xFE, cpu.Memory[0x0013]);
        }
    }
}