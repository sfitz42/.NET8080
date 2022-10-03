using Intel8080.Emulator.Instructions;
using Moq;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class DataTransferInstructionTests
    {
        private readonly CPU _cpu;
        private readonly IMemory _memory;

        public DataTransferInstructionTests()
        {
            _memory = new DefaultMemory(0x100);

            _cpu = new CPU(_memory);
        }

        [Fact]
        public void STAX_B_StoreAccumulator_LocationBC()
        {
            // Arrange
            _cpu.Registers.A = 0x42;
            _cpu.Registers.BC = 0x0010;

            // Act
            DefaultInstructionSet.STAX_B(_cpu);

            // Assert
            Assert.Equal(0x0042, _memory[0x0010]);
            
            Assert.Equal(0x42, _cpu.Registers.A);
            Assert.Equal(0x0010, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void STAX_D_StoreAccumulator_LocationDE()
        {
            // Arrange
            _cpu.Registers.A = 0x42;
            _cpu.Registers.DE = 0x0010;

            // Act
            DefaultInstructionSet.STAX_D(_cpu);

            // Assert
            Assert.Equal(0x0042, _memory[0x0010]);

            Assert.Equal(0x42, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0010, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void LDAX_B_LoadAcculmulator_LocationBC()
        {
            // Arrange
            _memory[0x0010] = 0x0042;
            _cpu.Registers.BC = 0x0010;

            // Act
            DefaultInstructionSet.LDAX_B(_cpu);

            // Assert
            Assert.Equal(0x42, _cpu.Registers.A);
            Assert.Equal(0x0010, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void LDAX_D_LoadAcculmulator_LocationBC()
        {
            // Arrange
            _memory[0x0010] = 0x0042;
            _cpu.Registers.DE = 0x0010;

            // Act
            DefaultInstructionSet.LDAX_D(_cpu);

            // Assert
            Assert.Equal(0x42, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0010, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_B_B_ShouldStoreRegBInRegB()
        {
            // Arrange
            _cpu.Registers.B = 0xFF;

            // Act
            DefaultInstructionSet.MOV_B_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0xFF00, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_B_C_ShouldStoreRegCInRegB()
        {
            // Arrange
            _cpu.Registers.C = 0xFF;

            // Act
            DefaultInstructionSet.MOV_B_C(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0xFFFF, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_B_D_ShouldStoreRegDInRegB()
        {
            // Arrange
            _cpu.Registers.D = 0xFF;

            // Act
            DefaultInstructionSet.MOV_B_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0xFF00, _cpu.Registers.BC);
            Assert.Equal(0xFF00, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_B_E_ShouldStoreRegEInRegB()
        {
            // Arrange
            _cpu.Registers.E = 0xFF;

            // Act
            DefaultInstructionSet.MOV_B_E(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0xFF00, _cpu.Registers.BC);
            Assert.Equal(0x00FF, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_B_H_ShouldStoreRegHInRegB()
        {
            // Arrange
            _cpu.Registers.H = 0xFF;

            // Act
            DefaultInstructionSet.MOV_B_H(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0xFF00, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0xFF00, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_B_L_ShouldStoreRegLInRegB()
        {
            // Arrange
            _cpu.Registers.L = 0xFF;

            // Act
            DefaultInstructionSet.MOV_B_L(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0xFF00, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x00FF, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        
        [Fact]
        public void MOV_B_M_ShouldStoreMemoryByteInRegB()
        {
            // Arrange
            _cpu.Registers.H = 0x00;
            _cpu.Registers.L = 0x10;

            _cpu.Memory[0x0010] = 0xFF;

            // Act
            DefaultInstructionSet.MOV_B_M(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0xFF00, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0010, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(0xFF, _cpu.Memory[0x0010]);
        }

        [Fact]
        public void MOV_B_A_ShouldStoreAccumulatorInRegB()
        {
            // Arrange
            _cpu.Registers.A = 0xFF;

            // Act
            DefaultInstructionSet.MOV_B_A(_cpu);

            // Assert
            Assert.Equal(0xFF, _cpu.Registers.A);
            Assert.Equal(0xFF00, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_C_B_ShouldStoreRegBInRegC()
        {
            // Arrange
            _cpu.Registers.B = 0xFF;

            // Act
            DefaultInstructionSet.MOV_C_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0xFFFF, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_C_C_ShouldStoreRegCInRegC()
        {
            // Arrange
            _cpu.Registers.C = 0xFF;

            // Act
            DefaultInstructionSet.MOV_C_C(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x00FF, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_C_D_ShouldStoreRegDInRegC()
        {
            // Arrange
            _cpu.Registers.D = 0xFF;

            // Act
            DefaultInstructionSet.MOV_C_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x00FF, _cpu.Registers.BC);
            Assert.Equal(0xFF00, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_C_E_ShouldStoreRegEInRegC()
        {
            // Arrange
            _cpu.Registers.E = 0xFF;

            // Act
            DefaultInstructionSet.MOV_C_E(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x00FF, _cpu.Registers.BC);
            Assert.Equal(0x00FF, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_C_H_ShouldStoreRegHInRegC()
        {
            // Arrange
            _cpu.Registers.H = 0xFF;

            // Act
            DefaultInstructionSet.MOV_C_H(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x00FF, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0xFF00, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_C_L_ShouldStoreRegLInRegC()
        {
            // Arrange
            _cpu.Registers.L = 0xFF;

            // Act
            DefaultInstructionSet.MOV_C_L(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x00FF, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x00FF, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }
        
        [Fact]
        public void MOV_C_M_ShouldStoreMemoryByteInRegC()
        {
            // Arrange
            _cpu.Registers.H = 0x00;
            _cpu.Registers.L = 0x10;

            _cpu.Memory[0x0010] = 0xFF;

            // Act
            DefaultInstructionSet.MOV_C_M(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x00FF, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0010, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(0xFF, _cpu.Memory[0x0010]);
        }

        [Fact]
        public void MOV_C_A_ShouldStoreAccumulatorInRegC()
        {
            // Arrange
            _cpu.Registers.A = 0xFF;

            // Act
            DefaultInstructionSet.MOV_C_A(_cpu);

            // Assert
            Assert.Equal(0xFF, _cpu.Registers.A);
            Assert.Equal(0x00FF, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }
        
        [Fact]
        public void MOV_D_B_ShouldStoreRegBInRegD()
        {
            // Arrange
            _cpu.Registers.B = 0xFF;

            // Act
            DefaultInstructionSet.MOV_D_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0xFF00, _cpu.Registers.BC);
            Assert.Equal(0xFF00, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_D_C_ShouldStoreRegCInRegD()
        {
            // Arrange
            _cpu.Registers.C = 0xFF;

            // Act
            DefaultInstructionSet.MOV_D_C(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x00FF, _cpu.Registers.BC);
            Assert.Equal(0xFF00, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_D_D_ShouldStoreRegDInRegD()
        {
            // Arrange
            _cpu.Registers.D = 0xFF;

            // Act
            DefaultInstructionSet.MOV_D_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0xFF00, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_D_E_ShouldStoreRegEInRegD()
        {
            // Arrange
            _cpu.Registers.E = 0xFF;

            // Act
            DefaultInstructionSet.MOV_D_E(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0xFFFF, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_D_H_ShouldStoreRegHInRegD()
        {
            // Arrange
            _cpu.Registers.H = 0xFF;

            // Act
            DefaultInstructionSet.MOV_D_H(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0xFF00, _cpu.Registers.DE);
            Assert.Equal(0xFF00, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_D_L_ShouldStoreRegLInRegD()
        {
            // Arrange
            _cpu.Registers.L = 0xFF;

            // Act
            DefaultInstructionSet.MOV_D_L(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0xFF00, _cpu.Registers.DE);
            Assert.Equal(0x00FF, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        
        [Fact]
        public void MOV_D_M_ShouldStoreMemoryByteInRegD()
        {
            // Arrange
            _cpu.Registers.H = 0x00;
            _cpu.Registers.L = 0x10;

            _cpu.Memory[0x0010] = 0xFF;

            // Act
            DefaultInstructionSet.MOV_D_M(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0xFF00, _cpu.Registers.DE);
            Assert.Equal(0x0010, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(0xFF, _cpu.Memory[0x0010]);
        }

        [Fact]
        public void MOV_D_A_ShouldStoreAccumulatorInRegD()
        {
            // Arrange
            _cpu.Registers.A = 0xFF;

            // Act
            DefaultInstructionSet.MOV_D_A(_cpu);

            // Assert
            Assert.Equal(0xFF, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0xFF00, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_E_B_ShouldStoreRegBInRegE()
        {
            // Arrange
            _cpu.Registers.B = 0xFF;

            // Act
            DefaultInstructionSet.MOV_E_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0xFF00, _cpu.Registers.BC);
            Assert.Equal(0x00FF, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_E_C_ShouldStoreRegCInRegE()
        {
            // Arrange
            _cpu.Registers.C = 0xFF;

            // Act
            DefaultInstructionSet.MOV_E_C(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x00FF, _cpu.Registers.BC);
            Assert.Equal(0x00FF, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_E_D_ShouldStoreRegDInRegE()
        {
            // Arrange
            _cpu.Registers.D = 0xFF;

            // Act
            DefaultInstructionSet.MOV_E_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0xFFFF, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_E_E_ShouldStoreRegEInRegE()
        {
            // Arrange
            _cpu.Registers.E = 0xFF;

            // Act
            DefaultInstructionSet.MOV_E_E(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x00FF, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_E_H_ShouldStoreRegHInRegE()
        {
            // Arrange
            _cpu.Registers.H = 0xFF;

            // Act
            DefaultInstructionSet.MOV_E_H(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x00FF, _cpu.Registers.DE);
            Assert.Equal(0xFF00, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_E_L_ShouldStoreRegLInRegE()
        {
            // Arrange
            _cpu.Registers.L = 0xFF;

            // Act
            DefaultInstructionSet.MOV_E_L(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x00FF, _cpu.Registers.DE);
            Assert.Equal(0x00FF, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        
        [Fact]
        public void MOV_E_M_ShouldStoreMemoryByteInRegE()
        {
            // Arrange
            _cpu.Registers.H = 0x00;
            _cpu.Registers.L = 0x10;

            _cpu.Memory[0x0010] = 0xFF;

            // Act
            DefaultInstructionSet.MOV_E_M(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x00FF, _cpu.Registers.DE);
            Assert.Equal(0x0010, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(0xFF, _cpu.Memory[0x0010]);
        }

        [Fact]
        public void MOV_E_A_ShouldStoreAccumulatorInRegE()
        {
            // Arrange
            _cpu.Registers.A = 0xFF;

            // Act
            DefaultInstructionSet.MOV_E_A(_cpu);

            // Assert
            Assert.Equal(0xFF, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x00FF, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }
        
        [Fact]
        public void MOV_H_B_ShouldStoreRegBInRegH()
        {
            // Arrange
            _cpu.Registers.B = 0xFF;

            // Act
            DefaultInstructionSet.MOV_H_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0xFF00, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0xFF00, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_H_C_ShouldStoreRegCInRegH()
        {
            // Arrange
            _cpu.Registers.C = 0xFF;

            // Act
            DefaultInstructionSet.MOV_H_C(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x00FF, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0xFF00, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_H_D_ShouldStoreRegDInRegH()
        {
            // Arrange
            _cpu.Registers.D = 0xFF;

            // Act
            DefaultInstructionSet.MOV_H_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0xFF00, _cpu.Registers.DE);
            Assert.Equal(0xFF00, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_H_E_ShouldStoreRegEInRegH()
        {
            // Arrange
            _cpu.Registers.E = 0xFF;

            // Act
            DefaultInstructionSet.MOV_H_E(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x00FF, _cpu.Registers.DE);
            Assert.Equal(0xFF00, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_H_H_ShouldStoreRegHInRegH()
        {
            // Arrange
            _cpu.Registers.H = 0xFF;

            // Act
            DefaultInstructionSet.MOV_H_H(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0xFF00, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_H_L_ShouldStoreRegLInRegH()
        {
            // Arrange
            _cpu.Registers.L = 0xFF;

            // Act
            DefaultInstructionSet.MOV_H_L(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0xFFFF, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        
        [Fact]
        public void MOV_H_M_ShouldStoreMemoryByteInRegH()
        {
            // Arrange
            _cpu.Registers.H = 0x00;
            _cpu.Registers.L = 0x10;

            _cpu.Memory[0x0010] = 0xFF;

            // Act
            DefaultInstructionSet.MOV_H_M(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0xFF10, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(0xFF, _cpu.Memory[0x0010]);
        }

        [Fact]
        public void MOV_H_A_ShouldStoreAccumulatorInRegH()
        {
            // Arrange
            _cpu.Registers.A = 0xFF;

            // Act
            DefaultInstructionSet.MOV_H_A(_cpu);

            // Assert
            Assert.Equal(0xFF, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0xFF00, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_L_B_ShouldStoreRegBInRegL()
        {
            // Arrange
            _cpu.Registers.B = 0xFF;

            // Act
            DefaultInstructionSet.MOV_L_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0xFF00, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x00FF, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_L_C_ShouldStoreRegCInRegL()
        {
            // Arrange
            _cpu.Registers.C = 0xFF;

            // Act
            DefaultInstructionSet.MOV_L_C(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x00FF, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x00FF, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_L_D_ShouldStoreRegDInRegL()
        {
            // Arrange
            _cpu.Registers.D = 0xFF;

            // Act
            DefaultInstructionSet.MOV_L_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0xFF00, _cpu.Registers.DE);
            Assert.Equal(0x00FF, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_L_E_ShouldStoreRegEInRegL()
        {
            // Arrange
            _cpu.Registers.E = 0xFF;

            // Act
            DefaultInstructionSet.MOV_L_E(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x00FF, _cpu.Registers.DE);
            Assert.Equal(0x00FF, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_L_H_ShouldStoreRegHInRegL()
        {
            // Arrange
            _cpu.Registers.H = 0xFF;

            // Act
            DefaultInstructionSet.MOV_L_H(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0xFFFF, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_L_L_ShouldStoreRegLInRegL()
        {
            // Arrange
            _cpu.Registers.L = 0xFF;

            // Act
            DefaultInstructionSet.MOV_L_L(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x00FF, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        
        [Fact]
        public void MOV_L_M_ShouldStoreMemoryByteInRegL()
        {
            // Arrange
            _cpu.Registers.H = 0x00;
            _cpu.Registers.L = 0x10;

            _cpu.Memory[0x0010] = 0xFF;

            // Act
            DefaultInstructionSet.MOV_L_M(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x00FF, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(0xFF, _cpu.Memory[0x0010]);
        }

        [Fact]
        public void MOV_L_A_ShouldStoreAccumulatorInRegL()
        {
            // Arrange
            _cpu.Registers.A = 0xFF;

            // Act
            DefaultInstructionSet.MOV_L_A(_cpu);

            // Assert
            Assert.Equal(0xFF, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x00FF, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_M_B_ShouldStoreRegBInMemoryLocation()
        {
            // Arrange
            _cpu.Registers.B = 0xFF;
            _cpu.Registers.HL = 0x0010;

            // Act
            DefaultInstructionSet.MOV_M_B(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0xFF00, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0010, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(0xFF, _cpu.Memory[0x0010]);
        }

        [Fact]
        public void MOV_M_C_ShouldStoreRegCInMemoryLocation()
        {
            // Arrange
            _cpu.Registers.C = 0xFF;
            _cpu.Registers.HL = 0x0010;

            // Act
            DefaultInstructionSet.MOV_M_C(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x00FF, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0010, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(0xFF, _cpu.Memory[0x0010]);
        }

        [Fact]
        public void MOV_M_D_ShouldStoreRegDInMemoryLocation()
        {
            // Arrange
            _cpu.Registers.D = 0xFF;
            _cpu.Registers.HL = 0x0010;

            // Act
            DefaultInstructionSet.MOV_M_D(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0xFF00, _cpu.Registers.DE);
            Assert.Equal(0x0010, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(0xFF, _cpu.Memory[0x0010]);
        }

        [Fact]
        public void MOV_M_E_ShouldStoreRegEInMemoryLocation()
        {
            // Arrange
            _cpu.Registers.E = 0xFF;
            _cpu.Registers.HL = 0x0010;

            // Act
            DefaultInstructionSet.MOV_M_E(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x00FF, _cpu.Registers.DE);
            Assert.Equal(0x0010, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(0xFF, _cpu.Memory[0x0010]);
        }

        [Fact]
        public void MOV_M_H_ShouldStoreRegHInMemoryLocation()
        {
            // Arrange
            _cpu.Registers.HL = 0x0010;

            // Act
            DefaultInstructionSet.MOV_M_H(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0010, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(0x00, _cpu.Memory[0x0010]);
        }

        [Fact]
        public void MOV_M_L_ShouldStoreRegLInMemoryLocation()
        {
            // Arrange
            _cpu.Registers.HL = 0x0010;

            // Act
            DefaultInstructionSet.MOV_M_L(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0010, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(0x10, _cpu.Memory[0x0010]);
        }

        [Fact]
        public void MOV_M_A_ShouldStoreAccumulatorInMemoryLocation()
        {
            // Arrange
            _cpu.Registers.A = 0xFF;
            _cpu.Registers.HL = 0x0010;

            // Act
            DefaultInstructionSet.MOV_M_A(_cpu);

            // Assert
            Assert.Equal(0xFF, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0010, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(0xFF, _cpu.Memory[0x0010]);
        }

        [Fact]
        public void MOV_A_B_ShouldStoreRegBInAccumulator()
        {
            // Arrange
            _cpu.Registers.B = 0xFF;

            // Act
            DefaultInstructionSet.MOV_A_B(_cpu);

            // Assert
            Assert.Equal(0xFF, _cpu.Registers.A);
            Assert.Equal(0xFF00, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_A_C_ShouldStoreRegCInAccumulator()
        {
            // Arrange
            _cpu.Registers.C = 0xFF;

            // Act
            DefaultInstructionSet.MOV_A_C(_cpu);

            // Assert
            Assert.Equal(0xFF, _cpu.Registers.A);
            Assert.Equal(0x00FF, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_A_D_ShouldStoreRegDInAccumulator()
        {
            // Arrange
            _cpu.Registers.D = 0xFF;

            // Act
            DefaultInstructionSet.MOV_A_D(_cpu);

            // Assert
            Assert.Equal(0xFF, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0xFF00, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_A_E_ShouldStoreRegEInAccumulator()
        {
            // Arrange
            _cpu.Registers.E = 0xFF;

            // Act
            DefaultInstructionSet.MOV_A_E(_cpu);

            // Assert
            Assert.Equal(0xFF, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x00FF, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_A_H_ShouldStoreRegHInAccumulator()
        {
            // Arrange
            _cpu.Registers.H = 0xFF;

            // Act
            DefaultInstructionSet.MOV_A_H(_cpu);

            // Assert
            Assert.Equal(0xFF, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0xFF00, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void MOV_A_L_ShouldStoreRegLInAccumulator()
        {
            // Arrange
            _cpu.Registers.L = 0xFF;

            // Act
            DefaultInstructionSet.MOV_A_L(_cpu);

            // Assert
            Assert.Equal(0xFF, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x00FF, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        
        [Fact]
        public void MOV_A_M_ShouldStoreMemoryByteInAccumulator()
        {
            // Arrange
            _cpu.Registers.H = 0x00;
            _cpu.Registers.L = 0x10;

            _cpu.Memory[0x0010] = 0xFF;

            // Act
            DefaultInstructionSet.MOV_A_M(_cpu);

            // Assert
            Assert.Equal(0xFF, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0010, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(0xFF, _cpu.Memory[0x0010]);
        }

        [Fact]
        public void MOV_A_A_ShouldStoreAccumulatorInAccumulator()
        {
            // Arrange
            _cpu.Registers.A = 0xFF;

            // Act
            DefaultInstructionSet.MOV_A_A(_cpu);

            // Assert
            Assert.Equal(0xFF, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }
    }
}