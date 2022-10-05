using Intel8080.Emulator.Instructions;
using Moq;
using System;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class AccumulatorInstructionTests
    {
        private readonly CPU _cpu;
        private readonly Mock<IMemory> _memory;

        public AccumulatorInstructionTests()
        {
            _memory = new Mock<IMemory>();

            _cpu = new CPU(_memory.Object);
        }

        [Fact]
        public void ADD_B_ShouldAddRegBToAccumulator()
        {
            // Arrange
            _cpu.Registers.A = 0x6C;
            _cpu.Registers.B = 0x2E;

            // Act
            DefaultInstructionSet.ADD_B(_cpu);

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
            DefaultInstructionSet.ADD_C(_cpu);

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
            DefaultInstructionSet.ADD_D(_cpu);

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
            DefaultInstructionSet.ADD_E(_cpu);

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
            DefaultInstructionSet.ADD_H(_cpu);

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
            DefaultInstructionSet.ADD_L(_cpu);

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
            DefaultInstructionSet.ADD_M(_cpu);

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
            DefaultInstructionSet.ADD_A(_cpu);

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
            DefaultInstructionSet.ADC_B(_cpu);

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
            DefaultInstructionSet.ADC_B(_cpu);

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
            DefaultInstructionSet.ADC_C(_cpu);

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
            DefaultInstructionSet.ADC_C(_cpu);

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
            DefaultInstructionSet.ADC_D(_cpu);

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
            DefaultInstructionSet.ADC_D(_cpu);

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
            DefaultInstructionSet.ADC_E(_cpu);

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
            DefaultInstructionSet.ADC_E(_cpu);

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
            DefaultInstructionSet.ADC_H(_cpu);

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
            DefaultInstructionSet.ADC_H(_cpu);

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
            DefaultInstructionSet.ADC_L(_cpu);

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
            DefaultInstructionSet.ADC_L(_cpu);

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
            DefaultInstructionSet.ADC_M(_cpu);

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
            DefaultInstructionSet.ADC_M(_cpu);

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
            DefaultInstructionSet.ADC_A(_cpu);

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
            DefaultInstructionSet.ADC_A(_cpu);

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
            DefaultInstructionSet.SUB_B(_cpu);

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
            DefaultInstructionSet.SUB_C(_cpu);

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
            DefaultInstructionSet.SUB_D(_cpu);

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
            DefaultInstructionSet.SUB_E(_cpu);

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
            DefaultInstructionSet.SUB_H(_cpu);

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
            DefaultInstructionSet.SUB_L(_cpu);

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
            DefaultInstructionSet.SUB_M(_cpu);

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
            DefaultInstructionSet.SUB_A(_cpu);

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
            DefaultInstructionSet.SBB_B(_cpu);

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
            DefaultInstructionSet.SBB_B(_cpu);

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
            DefaultInstructionSet.SBB_C(_cpu);

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
            DefaultInstructionSet.SBB_C(_cpu);

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
            DefaultInstructionSet.SBB_D(_cpu);

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
            DefaultInstructionSet.SBB_D(_cpu);

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
            DefaultInstructionSet.SBB_E(_cpu);

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
            DefaultInstructionSet.SBB_E(_cpu);

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
            DefaultInstructionSet.SBB_H(_cpu);

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
            DefaultInstructionSet.SBB_H(_cpu);

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
            DefaultInstructionSet.SBB_L(_cpu);

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
            DefaultInstructionSet.SBB_L(_cpu);

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
            DefaultInstructionSet.SBB_M(_cpu);

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
            DefaultInstructionSet.SBB_M(_cpu);

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
            DefaultInstructionSet.SBB_A(_cpu);

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
            DefaultInstructionSet.SBB_A(_cpu);

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
            DefaultInstructionSet.ANA_B(_cpu);

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
            DefaultInstructionSet.ANA_C(_cpu);

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
            DefaultInstructionSet.ANA_D(_cpu);

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
            DefaultInstructionSet.ANA_E(_cpu);

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
            DefaultInstructionSet.ANA_H(_cpu);

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
            DefaultInstructionSet.ANA_L(_cpu);

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
            DefaultInstructionSet.ANA_M(_cpu);

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
            DefaultInstructionSet.ANA_A(_cpu);

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
            DefaultInstructionSet.XRA_B(_cpu);

            // Assert
            Assert.Equal(0x24, _cpu.Registers.A);
            Assert.Equal(0x7800, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
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
            DefaultInstructionSet.XRA_C(_cpu);

            // Assert
            Assert.Equal(0x24, _cpu.Registers.A);
            Assert.Equal(0x0078, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
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
            DefaultInstructionSet.XRA_D(_cpu);

            // Assert
            Assert.Equal(0x24, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x7800, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
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
            DefaultInstructionSet.XRA_E(_cpu);

            // Assert
            Assert.Equal(0x24, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0078, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
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
            DefaultInstructionSet.XRA_H(_cpu);

            // Assert
            Assert.Equal(0x24, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x7800, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
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
            DefaultInstructionSet.XRA_L(_cpu);

            // Assert
            Assert.Equal(0x24, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0078, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
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
            DefaultInstructionSet.XRA_M(_cpu);

            // Assert
            Assert.Equal(0x24, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0010, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void XRA_A_ShouldBitwiseXORAccumulatorRegA()
        {
            // Arrange
            _cpu.Registers.A = 0xFF;

            // Act
            DefaultInstructionSet.XRA_A(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.True(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ORA_B_ShouldBitwiseOrAccumulatorRegB()
        {
            // Arrange
            _cpu.Registers.A = 0x33;
            _cpu.Registers.B = 0x0F;

            // Act
            DefaultInstructionSet.ORA_B(_cpu);

            // Assert
            Assert.Equal(0x3F, _cpu.Registers.A);
            Assert.Equal(0x0F00, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }
        
        [Fact]
        public void ORA_C_ShouldBitwiseOrAccumulatorRegC()
        {
            // Arrange
            _cpu.Registers.A = 0x33;
            _cpu.Registers.C = 0x0F;

            // Act
            DefaultInstructionSet.ORA_C(_cpu);

            // Assert
            Assert.Equal(0x3F, _cpu.Registers.A);
            Assert.Equal(0x000F, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }
        
        [Fact]
        public void ORA_D_ShouldBitwiseOrAccumulatorRegD()
        {
            // Arrange
            _cpu.Registers.A = 0x33;
            _cpu.Registers.D = 0x0F;

            // Act
            DefaultInstructionSet.ORA_D(_cpu);

            // Assert
            Assert.Equal(0x3F, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0F00, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }
        
        [Fact]
        public void ORA_E_ShouldBitwiseOrAccumulatorRegE()
        {
            // Arrange
            _cpu.Registers.A = 0x33;
            _cpu.Registers.E = 0x0F;

            // Act
            DefaultInstructionSet.ORA_E(_cpu);

            // Assert
            Assert.Equal(0x3F, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x000F, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }
        
        [Fact]
        public void ORA_H_ShouldBitwiseOrAccumulatorRegH()
        {
            // Arrange
            _cpu.Registers.A = 0x33;
            _cpu.Registers.H = 0x0F;

            // Act
            DefaultInstructionSet.ORA_H(_cpu);

            // Assert
            Assert.Equal(0x3F, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0F00, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }
        
        [Fact]
        public void ORA_L_ShouldBitwiseOrAccumulatorRegL()
        {
            // Arrange
            _cpu.Registers.A = 0x33;
            _cpu.Registers.L = 0x0F;

            // Act
            DefaultInstructionSet.ORA_L(_cpu);

            // Assert
            Assert.Equal(0x3F, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x000F, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }
        
        [Fact]
        public void ORA_M_ShouldBitwiseOrAccumulatorRegL()
        {
            // Arrange
            _cpu.Registers.A = 0x33;
            _cpu.Registers.HL = 0x0010;

            _memory.Setup(x => x[0x0010]).Returns(0x0F);

            // Act
            DefaultInstructionSet.ORA_M(_cpu);

            // Assert
            Assert.Equal(0x3F, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0010, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void ORA_A_ShouldBitwiseOrAccumulatorRegL()
        {
            // Arrange
            _cpu.Registers.A = 0x33;

            // Act
            DefaultInstructionSet.ORA_A(_cpu);

            // Assert
            Assert.Equal(0x33, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void CMP_B_BLessThanA_ShouldResetCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x0A;
            _cpu.Registers.B = 0x05;

            // Act
            DefaultInstructionSet.CMP_B(_cpu);

            // Assert
            Assert.Equal(0x0A, _cpu.Registers.A);
            Assert.Equal(0x0500, _cpu.Registers.BC);
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
        public void CMP_B_BGreaterThanA_ShouldSetCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x02;
            _cpu.Registers.B = 0x05;

            // Act
            DefaultInstructionSet.CMP_B(_cpu);

            // Assert
            Assert.Equal(0x02, _cpu.Registers.A);
            Assert.Equal(0x0500, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.True(_cpu.Flags.Carry);
        }

        [Fact]
        public void CMP_B_BGreaterThanASignDiffer_ShouldResetCarry()
        {
            // Arrange
            _cpu.Registers.A = 0xE5;
            _cpu.Registers.B = 0x05;

            // Act
            DefaultInstructionSet.CMP_B(_cpu);

            // Assert
            Assert.Equal(0xE5, _cpu.Registers.A);
            Assert.Equal(0x0500, _cpu.Registers.BC);
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
        public void CMP_C_CLessThanA_ShouldResetCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x0A;
            _cpu.Registers.C = 0x05;

            // Act
            DefaultInstructionSet.CMP_C(_cpu);

            // Assert
            Assert.Equal(0x0A, _cpu.Registers.A);
            Assert.Equal(0x0005, _cpu.Registers.BC);
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
        public void CMP_C_CGreaterThanA_ShouldSetCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x02;
            _cpu.Registers.C = 0x05;

            // Act
            DefaultInstructionSet.CMP_C(_cpu);

            // Assert
            Assert.Equal(0x02, _cpu.Registers.A);
            Assert.Equal(0x0005, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.True(_cpu.Flags.Carry);
        }

        [Fact]
        public void CMP_C_CGreaterThanA_SignDifferShouldResetCarry()
        {
            // Arrange
            _cpu.Registers.A = 0xE5;
            _cpu.Registers.C = 0x05;

            // Act
            DefaultInstructionSet.CMP_C(_cpu);

            // Assert
            Assert.Equal(0xE5, _cpu.Registers.A);
            Assert.Equal(0x0005, _cpu.Registers.BC);
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
        public void CMP_D_DLessThanA_ShouldResetCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x0A;
            _cpu.Registers.D = 0x05;

            // Act
            DefaultInstructionSet.CMP_D(_cpu);

            // Assert
            Assert.Equal(0x0A, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0500, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void CMP_D_DGreaterThanA_ShouldSetCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x02;
            _cpu.Registers.D = 0x05;

            // Act
            DefaultInstructionSet.CMP_D(_cpu);

            // Assert
            Assert.Equal(0x02, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0500, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.True(_cpu.Flags.Carry);
        }

        [Fact]
        public void CMP_D_DGreaterThanA_SignDifferShouldResetCarry()
        {
            // Arrange
            _cpu.Registers.A = 0xE5;
            _cpu.Registers.D = 0x05;

            // Act
            DefaultInstructionSet.CMP_D(_cpu);

            // Assert
            Assert.Equal(0xE5, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0500, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void CMP_E_ELessThanA_ShouldResetCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x0A;
            _cpu.Registers.E = 0x05;

            // Act
            DefaultInstructionSet.CMP_E(_cpu);

            // Assert
            Assert.Equal(0x0A, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0005, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void CMP_E_EGreaterThanA_ShouldSetCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x02;
            _cpu.Registers.E = 0x05;

            // Act
            DefaultInstructionSet.CMP_E(_cpu);

            // Assert
            Assert.Equal(0x02, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0005, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.True(_cpu.Flags.Carry);
        }

        [Fact]
        public void CMP_E_EGreaterThanASignDiffer_ShouldResetCarry()
        {
            // Arrange
            _cpu.Registers.A = 0xE5;
            _cpu.Registers.E = 0x05;

            // Act
            DefaultInstructionSet.CMP_E(_cpu);

            // Assert
            Assert.Equal(0xE5, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0005, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void CMP_H_HLessThanA_ShouldResetCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x0A;
            _cpu.Registers.H = 0x05;

            // Act
            DefaultInstructionSet.CMP_H(_cpu);

            // Assert
            Assert.Equal(0x0A, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0500, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void CMP_H_HGreaterThanA_ShouldSetCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x02;
            _cpu.Registers.H = 0x05;

            // Act
            DefaultInstructionSet.CMP_H(_cpu);

            // Assert
            Assert.Equal(0x02, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0500, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.True(_cpu.Flags.Carry);
        }

        [Fact]
        public void CMP_H_HGreaterThanASignDiffer_ShouldResetCarry()
        {
            // Arrange
            _cpu.Registers.A = 0xE5;
            _cpu.Registers.H = 0x05;

            // Act
            DefaultInstructionSet.CMP_H(_cpu);

            // Assert
            Assert.Equal(0xE5, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0500, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void CMP_L_LLessThanA_ShouldResetCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x0A;
            _cpu.Registers.L = 0x05;

            // Act
            DefaultInstructionSet.CMP_L(_cpu);

            // Assert
            Assert.Equal(0x0A, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0005, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.True(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void CMP_L_LGreaterThanA_ShouldSetCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x02;
            _cpu.Registers.L = 0x05;

            // Act
            DefaultInstructionSet.CMP_L(_cpu);

            // Assert
            Assert.Equal(0x02, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0005, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.True(_cpu.Flags.Carry);
        }

        [Fact]
        public void CMP_L_LGreaterThanASignDiffer_ShouldResetCarry()
        {
            // Arrange
            _cpu.Registers.A = 0xE5;
            _cpu.Registers.L = 0x05;

            // Act
            DefaultInstructionSet.CMP_L(_cpu);

            // Assert
            Assert.Equal(0xE5, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0005, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.True(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.False(_cpu.Flags.Carry);
        }

        [Fact]
        public void CMP_M_MemoryByteLessThanA_ShouldResetCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x0A;
            _cpu.Registers.HL = 0x0010;

            _memory.Setup(x => x[0x0010]).Returns(0x05);

            // Act
            DefaultInstructionSet.CMP_M(_cpu);

            // Assert
            Assert.Equal(0x0A, _cpu.Registers.A);
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
        public void CMP_M_MemoryByteGreaterThanA_ShouldSetCarry()
        {
            // Arrange
            _cpu.Registers.A = 0x02;
            _cpu.Registers.HL = 0x0010;

            _memory.Setup(x => x[0x0010]).Returns(0x05);

            // Act
            DefaultInstructionSet.CMP_M(_cpu);

            // Assert
            Assert.Equal(0x02, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0010, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Sign);
            Assert.False(_cpu.Flags.Zero);
            Assert.False(_cpu.Flags.AuxiliaryCarry);
            Assert.False(_cpu.Flags.Parity);
            Assert.True(_cpu.Flags.Carry);
        }

        [Fact]
        public void CMP_M_MemoryByteGreaterThanASignDiffer_ShouldResetCarry()
        {
            // Arrange
            _cpu.Registers.A = 0xE5;
            _cpu.Registers.HL = 0x0010;

            _memory.Setup(x => x[0x0010]).Returns(0x05);

            // Act
            DefaultInstructionSet.CMP_M(_cpu);

            // Assert
            Assert.Equal(0xE5, _cpu.Registers.A);
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
        public void CMP_A_ShouldSetZeroFlag()
        {
            // Arrange
            _cpu.Registers.A = 0x05;

            // Act
            DefaultInstructionSet.CMP_A(_cpu);

            // Assert
            Assert.Equal(0x05, _cpu.Registers.A);
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