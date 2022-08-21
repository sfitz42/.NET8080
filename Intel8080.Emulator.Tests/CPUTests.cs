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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

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
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CMC(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }
        
        [Fact]
        public void MOV_B_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x40);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_B_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_B_C_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x41);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_B_C(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_B_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x42);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_B_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_B_E_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x43);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_B_E(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_B_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x44);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_B_H(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_B_L_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x45);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_B_L(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_B_M_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x46);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_B_M(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void MOV_B_A_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x47);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_B_A(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_C_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x48);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_C_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_C_C_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x49);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_C_C(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_C_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x4A);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_C_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_C_E_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x4B);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_C_E(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_C_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x4C);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_C_H(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_C_L_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x4D);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_C_L(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_C_M_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x4E);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_C_M(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void MOV_C_A_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x4F);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_C_A(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_D_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x50);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_D_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_D_C_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x51);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_D_C(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_D_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x52);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_D_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_D_E_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x53);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_D_E(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_D_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x54);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_D_H(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_D_L_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x55);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_D_L(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_D_M_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x56);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_D_M(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void MOV_D_A_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x57);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_D_A(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_E_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x58);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_E_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_E_C_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x59);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_E_C(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_E_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x5A);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_E_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_E_E_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x5B);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_E_E(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_E_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x5C);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_E_H(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_E_L_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x5D);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_E_L(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_E_M_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x5E);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_E_M(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void MOV_E_A_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x5F);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_E_A(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_H_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x60);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_H_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_H_C_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x61);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_H_C(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_H_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x62);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_H_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_H_E_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x63);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_H_E(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_H_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x64);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_H_H(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_H_L_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x65);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_H_L(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_H_M_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x66);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_H_M(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void MOV_H_A_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x67);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_H_A(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_L_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x68);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_L_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_L_C_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x69);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_L_C(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_L_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x6A);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_L_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_L_E_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x6B);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_L_E(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_L_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x6C);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_L_H(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_L_L_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x6D);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_L_L(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_L_M_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x6E);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_L_M(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void MOV_L_A_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x6F);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_L_A(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_M_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x70);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_M_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void MOV_M_C_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x71);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_M_C(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void MOV_M_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x72);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_M_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void MOV_M_E_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x73);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_M_E(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void MOV_M_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x74);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_M_H(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void MOV_M_L_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x75);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_M_L(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void HLT_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x76);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.HLT(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void MOV_M_A_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x77);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_M_A(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void MOV_A_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x78);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_A_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_A_C_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x79);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_A_C(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_A_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x7A);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_A_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_A_E_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x7B);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_A_E(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_A_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x7C);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_A_H(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_A_L_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x7D);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_A_L(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void MOV_A_M_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x7E);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_A_M(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void MOV_A_A_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x7F);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.MOV_A_A(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void ADD_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x80);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ADD_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ADD_C_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x81);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ADD_C(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ADD_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x82);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ADD_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ADD_E_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x83);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ADD_E(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ADD_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x84);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ADD_H(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ADD_L_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x85);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ADD_L(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ADD_M_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x86);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ADD_M(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void ADD_A_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x87);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ADD_A(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ADC_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x88);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ADC_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ADC_C_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x89);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ADC_C(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ADC_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x8A);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ADC_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ADC_E_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x8B);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ADC_E(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ADC_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x8C);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ADC_H(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ADC_L_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x8D);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ADC_L(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ADC_M_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x8E);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ADC_M(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void ADC_A_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x8F);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ADC_A(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }
    }
}