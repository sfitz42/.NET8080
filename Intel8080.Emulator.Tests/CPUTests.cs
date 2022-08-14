using Moq;
using Xunit;

namespace Intel8080.Emulator.Tests
{
    public class CPUTests
    {
        private readonly CPU _cpu;
        private readonly Mock<DefaultInstructionSet> _instructionSet;
        private readonly Mock<IMemory> _memory;

        public CPUTests()
        {
            _memory = new Mock<IMemory>();
            _instructionSet = new Mock<DefaultInstructionSet>();

            _cpu = new CPU(_memory.Object, _instructionSet.Object);
        }

        [Fact]
        public void NOP_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x00);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.NOP(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void LXI_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x01);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.LXI_B(_cpu), Times.Once);

            Assert.Equal(3, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void STAX_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x02);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.STAX_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void INX_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x03);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.INX_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void INR_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x04);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.INR_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void DCR_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x05);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.DCR_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MVI_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x06);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.MVI_B(_cpu), Times.Once);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void RLC_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x07);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.RLC(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void DAD_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x09);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.DAD_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void LDAX_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x0A);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.LDAX_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void DCX_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x0B);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.DCX_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void INR_C_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x0C);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.INR_C(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void DCR_C_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x0D);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.DCR_C(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MVI_C_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x0E);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.MVI_C(_cpu), Times.Once);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void RRC_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x0F);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.RRC(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void LXI_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x11);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.LXI_D(_cpu), Times.Once);

            Assert.Equal(3, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void STAX_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x12);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.STAX_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void INX_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x13);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.INX_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void INR_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x14);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.INR_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void DCR_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x15);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.DCR_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MVI_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x16);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.MVI_D(_cpu), Times.Once);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void RAL_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x17);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.RAL(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void DAD_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x19);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.DAD_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void LDAX_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x1A);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.LDAX_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void DCX_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x1B);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.DCX_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void INR_E_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x1C);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.INR_E(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void DCR_E_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x1D);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.DCR_E(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MVI_E_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x1E);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.MVI_E(_cpu), Times.Once);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void RAR_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x1F);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.RAR(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void LXI_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x21);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.LXI_H(_cpu), Times.Once);

            Assert.Equal(3, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void SHLD_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x22);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.SHLD(_cpu), Times.Once);

            Assert.Equal(3, _cpu.Registers.PC);
            Assert.Equal(16, _cpu.Cycles);
        }

        [Fact]
        public void INX_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x23);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.INX_H(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void INR_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x24);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.INR_H(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void DCR_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x25);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.DCR_H(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MVI_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x26);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.MVI_H(_cpu), Times.Once);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void DAA_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x27);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.DAA(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void DAD_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x29);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.DAD_H(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void LHLD_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x2A);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.LHLD(_cpu), Times.Once);

            Assert.Equal(3, _cpu.Registers.PC);
            Assert.Equal(16, _cpu.Cycles);
        }

        [Fact]
        public void DCX_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x2B);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.DCX_H(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void INR_L_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x2C);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.INR_L(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void DCR_L_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x2D);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.DCR_L(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MVI_L_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x2E);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.MVI_L(_cpu), Times.Once);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void CMA_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x2F);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.CMA(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void LXI_SP_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x31);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.LXI_SP(_cpu), Times.Once);

            Assert.Equal(3, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void STA_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x32);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.STA(_cpu), Times.Once);

            Assert.Equal(3, _cpu.Registers.PC);
            Assert.Equal(13, _cpu.Cycles);
        }

        [Fact]
        public void INX_SP_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x33);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.INX_SP(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void INR_M_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x34);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.INR_M(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void DCR_M_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x35);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.DCR_M(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void MVI_M_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x36);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.MVI_M(_cpu), Times.Once);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void STC_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x37);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.STC(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void DAD_SP_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x39);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.DAD_SP(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void LDA_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x3A);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.LDA(_cpu), Times.Once);

            Assert.Equal(3, _cpu.Registers.PC);
            Assert.Equal(13, _cpu.Cycles);
        }

        [Fact]
        public void DCX_SP_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x3B);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.DCX_SP(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void INR_A_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x3C);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.INR_A(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void DCR_A_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x3D);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.DCR_A(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MVI_A_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x3E);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.MVI_A(_cpu), Times.Once);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void CMC_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x3F);
            
            // Act
            _cpu.Run();

            // Assert
            _instructionSet.Verify(x => x.CMC(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }
    }
}