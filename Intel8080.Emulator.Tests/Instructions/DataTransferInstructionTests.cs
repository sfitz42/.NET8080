using Moq;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class DataTransferInstructionTests
    {
        private readonly CPU _cpu;
        private readonly IInstructionSet _instructionSet;
        private readonly IMemory _memory;

        public DataTransferInstructionTests()
        {
            _memory = new DefaultMemory(0x100);
            _instructionSet = new DefaultInstructionSet();

            _cpu = new CPU(_memory, _instructionSet);
        }

        [Fact]
        public void STAX_B_StoreAccumulator_LocationBC()
        {
            // Arrange
            _cpu.Registers.A = 0x42;
            _cpu.Registers.BC = 0x0010;

            // Act
            _instructionSet.STAX_B(_cpu);

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
            _instructionSet.STAX_D(_cpu);

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
            _instructionSet.LDAX_B(_cpu);

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
            _instructionSet.LDAX_D(_cpu);

            // Assert
            Assert.Equal(0x42, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0010, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }
    }
}