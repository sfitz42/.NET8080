using Moq;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class ImmediateInstructionTests
    {
        private readonly CPU _cpu;
        private readonly IMemory _memory;

        public ImmediateInstructionTests()
        {
            _memory = new DefaultMemory(0x100);

            _cpu = new CPU(_memory);
        }

        [Fact]
        public void LXI_B_ShouldStoreImmediateDataInBC()
        {
            // Arrange
            _memory[0x0001] = 0x03;
            _memory[0x0002] = 0x01;

            // Act
            InstructionSet.LXI_B(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0x0103, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(3, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void LXI_D_ShouldStoreImmediateDataInDE()
        {
            // Arrange
            _memory[0x0001] = 0x03;
            _memory[0x0002] = 0x01;

            // Act
            InstructionSet.LXI_D(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0103, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(3, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void LXI_H_ShouldStoreImmediateDataInHL()
        {
            // Arrange
            _memory[0x0001] = 0x03;
            _memory[0x0002] = 0x01;

            // Act
            InstructionSet.LXI_H(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0103, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(3, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void LXI_SP_ShouldStoreImmediateDataInSP()
        {
            // Arrange
            _memory[0x0001] = 0x03;
            _memory[0x0002] = 0x01;

            // Act
            InstructionSet.LXI_SP(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0103, _cpu.Registers.SP);

            Assert.Equal(3, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void MVI_B_ShouldStoreImmediateDataInB()
        {
            // Arrange
            _memory[0x0001] = 0xFF;

            // Act
            InstructionSet.MVI_B(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0xFF00, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void MVI_C_ShouldStoreImmediateDataInC()
        {
            // Arrange
            _memory[0x0001] = 0xFF;

            // Act
            InstructionSet.MVI_C(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0x00FF, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void MVI_D_ShouldStoreImmediateDataInD()
        {
            // Arrange
            _memory[0x0001] = 0xFF;

            // Act
            InstructionSet.MVI_D(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0xFF00, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void MVI_E_ShouldStoreImmediateDataInE()
        {
            // Arrange
            _memory[0x0001] = 0xFF;

            // Act
            InstructionSet.MVI_E(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x00FF, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void MVI_H_ShouldStoreImmediateDataInH()
        {
            // Arrange
            _memory[0x0001] = 0xFF;

            // Act
            InstructionSet.MVI_H(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0xFF00, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void MVI_L_ShouldStoreImmediateDataInL()
        {
            // Arrange
            _memory[0x0001] = 0xFF;

            // Act
            InstructionSet.MVI_L(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x00FF, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void MVI_M_ShouldStoreImmediateDataInMemoryLocation()
        {
            // Arrange
            _cpu.Registers.HL = 0x0050;
            _memory[0x0001] = 0xFF;

            // Act
            InstructionSet.MVI_M(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0050, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(0xFF, _cpu.Memory[0x0050]);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void MVI_A_ShouldStoreImmediateDataInAccumulator()
        {
            // Arrange
            _memory[0x0001] = 0xFF;

            // Act
            InstructionSet.MVI_A(_cpu);

            // Assert
            Assert.Equal(0x00FF, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }
    }
}