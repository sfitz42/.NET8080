using Moq;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class CarryBitInstructionTests
    {
        private readonly CPU _cpu;
        private readonly Mock<IMemory> _memory;

        public CarryBitInstructionTests()
        {
            _memory = new Mock<IMemory>();

            _cpu = new CPU(_memory.Object);
        }

        [Fact]
        public void NOP_ShouldAffectOnlyPCAndCycles()
        {
            // Act
            InstructionSet.NOP(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void STC_ShouldSetCarry()
        {
            // Arrange
            _cpu.Flags.Carry = false;

            // Act
            InstructionSet.STC(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Carry);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void CMC_ShouldSetCarryIfCarryIsFalse()
        {
            // Arrange
            _cpu.Flags.Carry = false;

            // Act
            InstructionSet.CMC(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.True(_cpu.Flags.Carry);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void CMC_ShouldUnsetCarryIfCarryIsTrue()
        {
            // Arrange
            _cpu.Flags.Carry = true;

            // Act
            InstructionSet.CMC(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);

            Assert.False(_cpu.Flags.Carry);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }
    }
}