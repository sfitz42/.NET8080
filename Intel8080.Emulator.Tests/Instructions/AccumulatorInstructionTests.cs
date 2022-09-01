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

        [Fact]
        public void SUB_B_ShouldSubtractRegBFromAccumulator()
        {
            // Arrange
            _cpu.Registers.A = 0x3E;
            _cpu.Registers.B = 0x3E;

            // Act
            _instructionSet.SUB_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x3E00, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.True(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void SUB_C_ShouldSubtractRegCFromAccumulator()
        {
            // Arrange
            _cpu.Registers.A = 0x3E;
            _cpu.Registers.C = 0x3E;

            // Act
            _instructionSet.SUB_C(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x003E, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.True(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void SUB_D_ShouldSubtractRegDFromAccumulator()
        {
            // Arrange
            _cpu.Registers.A = 0x3E;
            _cpu.Registers.D = 0x3E;

            // Act
            _instructionSet.SUB_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x3E00, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.True(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void SUB_E_ShouldSubtractRegEFromAccumulator()
        {
            // Arrange
            _cpu.Registers.A = 0x3E;
            _cpu.Registers.E = 0x3E;

            // Act
            _instructionSet.SUB_E(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x003E, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.True(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void SUB_H_ShouldSubtractRegHFromAccumulator()
        {
            // Arrange
            _cpu.Registers.A = 0x3E;
            _cpu.Registers.H = 0x3E;

            // Act
            _instructionSet.SUB_H(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x3E00, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.True(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void SUB_L_ShouldSubtractRegLFromAccumulator()
        {
            // Arrange
            _cpu.Registers.A = 0x3E;
            _cpu.Registers.L = 0x3E;

            // Act
            _instructionSet.SUB_L(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x003E, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.True(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void SUB_M_ShouldSubtractMemoryByteFromAccumulator()
        {
            // Arrange
            _cpu.Registers.A = 0x3E;
            _cpu.Registers.HL = 0x0010;

            _memory.Setup(x => x[0x0010]).Returns(0x3E);

            // Act
            _instructionSet.SUB_M(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0010, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.True(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void SUB_A_ShouldSubtractRegAFromAccumulator()
        {
            // Arrange
            _cpu.Registers.A = 0x3E;

            // Act
            _instructionSet.SUB_A(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.True(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void SBB_B_ShouldSubtractRegBFromAccumulator_NoCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x04;
            _cpu.Registers.B = 0x02;

            _cpu.Flags.Carry = false;

            // Act
            _instructionSet.SBB_B(_cpu);

            // Assert
            Assert.Equal(0x02, _cpu.Registers.A);
            Assert.Equal(0x0200, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void SBB_B_ShouldSubtractRegBFromAccumulator_Carry()
        {
            // Arrange
            _cpu.Registers.A = 0x04;
            _cpu.Registers.B = 0x02;

            _cpu.Flags.Carry = true;

            // Act
            _instructionSet.SBB_B(_cpu);

            // Assert
            Assert.Equal(0x01, _cpu.Registers.A);
            Assert.Equal(0x0200, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void SBB_C_ShouldSubtractRegCFromAccumulator_NoCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x04;
            _cpu.Registers.C = 0x02;

            _cpu.Flags.Carry = false;

            // Act
            _instructionSet.SBB_C(_cpu);

            // Assert
            Assert.Equal(0x02, _cpu.Registers.A);
            Assert.Equal(0x0002, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void SBB_C_ShouldSubtractRegCFromAccumulator_Carry()
        {
            // Arrange
            _cpu.Registers.A = 0x04;
            _cpu.Registers.C = 0x02;

            _cpu.Flags.Carry = true;

            // Act
            _instructionSet.SBB_C(_cpu);

            // Assert
            Assert.Equal(0x01, _cpu.Registers.A);
            Assert.Equal(0x0002, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void SBB_D_ShouldSubtractRegDFromAccumulator_NoCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x04;
            _cpu.Registers.D = 0x02;

            _cpu.Flags.Carry = false;

            // Act
            _instructionSet.SBB_D(_cpu);

            // Assert
            Assert.Equal(0x02, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0200, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void SBB_D_ShouldSubtractRegDFromAccumulator_Carry()
        {
            // Arrange
            _cpu.Registers.A = 0x04;
            _cpu.Registers.D = 0x02;

            _cpu.Flags.Carry = true;

            // Act
            _instructionSet.SBB_D(_cpu);

            // Assert
            Assert.Equal(0x01, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0200, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }
        
        [Fact]
        public void SBB_E_ShouldSubtractRegEFromAccumulator_NoCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x04;
            _cpu.Registers.E = 0x02;

            _cpu.Flags.Carry = false;

            // Act
            _instructionSet.SBB_E(_cpu);

            // Assert
            Assert.Equal(0x02, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0002, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void SBB_E_ShouldSubtractRegEFromAccumulator_Carry()
        {
            // Arrange
            _cpu.Registers.A = 0x04;
            _cpu.Registers.E = 0x02;

            _cpu.Flags.Carry = true;

            // Act
            _instructionSet.SBB_E(_cpu);

            // Assert
            Assert.Equal(0x01, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0002, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }
        
        [Fact]
        public void SBB_H_ShouldSubtractRegHFromAccumulator_NoCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x04;
            _cpu.Registers.H = 0x02;

            _cpu.Flags.Carry = false;

            // Act
            _instructionSet.SBB_H(_cpu);

            // Assert
            Assert.Equal(0x02, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0200, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void SBB_H_ShouldSubtractRegHFromAccumulator_Carry()
        {
            // Arrange
            _cpu.Registers.A = 0x04;
            _cpu.Registers.H = 0x02;

            _cpu.Flags.Carry = true;

            // Act
            _instructionSet.SBB_H(_cpu);

            // Assert
            Assert.Equal(0x01, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0200, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }
        
        [Fact]
        public void SBB_L_ShouldSubtractRegLFromAccumulator_NoCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x04;
            _cpu.Registers.L = 0x02;

            _cpu.Flags.Carry = false;

            // Act
            _instructionSet.SBB_L(_cpu);

            // Assert
            Assert.Equal(0x02, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0002, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void SBB_L_ShouldSubtractRegLFromAccumulator_Carry()
        {
            // Arrange
            _cpu.Registers.A = 0x04;
            _cpu.Registers.L = 0x02;

            _cpu.Flags.Carry = true;

            // Act
            _instructionSet.SBB_L(_cpu);

            // Assert
            Assert.Equal(0x01, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0002, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void SBB_M_ShouldSubtractMemoryByteFromAccumulator_NoCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x04;
            _cpu.Registers.HL = 0x0010;

            _memory.Setup(x => x[0x0010]).Returns(0x02);

            _cpu.Flags.Carry = false;

            // Act
            _instructionSet.SBB_M(_cpu);

            // Assert
            Assert.Equal(0x02, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0010, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void SBB_M_ShouldSubtractMemoryByteFromAccumulator_Carry()
        {
            // Arrange
            _cpu.Registers.A = 0x04;
            _cpu.Registers.HL = 0x0010;

            _memory.Setup(x => x[0x0010]).Returns(0x02);

            _cpu.Flags.Carry = true;

            // Act
            _instructionSet.SBB_M(_cpu);

            // Assert
            Assert.Equal(0x01, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0010, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void SBB_A_ShouldSubtractAccumulator_NoCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x04;

            _cpu.Flags.Carry = false;

            // Act
            _instructionSet.SBB_A(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.True(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void SBB_A_ShouldSubtractAccumulator_Carry()
        {
            // Arrange
            _cpu.Registers.A = 0x04;

            _cpu.Flags.Carry = true;

            // Act
            _instructionSet.SBB_A(_cpu);

            // Assert
            Assert.Equal(0xFF, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.True(_cpu.Flags.Carry);
        }

        [Fact]
        public void ANA_B_ShouldBitwiseANDAccumulatorRegB()
        {
            // Arrange
            _cpu.Registers.A = 0xFC;
            _cpu.Registers.B = 0x0F;

            // Act
            _instructionSet.ANA_B(_cpu);

            // Assert
            Assert.Equal(0x0C, _cpu.Registers.A);
            Assert.Equal(0x0F00, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ANA_C_ShouldBitwiseANDAccumulatorRegC()
        {
            // Arrange
            _cpu.Registers.A = 0xFC;
            _cpu.Registers.C = 0x0F;

            // Act
            _instructionSet.ANA_C(_cpu);

            // Assert
            Assert.Equal(0x0C, _cpu.Registers.A);
            Assert.Equal(0x000F, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ANA_D_ShouldBitwiseANDAccumulatorRegD()
        {
            // Arrange
            _cpu.Registers.A = 0xFC;
            _cpu.Registers.D = 0x0F;

            // Act
            _instructionSet.ANA_D(_cpu);

            // Assert
            Assert.Equal(0x0C, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0F00, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ANA_E_ShouldBitwiseANDAccumulatorRegE()
        {
            // Arrange
            _cpu.Registers.A = 0xFC;
            _cpu.Registers.E = 0x0F;

            // Act
            _instructionSet.ANA_E(_cpu);

            // Assert
            Assert.Equal(0x0C, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x000F, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ANA_H_ShouldBitwiseANDAccumulatorRegH()
        {
            // Arrange
            _cpu.Registers.A = 0xFC;
            _cpu.Registers.H = 0x0F;

            // Act
            _instructionSet.ANA_H(_cpu);

            // Assert
            Assert.Equal(0x0C, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0F00, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ANA_L_ShouldBitwiseANDAccumulatorRegL()
        {
            // Arrange
            _cpu.Registers.A = 0xFC;
            _cpu.Registers.L = 0x0F;

            // Act
            _instructionSet.ANA_L(_cpu);

            // Assert
            Assert.Equal(0x0C, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x000F, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ANA_M_ShouldBitwiseANDAccumulatorMemoryByte()
        {
            // Arrange
            _cpu.Registers.A = 0xFC;
            _cpu.Registers.HL = 0x0010;

            _memory.Setup(x => x[0x0010]).Returns(0x0F);

            // Act
            _instructionSet.ANA_M(_cpu);

            // Assert
            Assert.Equal(0x0C, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0010, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ANA_A_ShouldBitwiseANDAccumulatorRegA()
        {
            // Arrange
            _cpu.Registers.A = 0xFF;

            // Act
            _instructionSet.ANA_A(_cpu);

            // Assert
            Assert.Equal(0xFF, _cpu.Registers.A);
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
        public void XRA_B_ShouldBitwiseXORAccumulatorRegB()
        {
            // Arrange
            _cpu.Registers.A = 0x5C;
            _cpu.Registers.B = 0x78;

            // Act
            _instructionSet.XRA_B(_cpu);

            // Assert
            Assert.Equal(0x24, _cpu.Registers.A);
            Assert.Equal(0x7800, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void XRA_C_ShouldBitwiseXORAccumulatorRegC()
        {
            // Arrange
            _cpu.Registers.A = 0x5C;
            _cpu.Registers.C = 0x78;

            // Act
            _instructionSet.XRA_C(_cpu);

            // Assert
            Assert.Equal(0x24, _cpu.Registers.A);
            Assert.Equal(0x0078, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void XRA_D_ShouldBitwiseXORAccumulatorRegD()
        {
            // Arrange
            _cpu.Registers.A = 0x5C;
            _cpu.Registers.D = 0x78;

            // Act
            _instructionSet.XRA_D(_cpu);

            // Assert
            Assert.Equal(0x24, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x7800, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void XRA_E_ShouldBitwiseXORAccumulatorRegD()
        {
            // Arrange
            _cpu.Registers.A = 0x5C;
            _cpu.Registers.E = 0x78;

            // Act
            _instructionSet.XRA_E(_cpu);

            // Assert
            Assert.Equal(0x24, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0078, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void XRA_H_ShouldBitwiseXORAccumulatorRegH()
        {
            // Arrange
            _cpu.Registers.A = 0x5C;
            _cpu.Registers.H = 0x78;

            // Act
            _instructionSet.XRA_H(_cpu);

            // Assert
            Assert.Equal(0x24, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x7800, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void XRA_L_ShouldBitwiseXORAccumulatorRegL()
        {
            // Arrange
            _cpu.Registers.A = 0x5C;
            _cpu.Registers.L = 0x78;

            // Act
            _instructionSet.XRA_L(_cpu);

            // Assert
            Assert.Equal(0x24, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0078, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void XRA_M_ShouldBitwiseXORAccumulatorMemoryByte()
        {
            // Arrange
            _cpu.Registers.A = 0x5C;
            _cpu.Registers.HL = 0x0010;

            _memory.Setup(x => x[0x0010]).Returns(0x78);

            // Act
            _instructionSet.XRA_M(_cpu);

            // Assert
            Assert.Equal(0x24, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0010, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void XRA_A_ShouldBitwiseXORAccumulatorRegA()
        {
            // Arrange
            _cpu.Registers.A = 0xFF;

            // Act
            _instructionSet.XRA_A(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.True(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }
    }
}