using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class ControlInstructionTests
    {
        private CPU _cpu;

        public ControlInstructionTests()
        {
            _cpu = new CPU(0x100);
        }

        [Fact]
        public void NOP_ShouldAffectOnlyPCAndCycles()
        {
            // Act
            InstructionSet.NOP(_cpu, InstructionSet.InstructionTable[0x00]);

            // Assert
            Assert.Equal(0, _cpu.Registers.A);
            Assert.Equal(0x02, _cpu.Registers.F);
            Assert.Equal(0, _cpu.Registers.BC);
            Assert.Equal(0, _cpu.Registers.DE);
            Assert.Equal(0, _cpu.Registers.HL);
            Assert.Equal(0, _cpu.Registers.SP);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }
    }
}