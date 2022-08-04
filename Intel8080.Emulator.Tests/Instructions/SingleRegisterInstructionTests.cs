using Moq;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class SingleRegisterInstructionTests
    {
        private readonly CPU _cpu;
        private readonly Mock<IMemory> _memory;

        public SingleRegisterInstructionTests()
        {
            _memory = new Mock<IMemory>();

            _cpu = new CPU(_memory.Object);
        }

        [Fact]
        public void INR_B_ShouldIncrementByOne()
        {
            // Arrange
            _cpu.Registers.B = 0x99;

            // Act
            InstructionSet.INR_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x9A00, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Registers.Flags.Sign);
            Assert.False(_cpu.Registers.Flags.Zero);
            Assert.False(_cpu.Registers.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Registers.Flags.Parity);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void INR_B_ShouldSetAuxCarry()
        {
            // Arrange
            _cpu.Registers.B = 0xFF;

            // Act
            InstructionSet.INR_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Registers.Flags.Sign);
            Assert.True(_cpu.Registers.Flags.Zero);
            Assert.True(_cpu.Registers.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Registers.Flags.Parity);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void INR_D_ShouldIncrementByOne()
        {
            // Arrange
            _cpu.Registers.D = 0x99;

            // Act
            InstructionSet.INR_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x9A00, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Registers.Flags.Sign);
            Assert.False(_cpu.Registers.Flags.Zero);
            Assert.False(_cpu.Registers.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Registers.Flags.Parity);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void INR_D_ShouldSetAuxCarry()
        {
            // Arrange
            _cpu.Registers.D = 0xFF;

            // Act
            InstructionSet.INR_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Registers.Flags.Sign);
            Assert.True(_cpu.Registers.Flags.Zero);
            Assert.True(_cpu.Registers.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Registers.Flags.Parity);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void INR_E_ShouldIncrementByOne()
        {
            // Arrange
            _cpu.Registers.E = 0x99;

            // Act
            InstructionSet.INR_E(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x009A, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Registers.Flags.Sign);
            Assert.False(_cpu.Registers.Flags.Zero);
            Assert.False(_cpu.Registers.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Registers.Flags.Parity);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void INR_E_ShouldSetAuxCarry()
        {
            // Arrange
            _cpu.Registers.E = 0xFF;

            // Act
            InstructionSet.INR_E(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Registers.Flags.Sign);
            Assert.True(_cpu.Registers.Flags.Zero);
            Assert.True(_cpu.Registers.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Registers.Flags.Parity);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }
    
        [Fact]
        public void DCR_B_ShouldDecrementByOne()
        {
            // Arrange
            _cpu.Registers.B = 0xFF;

            // Act
            InstructionSet.DCR_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0xFE00, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Registers.Flags.Sign);
            Assert.False(_cpu.Registers.Flags.Zero);
            Assert.False(_cpu.Registers.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Registers.Flags.Parity);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void DCR_B_ShouldSetAuxCarry()
        {
            // Arrange
            _cpu.Registers.B = 0x00;

            // Act
            InstructionSet.DCR_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0xFF00, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Registers.Flags.Sign);
            Assert.False(_cpu.Registers.Flags.Zero);
            Assert.True(_cpu.Registers.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Registers.Flags.Parity);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void DCR_D_ShouldDecrementByOne()
        {
            // Arrange
            _cpu.Registers.D = 0xFF;

            // Act
            InstructionSet.DCR_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0xFE00, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Registers.Flags.Sign);
            Assert.False(_cpu.Registers.Flags.Zero);
            Assert.False(_cpu.Registers.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Registers.Flags.Parity);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void DCR_D_ShouldSetAuxCarry()
        {
            // Arrange
            _cpu.Registers.D = 0x00;

            // Act
            InstructionSet.DCR_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0xFF00, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Registers.Flags.Sign);
            Assert.False(_cpu.Registers.Flags.Zero);
            Assert.True(_cpu.Registers.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Registers.Flags.Parity);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void DCR_E_ShouldDecrementByOne()
        {
            // Arrange
            _cpu.Registers.E = 0xFF;

            // Act
            InstructionSet.DCR_E(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x00FE, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Registers.Flags.Sign);
            Assert.False(_cpu.Registers.Flags.Zero);
            Assert.False(_cpu.Registers.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Registers.Flags.Parity);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void DCR_E_ShouldSetAuxCarry()
        {
            // Arrange
            _cpu.Registers.D = 0x00;

            // Act
            InstructionSet.DCR_E(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x00FF, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Registers.Flags.Sign);
            Assert.False(_cpu.Registers.Flags.Zero);
            Assert.True(_cpu.Registers.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Registers.Flags.Parity);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void INR_C_ShouldIncrementByOne()
        {
            // Arrange
            _cpu.Registers.C = 0x99;

            // Act
            InstructionSet.INR_C(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x009A, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Registers.Flags.Sign);
            Assert.False(_cpu.Registers.Flags.Zero);
            Assert.False(_cpu.Registers.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Registers.Flags.Parity);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void INR_C_ShouldSetAuxCarry()
        {
            // Arrange
            _cpu.Registers.C = 0xFF;

            // Act
            InstructionSet.INR_C(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Registers.Flags.Sign);
            Assert.True(_cpu.Registers.Flags.Zero);
            Assert.True(_cpu.Registers.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Registers.Flags.Parity);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }
    
        [Fact]
        public void DCR_C_ShouldDecrementByOne()
        {
            // Arrange
            _cpu.Registers.C = 0xFF;

            // Act
            InstructionSet.DCR_C(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x00FE, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Registers.Flags.Sign);
            Assert.False(_cpu.Registers.Flags.Zero);
            Assert.False(_cpu.Registers.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Registers.Flags.Parity);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void DCR_C_ShouldSetAuxCarry()
        {
            // Arrange
            _cpu.Registers.C = 0x00;

            // Act
            InstructionSet.DCR_C(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x00FF, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Registers.Flags.Sign);
            Assert.False(_cpu.Registers.Flags.Zero);
            Assert.True(_cpu.Registers.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Registers.Flags.Parity);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }
    }
}