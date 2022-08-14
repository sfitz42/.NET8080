using Moq;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class DirectAddressingInstructionTests
    {
        private readonly CPU _cpu;
        private readonly IInstructionSet _instructionSet;
        private readonly IMemory _memory;

        public DirectAddressingInstructionTests()
        {
            _memory = new DefaultMemory(0x300);
            _instructionSet = new DefaultInstructionSet();

            _cpu = new CPU(_memory, _instructionSet);
        }

        [Fact]
        public void STA_ShouldStoreAccumulatorInMemory()
        {
            // Arrange
            _memory[0x0001] = 0x0A;
            _memory[0x0002] = 0x01;
            _cpu.Registers.A = 0x42;

            // Act
            _instructionSet.STA(_cpu);

            // Assert
            Assert.Equal(0x42, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(0x42, _memory[0x10A]);
        }
        
        [Fact]
        public void SHLD_ShouldStoreHLInMemory()
        {
            // Arrange
            _memory[0x0001] = 0x0A;
            _memory[0x0002] = 0x01;
            _cpu.Registers.HL = 0xAE29;

            // Act
            _instructionSet.SHLD(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0xAE29, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(0x29, _memory[0x10A]);
            Assert.Equal(0xAE, _memory[0x10B]);
        }

        [Fact]
        public void LHLD_ShouldStoreMemoryInHL()
        {
            // Arrange
            _memory[0x0001] = 0x5B;
            _memory[0x0002] = 0x02;

            _memory[0x25B] = 0xFF;
            _memory[0x25C] = 0x03;

            // Act
            _instructionSet.LHLD(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x03FF, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }
        
        [Fact]
        public void LDA_ShouldStoreMemoryInAccumulator()
        {
            // Arrange
            _memory[0x0001] = 0x5B;
            _memory[0x0002] = 0x02;

            _memory[0x25B] = 0x42;

            // Act
            _instructionSet.LDA(_cpu);

            // Assert
            Assert.Equal(0x42, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }
    }
}