using Intel8080.Emulator.Instructions;
using Moq;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class ControlInstructions
    {
        private readonly CPU _cpu;
        private readonly Mock<IMemory> _memory;

        public ControlInstructions()
        {
            _memory = new Mock<IMemory>();

            _cpu = new CPU(_memory.Object, 1);
        }

        [Fact]
        public void NOP_ShouldAffectOnlyPCAndCycles()
        {
            // Act
            DefaultInstructionSet.NOP(_cpu);

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
            DefaultInstructionSet.HLT(_cpu);

            // Assert
            Assert.True(_cpu.Halted);
        }

        [Fact]
        public void IN_ShouldReadByteFromPort()
        {
            // Arrange
            _memory.Setup(x => x[0x0000]).Returns(0x00);

            _cpu.Ports[0].In = () => { return 0x48; };

            // Act
            DefaultInstructionSet.IN(_cpu);

            // Assert
            Assert.Equal(0x48, _cpu.Registers.A);
        }

        [Fact]
        public void OUT_ShouldWriteByteToPort()
        {
            // Arrange
            _cpu.Registers.A = 0x48;
            
            _memory.Setup(x => x[0x0000]).Returns(0x00);

            int output = 0;

            _cpu.Ports[0].Out = (byte x) => { output = x; };

            // Act
            DefaultInstructionSet.OUT(_cpu);

            // Assert
            Assert.Equal(0x48, _cpu.Registers.A);
            Assert.Equal(0x48, output);
        }

        [Fact]
        public void DI_ShouldDisableInterupts()
        {
            // Act
            DefaultInstructionSet.DI(_cpu);

            // Assert
            Assert.False(_cpu.InterruptEnabled);
        }

        [Fact]
        public void EI_ShouldEnableInterupts()
        {
            // Act
            DefaultInstructionSet.EI(_cpu);

            // Assert
            Assert.True(_cpu.InterruptEnabled);
        }
    }
}