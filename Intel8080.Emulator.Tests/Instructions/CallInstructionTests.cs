using Intel8080.Emulator.Instructions;
using Moq;
using System;
using Xunit;

namespace Intel8080.Emulator.Tests.Instructions
{
    public class CallInstructionTests
    {
        private readonly CPU _cpu;
        private readonly IMemory _memory;

        public CallInstructionTests()
        {
            _memory = new DefaultMemory(0x100);

            _cpu = new CPU(_memory);

            _cpu.Registers.PC = 1;
        }

        [Fact]
        public void CALL_ShouldCallSubroutine()
        {
            // Arrange
            _memory[0x0001] = 0x50;
            _memory[0x0002] = 0x00;

            _cpu.Registers.SP = 0x0012;

            // Act
            DefaultInstructionSet.CALL(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
            Assert.Equal(0x0010, _cpu.Registers.SP);

            Assert.Equal(0x03, _memory[0x0010]);
            Assert.Equal(0x00, _memory[0x0011]);
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
            DefaultInstructionSet.CNZ(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
            Assert.Equal(0x0010, _cpu.Registers.SP);

            Assert.Equal(0x03, _memory[0x0010]);
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
            DefaultInstructionSet.CNZ(_cpu);

            // Assert
            Assert.Equal(0x0003, _cpu.Registers.PC);
            Assert.Equal(0x0012, _cpu.Registers.SP);
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
            DefaultInstructionSet.CZ(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
            Assert.Equal(0x0010, _cpu.Registers.SP);

            Assert.Equal(0x03, _memory[0x0010]);
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
            DefaultInstructionSet.CZ(_cpu);

            // Assert
            Assert.Equal(0x0003, _cpu.Registers.PC);
            Assert.Equal(0x0012, _cpu.Registers.SP);
        }
        
        [Fact]
        public void RST_0_ShouldCall0x00()
        {
            _cpu.Registers.SP = 0x0012;

            // Act
            DefaultInstructionSet.RST_0(_cpu);

            // Assert
            Assert.Equal(0x0000, _cpu.Registers.PC);
            Assert.Equal(0x0010, _cpu.Registers.SP);

            Assert.Equal(0x01, _memory[0x0010]);
            Assert.Equal(0x00, _memory[0x0011]);
        }
        
        [Fact]
        public void RST_1_ShouldCall0x08()
        {
            _cpu.Registers.SP = 0x0012;

            // Act
            DefaultInstructionSet.RST_1(_cpu);

            // Assert
            Assert.Equal(0x0008, _cpu.Registers.PC);
            Assert.Equal(0x0010, _cpu.Registers.SP);

            Assert.Equal(0x01, _memory[0x0010]);
            Assert.Equal(0x00, _memory[0x0011]);
        }
        
        [Fact]
        public void RST_2_ShouldCall0x10()
        {
            _cpu.Registers.SP = 0x0012;

            // Act
            DefaultInstructionSet.RST_2(_cpu);

            // Assert
            Assert.Equal(0x0010, _cpu.Registers.PC);
            Assert.Equal(0x0010, _cpu.Registers.SP);

            Assert.Equal(0x01, _memory[0x0010]);
            Assert.Equal(0x00, _memory[0x0011]);
        }
        
        [Fact]
        public void RST_3_ShouldCall0x18()
        {
            _cpu.Registers.SP = 0x0012;

            // Act
            DefaultInstructionSet.RST_3(_cpu);

            // Assert
            Assert.Equal(0x0018, _cpu.Registers.PC);
            Assert.Equal(0x0010, _cpu.Registers.SP);

            Assert.Equal(0x01, _memory[0x0010]);
            Assert.Equal(0x00, _memory[0x0011]);
        }
        
        [Fact]
        public void RST_4_ShouldCall0x20()
        {
            _cpu.Registers.SP = 0x0012;

            // Act
            DefaultInstructionSet.RST_4(_cpu);

            // Assert
            Assert.Equal(0x0020, _cpu.Registers.PC);
            Assert.Equal(0x0010, _cpu.Registers.SP);

            Assert.Equal(0x01, _memory[0x0010]);
            Assert.Equal(0x00, _memory[0x0011]);
        }
        
        [Fact]
        public void RST_5_ShouldCall0x28()
        {
            _cpu.Registers.SP = 0x0012;

            // Act
            DefaultInstructionSet.RST_5(_cpu);

            // Assert
            Assert.Equal(0x0028, _cpu.Registers.PC);
            Assert.Equal(0x0010, _cpu.Registers.SP);

            Assert.Equal(0x01, _memory[0x0010]);
            Assert.Equal(0x00, _memory[0x0011]);
        }
        
        [Fact]
        public void RST_6_ShouldCall0x30()
        {
            _cpu.Registers.SP = 0x0012;

            // Act
            DefaultInstructionSet.RST_6(_cpu);

            // Assert
            Assert.Equal(0x0030, _cpu.Registers.PC);
            Assert.Equal(0x0010, _cpu.Registers.SP);

            Assert.Equal(0x01, _memory[0x0010]);
            Assert.Equal(0x00, _memory[0x0011]);
        }

                
        [Fact]
        public void RST_7_ShouldCall0x38()
        {
            _cpu.Registers.SP = 0x0012;

            // Act
            DefaultInstructionSet.RST_7(_cpu);

            // Assert
            Assert.Equal(0x0038, _cpu.Registers.PC);
            Assert.Equal(0x0010, _cpu.Registers.SP);

            Assert.Equal(0x01, _memory[0x0010]);
            Assert.Equal(0x00, _memory[0x0011]);
        }

        [Fact]
        public void CNC_ShouldCallIfZeroFlagFalse()
        {
            // Arrange
            _memory[0x0001] = 0x50;
            _memory[0x0002] = 0x00;

            _cpu.Registers.SP = 0x0012;

            _cpu.Flags.Carry = false;

            // Act
            DefaultInstructionSet.CNC(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
            Assert.Equal(0x0010, _cpu.Registers.SP);

            Assert.Equal(0x03, _memory[0x0010]);
            Assert.Equal(0x00, _memory[0x0011]);
        }

        [Fact]
        public void CNC_ShouldNotCallIfZeroFlagSet()
        {
            // Arrange
            _memory[0x0001] = 0x50;
            _memory[0x0002] = 0x00;

            _cpu.Registers.SP = 0x0012;

            _cpu.Flags.Carry = true;

            // Act
            DefaultInstructionSet.CNC(_cpu);

            // Assert
            Assert.Equal(0x0003, _cpu.Registers.PC);
            Assert.Equal(0x0012, _cpu.Registers.SP);
        }

        [Fact]
        public void CC_ShouldCallIfZeroFlagSet()
        {
            // Arrange
            _memory[0x0001] = 0x50;
            _memory[0x0002] = 0x00;

            _cpu.Registers.SP = 0x0012;

            _cpu.Flags.Carry = true;

            // Act
            DefaultInstructionSet.CC(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
            Assert.Equal(0x0010, _cpu.Registers.SP);

            Assert.Equal(0x03, _memory[0x0010]);
            Assert.Equal(0x00, _memory[0x0011]);
        }

        [Fact]
        public void CC_ShouldNotCallIfZeroFlagFalse()
        {
            // Arrange
            _memory[0x0001] = 0x50;
            _memory[0x0002] = 0x00;

            _cpu.Registers.SP = 0x0012;

            _cpu.Flags.Carry = false;

            // Act
            DefaultInstructionSet.CC(_cpu);

            // Assert
            Assert.Equal(0x0003, _cpu.Registers.PC);
            Assert.Equal(0x0012, _cpu.Registers.SP);
        }

        [Fact]
        public void CPO_ShouldNotCallIfParityEven()
        {
            // Arrange
            _memory[0x0001] = 0x50;
            _memory[0x0002] = 0x00;

            _cpu.Registers.SP = 0x0012;

            _cpu.Flags.Parity = false;

            // Act
            DefaultInstructionSet.CPO(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
            Assert.Equal(0x0010, _cpu.Registers.SP);

            Assert.Equal(0x03, _memory[0x0010]);
            Assert.Equal(0x00, _memory[0x0011]);
        }

        [Fact]
        public void CPO_ShouldCallIfParityOdd()
        {
            // Arrange
            _memory[0x0001] = 0x50;
            _memory[0x0002] = 0x00;

            _cpu.Registers.SP = 0x0012;

            _cpu.Flags.Parity = true;

            // Act
            DefaultInstructionSet.CPO(_cpu);

            // Assert
            Assert.Equal(0x0003, _cpu.Registers.PC);
            Assert.Equal(0x0012, _cpu.Registers.SP);
        }

        [Fact]
        public void CPE_ShouldNotCallIfParityEven()
        {
            // Arrange
            _memory[0x0001] = 0x50;
            _memory[0x0002] = 0x00;

            _cpu.Registers.SP = 0x0012;

            _cpu.Flags.Parity = true;

            // Act
            DefaultInstructionSet.CPE(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
            Assert.Equal(0x0010, _cpu.Registers.SP);

            Assert.Equal(0x03, _memory[0x0010]);
            Assert.Equal(0x00, _memory[0x0011]);
        }

        [Fact]
        public void CPE_ShouldNotCallIfParityOdd()
        {
            // Arrange
            _memory[0x0001] = 0x50;
            _memory[0x0002] = 0x00;

            _cpu.Registers.SP = 0x0012;

            _cpu.Flags.Parity = false;

            // Act
            DefaultInstructionSet.CPE(_cpu);

            // Assert
            Assert.Equal(0x0003, _cpu.Registers.PC);
            Assert.Equal(0x0012, _cpu.Registers.SP);
        }

        [Fact]
        public void CP_ShouldNotCallIfSignFlagReset()
        {
            // Arrange
            _memory[0x0001] = 0x50;
            _memory[0x0002] = 0x00;

            _cpu.Registers.SP = 0x0012;

            _cpu.Flags.Sign = false;

            // Act
            DefaultInstructionSet.CP(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
            Assert.Equal(0x0010, _cpu.Registers.SP);

            Assert.Equal(0x03, _memory[0x0010]);
            Assert.Equal(0x00, _memory[0x0011]);
        }

        [Fact]
        public void CP_ShouldCallIfSignFlagReset()
        {
            // Arrange
            _memory[0x0001] = 0x50;
            _memory[0x0002] = 0x00;

            _cpu.Registers.SP = 0x0012;

            _cpu.Flags.Sign = true;

            // Act
            DefaultInstructionSet.CP(_cpu);

            // Assert
            Assert.Equal(0x0003, _cpu.Registers.PC);
            Assert.Equal(0x0012, _cpu.Registers.SP);
        }

        [Fact]
        public void CM_ShouldNotCallIfSignFlagSet()
        {
            // Arrange
            _memory[0x0001] = 0x50;
            _memory[0x0002] = 0x00;

            _cpu.Registers.SP = 0x0012;

            _cpu.Flags.Sign = true;

            // Act
            DefaultInstructionSet.CM(_cpu);

            // Assert
            Assert.Equal(0x0050, _cpu.Registers.PC);
            Assert.Equal(0x0010, _cpu.Registers.SP);

            Assert.Equal(0x03, _memory[0x0010]);
            Assert.Equal(0x00, _memory[0x0011]);
        }

        [Fact]
        public void CM_ShouldNotCallIfSignFlagReset()
        {
            // Arrange
            _memory[0x0001] = 0x50;
            _memory[0x0002] = 0x00;

            _cpu.Registers.SP = 0x0012;

            _cpu.Flags.Parity = false;

            // Act
            DefaultInstructionSet.CPE(_cpu);

            // Assert
            Assert.Equal(0x0003, _cpu.Registers.PC);
            Assert.Equal(0x0012, _cpu.Registers.SP);
        }
    }
}