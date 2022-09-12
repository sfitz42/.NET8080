using Intel8080.Emulator.Instructions;
using Moq;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class ControlInstructions
    {
        private readonly CPU _cpu;
        private readonly IInstructionSet _instructionSet;
        private readonly Mock<IMemory> _memory;

        public ControlInstructions()
        {
            _memory = new Mock<IMemory>();
            _instructionSet = new DefaultInstructionSet();

            _cpu = new CPU(_memory.Object, _instructionSet);
        }

        [Fact]
        public void NOP_ShouldAffectOnlyPCAndCycles()
        {
            // Act
            _instructionSet.NOP(_cpu);

            // Assert
            Assert.Equal(0x00, _cpu.Registers.A);
            Assert.Equal(0x0000, _cpu.Registers.BC);
            Assert.Equal(0x0000, _cpu.Registers.DE);
            Assert.Equal(0x0000, _cpu.Registers.HL);
            Assert.Equal(0x0000, _cpu.Registers.SP);
        }

        [Fact]
        public void HLT_ShouldHaltCPU()
        {
            // Act
            _instructionSet.HLT(_cpu);

            // Assert
            Assert.True(_cpu.Halted);
        }

        [Fact]
        public void RNZ_ShouldNotReturnIfZeroFlagSet()
        {
            // Arrange
            _memory.Setup(x => x[0x0010]).Returns(0x50);
            _memory.Setup(x => x[0x0011]).Returns(0x00);

            _cpu.Registers.SP = 0x0010;

            _cpu.Flags.Zero = true;

            // Act
            _instructionSet.RNZ(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.PC);
        }

        [Fact]
        public void RNZ_ShouldReturnIfZeroFlagFalse()
        {
            // Arrange
            _memory.Setup(x => x[0x0010]).Returns(0x50);
            _memory.Setup(x => x[0x0011]).Returns(0x00);

            _cpu.Registers.SP = 0x0010;

            _cpu.Flags.Zero = false;

            // Act
            _instructionSet.RNZ(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
        }
    }
}