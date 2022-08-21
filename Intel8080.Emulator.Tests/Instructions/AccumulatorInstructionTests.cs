using Moq;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class AccumulatorInstructionTests
    {
        private readonly CPU _cpu;
        private readonly Mock<IMemory> _memory;
        private readonly IInstructionSet _instructionSet;

        public AccumulatorInstructionTests()
        {
            _memory = new Mock<IMemory>();

            _instructionSet = new DefaultInstructionSet();
            _cpu = new CPU(_memory.Object, _instructionSet);
        }

        [Fact]
        public void ADD_B_ShouldAddRegBToAccumulator()
        {
            // Arrange
            _cpu.Registers.A = 0x6C;
            _cpu.Registers.B = 0x2E;

            // Act
            _instructionSet.ADD_B(_cpu);

            // Assert
            Assert.Equal(0x9A, _cpu.Registers.A);
            Assert.Equal(0x2E00, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ADD_C_ShouldAddRegCToAccumulator()
        {
            // Arrange
            _cpu.Registers.A = 0x6C;
            _cpu.Registers.C = 0x2E;

            // Act
            _instructionSet.ADD_C(_cpu);

            // Assert
            Assert.Equal(0x9A, _cpu.Registers.A);
            Assert.Equal(0x002E, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ADD_D_ShouldAddRegDToAccumulator()
        {
            // Arrange
            _cpu.Registers.A = 0x6C;
            _cpu.Registers.D = 0x2E;

            // Act
            _instructionSet.ADD_D(_cpu);

            // Assert
            Assert.Equal(0x9A, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x2E00, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ADD_E_ShouldAddRegEToAccumulator()
        {
            // Arrange
            _cpu.Registers.A = 0x6C;
            _cpu.Registers.E = 0x2E;

            // Act
            _instructionSet.ADD_E(_cpu);

            // Assert
            Assert.Equal(0x9A, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x002E, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ADD_H_ShouldAddRegHToAccumulator()
        {
            // Arrange
            _cpu.Registers.A = 0x6C;
            _cpu.Registers.H = 0x2E;

            // Act
            _instructionSet.ADD_H(_cpu);

            // Assert
            Assert.Equal(0x9A, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x2E00, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ADD_L_ShouldAddRegLToAccumulator()
        {
            // Arrange
            _cpu.Registers.A = 0x6C;
            _cpu.Registers.L = 0x2E;

            // Act
            _instructionSet.ADD_L(_cpu);

            // Assert
            Assert.Equal(0x9A, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x002E, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ADD_M_ShouldAddMemoryByteToAccumulator()
        {
            // Arrange
            _cpu.Registers.A = 0x6C;
            _cpu.Registers.HL = 0x0010;
            
            _memory.Setup(x => x[0x0010]).Returns(0x2E);

            // Act
            _instructionSet.ADD_M(_cpu);

            // Assert
            Assert.Equal(0x9A, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0010, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ADD_A_ShouldDoubleAccumulator()
        {
            // Arrange
            _cpu.Registers.A = 0x6C;

            // Act
            _instructionSet.ADD_A(_cpu);

            // Assert
            Assert.Equal(0xD8, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ADC_B_ShouldAddRegBToAccumulator_NoCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x42;
            _cpu.Registers.B = 0x3D;

            _cpu.Flags.Carry = false;

            // Act
            _instructionSet.ADC_B(_cpu);

            // Assert
            Assert.Equal(0x7F, _cpu.Registers.A);
            Assert.Equal(0x3D00, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ADC_B_ShouldAddRegBToAccumulator_Carry()
        {
            // Arrange
            _cpu.Registers.A = 0x42;
            _cpu.Registers.B = 0x3D;

            _cpu.Flags.Carry = true;

            // Act
            _instructionSet.ADC_B(_cpu);

            // Assert
            Assert.Equal(0x80, _cpu.Registers.A);
            Assert.Equal(0x3D00, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ADC_C_ShouldAddRegCToAccumulator_NoCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x42;
            _cpu.Registers.C = 0x3D;

            _cpu.Flags.Carry = false;

            // Act
            _instructionSet.ADC_C(_cpu);

            // Assert
            Assert.Equal(0x7F, _cpu.Registers.A);
            Assert.Equal(0x003D, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ADC_C_ShouldAddRegCToAccumulator_Carry()
        {
            // Arrange
            _cpu.Registers.A = 0x42;
            _cpu.Registers.C = 0x3D;

            _cpu.Flags.Carry = true;

            // Act
            _instructionSet.ADC_C(_cpu);

            // Assert
            Assert.Equal(0x80, _cpu.Registers.A);
            Assert.Equal(0x003D, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ADC_D_ShouldAddRegDToAccumulator_NoCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x42;
            _cpu.Registers.D = 0x3D;

            _cpu.Flags.Carry = false;

            // Act
            _instructionSet.ADC_D(_cpu);

            // Assert
            Assert.Equal(0x7F, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x3D00, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ADC_D_ShouldAddRegDToAccumulator_Carry()
        {
            // Arrange
            _cpu.Registers.A = 0x42;
            _cpu.Registers.D = 0x3D;

            _cpu.Flags.Carry = true;

            // Act
            _instructionSet.ADC_D(_cpu);

            // Assert
            Assert.Equal(0x80, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x3D00, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ADC_E_ShouldAddRegEToAccumulator_NoCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x42;
            _cpu.Registers.E = 0x3D;

            _cpu.Flags.Carry = false;

            // Act
            _instructionSet.ADC_E(_cpu);

            // Assert
            Assert.Equal(0x7F, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x003D, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ADC_E_ShouldAddRegEToAccumulator_Carry()
        {
            // Arrange
            _cpu.Registers.A = 0x42;
            _cpu.Registers.E = 0x3D;

            _cpu.Flags.Carry = true;

            // Act
            _instructionSet.ADC_E(_cpu);

            // Assert
            Assert.Equal(0x80, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x003D, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ADC_H_ShouldAddRegHToAccumulator_NoCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x42;
            _cpu.Registers.H = 0x3D;

            _cpu.Flags.Carry = false;

            // Act
            _instructionSet.ADC_H(_cpu);

            // Assert
            Assert.Equal(0x7F, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x3D00, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ADC_H_ShouldAddRegHToAccumulator_Carry()
        {
            // Arrange
            _cpu.Registers.A = 0x42;
            _cpu.Registers.H = 0x3D;

            _cpu.Flags.Carry = true;

            // Act
            _instructionSet.ADC_H(_cpu);

            // Assert
            Assert.Equal(0x80, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x3D00, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ADC_L_ShouldAddRegLToAccumulator_NoCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x42;
            _cpu.Registers.L = 0x3D;

            _cpu.Flags.Carry = false;

            // Act
            _instructionSet.ADC_L(_cpu);

            // Assert
            Assert.Equal(0x7F, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x003D, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ADC_L_ShouldAddRegLToAccumulator_Carry()
        {
            // Arrange
            _cpu.Registers.A = 0x42;
            _cpu.Registers.L = 0x3D;

            _cpu.Flags.Carry = true;

            // Act
            _instructionSet.ADC_L(_cpu);

            // Assert
            Assert.Equal(0x80, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x003D, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ADC_M_ShouldAddMemoryByteToAccumulator_NoCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x42;
            _cpu.Registers.HL = 0x0010;

            _memory.Setup(x => x[0x0010]).Returns(0x3D);

            _cpu.Flags.Carry = false;

            // Act
            _instructionSet.ADC_M(_cpu);

            // Assert
            Assert.Equal(0x7F, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0010, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ADC_M_ShouldAddMemoryByteToAccumulator_Carry()
        {
            // Arrange
            _cpu.Registers.A = 0x42;
            _cpu.Registers.HL = 0x0010;

            _memory.Setup(x => x[0x0010]).Returns(0x3D);

            _cpu.Flags.Carry = true;

            // Act
            _instructionSet.ADC_M(_cpu);

            // Assert
            Assert.Equal(0x80, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0010, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ADC_A_ShouldDoubleAccumulator_NoCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x42;

            _cpu.Flags.Carry = false;

            // Act
            _instructionSet.ADC_A(_cpu);

            // Assert
            Assert.Equal(0x84, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ADC_A_ShouldDoubleAccumulator_Carry()
        {
            // Arrange
            _cpu.Registers.A = 0x42;

            _cpu.Flags.Carry = true;

            // Act
            _instructionSet.ADC_A(_cpu);

            // Assert
            Assert.Equal(0x85, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

    }
}