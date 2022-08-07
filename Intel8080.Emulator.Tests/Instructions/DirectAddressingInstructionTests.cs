using Moq;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class DirectAddressingInstructionTests
    {
        private readonly CPU _cpu;
        private readonly IMemory _memory;

        public DirectAddressingInstructionTests()
        {
            _memory = new DefaultMemory(0x300);

            _cpu = new CPU(_memory);
        }

        [Fact]
        public void SHLD_ShouldStoreHLInMemory()
        {
            // Arrange
            _memory[0x0001] = 0x0A;
            _memory[0x0002] = 0x01;
            _cpu.Registers.HL = 0xAE29;

            // Act
            InstructionSet.SHLD(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0xAE29, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(0x29, _memory[0x10A]);
            Assert.Equal(0xAE, _memory[0x10B]);

            Assert.Equal(3, _cpu.Registers.PC);
            Assert.Equal(16, _cpu.Cycles);
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
            InstructionSet.LHLD(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x03FF, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(3, _cpu.Registers.PC);
            Assert.Equal(16, _cpu.Cycles);
        }
    }
}