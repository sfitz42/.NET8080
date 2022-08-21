using Moq;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class AcculmulatorInstructions
    {
        private readonly CPU _cpu;
        private readonly IInstructionSet _instructionSet;
        private readonly Mock<IMemory> _memory;

        public AcculmulatorInstructions()
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
    }
}