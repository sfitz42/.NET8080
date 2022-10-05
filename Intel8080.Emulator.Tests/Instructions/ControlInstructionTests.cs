using Intel8080.Emulator.Instructions;
using Intel8080.Emulator.IO;
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

            _cpu = new CPU(_memory.Object);
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

            var inputDevice = new Mock<IInputDevice>();

            _cpu.IOController.AddDevice(inputDevice.Object, 0x00);

            inputDevice.Setup(x => x.Read()).Returns(0x48);

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

            var outputDevice = new Mock<IOutputDevice>();

            _cpu.IOController.AddDevice(outputDevice.Object, 0x00);

            // Act
            DefaultInstructionSet.OUT(_cpu);

            // Assert
            outputDevice.Verify(x => x.Write(_cpu.Registers.A), Times.Once);
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