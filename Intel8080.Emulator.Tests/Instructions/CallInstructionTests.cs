using Intel8080.Emulator.Instructions;
using Moq;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class CallInstructionTests
    {
        private readonly CPU _cpu;
        private readonly IInstructionSet _instructionSet;
        private readonly IMemory _memory;

        public CallInstructionTests()
        {
            _memory = new DefaultMemory(0x100);
            _instructionSet = new DefaultInstructionSet();

            _cpu = new CPU(_memory, _instructionSet);

            _cpu.Registers.PC = 1;
        }

        [Fact]
        public void CNZ_ShouldCallIfZeroFlagFalse()
        {
            // Arrange
            _memory[0x0001] = 0x50;
            _memory[0x0002] = 0x00;

            _cpu.Registers.SP = 0x0012;

            _cpu.Flags.Zero = false;

            // Act
            _instructionSet.CNZ(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
            Assert.Equal(0x0010, _cpu.Registers.SP);

            Assert.Equal(0x04, _memory[0x0012]);
            Assert.Equal(0x00, _memory[0x0011]);
        }

        [Fact]
        public void CNZ_ShouldNotCallIfZeroFlagSet()
        {
            // Arrange
            _memory[0x0001] = 0x50;
            _memory[0x0002] = 0x00;

            _cpu.Registers.SP = 0x0012;

            _cpu.Flags.Zero = true;

            // Act
            _instructionSet.CNZ(_cpu);

            // Assert
            Assert.Equal(0x0003, _cpu.Registers.PC);
            Assert.Equal(0x0012, _cpu.Registers.SP);
        }
        
        [Fact]
        public void RST_0_ShouldCall0x00()
        {
            _cpu.Registers.SP = 0x0012;

            // Act
            _instructionSet.RST_0(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.PC);
            Assert.Equal(0x0010, _cpu.Registers.SP);

            Assert.Equal(0x02, _memory[0x0012]);
            Assert.Equal(0x00, _memory[0x0011]);
        }
        
        [Fact]
        public void RST_1_ShouldCall0x08()
        {
            _cpu.Registers.SP = 0x0012;

            // Act
            _instructionSet.RST_1(_cpu);

            // Assert
            Assert.Equal(0x0008, _cpu.Registers.PC);
            Assert.Equal(0x0010, _cpu.Registers.SP);

            Assert.Equal(0x02, _memory[0x0012]);
            Assert.Equal(0x00, _memory[0x0011]);
        }

        [Fact]
        public void CZ_ShouldCallIfZeroFlagSet()
        {
            // Arrange
            _memory[0x0001] = 0x50;
            _memory[0x0002] = 0x00;

            _cpu.Registers.SP = 0x0012;

            _cpu.Flags.Zero = true;

            // Act
            _instructionSet.CZ(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
            Assert.Equal(0x0010, _cpu.Registers.SP);

            Assert.Equal(0x04, _memory[0x0012]);
            Assert.Equal(0x00, _memory[0x0011]);
        }

        [Fact]
        public void CZ_ShouldNotCallIfZeroFlagFalse()
        {
            // Arrange
            _memory[0x0001] = 0x50;
            _memory[0x0002] = 0x00;

            _cpu.Registers.SP = 0x0012;

            _cpu.Flags.Zero = false;

            // Act
            _instructionSet.CZ(_cpu);

            // Assert
            Assert.Equal(0x0003, _cpu.Registers.PC);
            Assert.Equal(0x0012, _cpu.Registers.SP);
        }

        [Fact]
        public void CALL_ShouldCallSubroutine()
        {
            // Arrange
            _memory[0x0001] = 0x50;
            _memory[0x0002] = 0x00;

            _cpu.Registers.SP = 0x0012;

            // Act
            _instructionSet.CALL(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
            Assert.Equal(0x0010, _cpu.Registers.SP);

            Assert.Equal(0x04, _memory[0x0012]);
            Assert.Equal(0x00, _memory[0x0011]);
        }
    }
}