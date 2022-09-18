using Intel8080.Emulator.Instructions;
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

            _instructionSet.CallBase = true;

            _cpu = new CPU(_memory.Object, 1, _instructionSet.Object);
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

        [Fact]
        public void SUB_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x90);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.SUB_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void SUB_C_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x91);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.SUB_C(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void SUB_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x92);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.SUB_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void SUB_E_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x93);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.SUB_E(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void SUB_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x94);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.SUB_H(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void SUB_L_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x95);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.SUB_L(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void SUB_M_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x96);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.SUB_M(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void SUB_A_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x97);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.SUB_A(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void SBB_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x98);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.SBB_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void SBB_C_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x99);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.SBB_C(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void SBB_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x9A);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.SBB_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void SBB_E_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x9B);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.SBB_E(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void SBB_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x9C);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.SBB_H(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void SBB_L_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x9D);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.SBB_L(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void SBB_M_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x9E);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.SBB_M(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void SBB_A_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0x9F);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.SBB_A(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ANA_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xA0);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ANA_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ANA_C_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xA1);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ANA_C(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ANA_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xA2);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ANA_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ANA_E_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xA3);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ANA_E(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ANA_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xA4);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ANA_H(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ANA_L_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xA5);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ANA_L(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ANA_M_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xA6);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ANA_M(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void ANA_A_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xA7);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ANA_A(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void XRA_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xA8);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.XRA_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void XRA_C_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xA9);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.XRA_C(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void XRA_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xAA);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.XRA_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void XRA_E_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xAB);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.XRA_E(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void XRA_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xAC);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.XRA_H(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void XRA_L_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xAD);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.XRA_L(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void XRA_M_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xAE);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.XRA_M(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void XRA_A_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xAF);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.XRA_A(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ORA_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xB0);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ORA_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ORA_C_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xB1);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ORA_C(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ORA_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xB2);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ORA_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ORA_E_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xB3);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ORA_E(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ORA_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xB4);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ORA_H(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ORA_L_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xB5);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ORA_L(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void ORA_M_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xB6);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ORA_M(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void ORA_A_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xB7);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ORA_A(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void CMP_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xB8);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CMP_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void CMP_C_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xB9);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CMP_C(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void CMP_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xBA);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CMP_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void CMP_E_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xBB);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CMP_E(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void CMP_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xBC);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CMP_H(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void CMP_L_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xBD);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CMP_L(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void CMP_M_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xBE);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CMP_M(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void CMP_A_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xBF);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CMP_A(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void RNZ_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _cpu.Flags.Zero = true;

            _memory.Setup(x => x[0x00]).Returns(0xC0);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RNZ(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void RNZ_ShouldAddCyclesIfZeroFlagReset()
        {
            // Arrange
            _cpu.Flags.Zero = false;

            _memory.Setup(x => x[0x00]).Returns(0xC0);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RNZ(_cpu), Times.Once);

            Assert.Equal(11, _cpu.Cycles);
        }

        [Fact]
        public void POP_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xC1);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.POP_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void JNZ_ShouldAdvanceCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xC2);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.JNZ(_cpu), Times.Once);

            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void JMP_ShouldAdvanceCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xC3);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.JMP(_cpu), Times.Once);

            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void CNZ_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _cpu.Flags.Zero = true;

            _memory.Setup(x => x[0x00]).Returns(0xC4);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CNZ(_cpu), Times.Once);

            Assert.Equal(3, _cpu.Registers.PC);
            Assert.Equal(11, _cpu.Cycles);
        }

        [Fact]
        public void CNZ_ShouldAddCyclesIfZeroFlagReset()
        {
            // Arrange
            _cpu.Flags.Zero = false;

            _memory.Setup(x => x[0x00]).Returns(0xC4);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CNZ(_cpu), Times.Once);

            Assert.Equal(17, _cpu.Cycles);
        }

        [Fact]
        public void PUSH_B_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xC5);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.PUSH_B(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(11, _cpu.Cycles);
        }

        [Fact]
        public void ADI_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xC6);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ADI(_cpu), Times.Once);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void RST_0_ShouldAdvanceCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xC7);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RST_0(_cpu), Times.Once);

            Assert.Equal(11, _cpu.Cycles);
        }

        [Fact]
        public void RZ_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _cpu.Flags.Zero = false;

            _memory.Setup(x => x[0x00]).Returns(0xC8);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RZ(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void RZ_ShouldAddCyclesIfZeroFlagSet()
        {
            // Arrange
            _cpu.Flags.Zero = true;

            _memory.Setup(x => x[0x00]).Returns(0xC8);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RZ(_cpu), Times.Once);

            Assert.Equal(11, _cpu.Cycles);
        }

        [Fact]
        public void RET_ShouldAdvanceCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xC9);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RET(_cpu), Times.Once);

            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void JZ_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xCA);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.JZ(_cpu), Times.Once);

            Assert.Equal(3, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void CZ_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _cpu.Flags.Zero = false;

            _memory.Setup(x => x[0x00]).Returns(0xCC);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CZ(_cpu), Times.Once);

            Assert.Equal(3, _cpu.Registers.PC);
            Assert.Equal(11, _cpu.Cycles);
        }

        [Fact]
        public void CZ_ShouldAddCyclesIfZeroFlagSet()
        {
            // Arrange
            _cpu.Flags.Zero = true;

            _memory.Setup(x => x[0x00]).Returns(0xCC);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CZ(_cpu), Times.Once);

            Assert.Equal(17, _cpu.Cycles);
        }

        [Fact]
        public void CALL_ShouldAdvanceCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xCD);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CALL(_cpu), Times.Once);

            Assert.Equal(17, _cpu.Cycles);
        }

        [Fact]
        public void ACI_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xCE);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ACI(_cpu), Times.Once);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void RST_1_ShouldAdvanceCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xCF);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RST_1(_cpu), Times.Once);

            Assert.Equal(11, _cpu.Cycles);
        }
    
        [Fact]
        public void RNC_ShouldAdvancePCAndCyclesIfCarrySet()
        {
            // Arrange
            _cpu.Flags.Carry = true;

            _memory.Setup(x => x[0x00]).Returns(0xD0);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RNC(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void RNC_ShouldAddCyclesIfCarryFlagReset()
        {
            // Arrange
            _cpu.Flags.Carry = false;

            _memory.Setup(x => x[0x00]).Returns(0xD0);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RNC(_cpu), Times.Once);

            Assert.Equal(11, _cpu.Cycles);
        }

        [Fact]
        public void POP_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xD1);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.POP_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void JNC_ShouldAdvanceCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xD2);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.JNC(_cpu), Times.Once);

            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void OUT_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xD3);

            _cpu.Ports[0].Out = (byte x) => { return; };

            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.OUT(_cpu), Times.Once);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void CNC_ShouldAdvancePCAndCyclesIfCarrySet()
        {
            // Arrange
            _cpu.Flags.Carry = true;

            _memory.Setup(x => x[0x00]).Returns(0xD4);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CNC(_cpu), Times.Once);

            Assert.Equal(3, _cpu.Registers.PC);
            Assert.Equal(11, _cpu.Cycles);
        }

        [Fact]
        public void CNC_ShouldAddCyclesIfCarryFlagReset()
        {
            // Arrange
            _cpu.Flags.Carry = false;

            _memory.Setup(x => x[0x00]).Returns(0xD4);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CNC(_cpu), Times.Once);

            Assert.Equal(17, _cpu.Cycles);
        }

        [Fact]
        public void PUSH_D_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xD5);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.PUSH_D(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(11, _cpu.Cycles);
        }

        [Fact]
        public void SUI_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xD6);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.SUI(_cpu), Times.Once);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void RST_2_ShouldAdvanceCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xD7);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RST_2(_cpu), Times.Once);

            Assert.Equal(11, _cpu.Cycles);
        }

        [Fact]
        public void RC_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _cpu.Flags.Carry = false;

            _memory.Setup(x => x[0x00]).Returns(0xD8);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RC(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void RC_ShouldAddCyclesIfCarryFlagSet()
        {
            // Arrange
            _cpu.Flags.Carry = true;

            _memory.Setup(x => x[0x00]).Returns(0xD8);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RC(_cpu), Times.Once);

            Assert.Equal(11, _cpu.Cycles);
        }

        [Fact]
        public void JC_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xDA);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.JC(_cpu), Times.Once);

            Assert.Equal(3, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void IN_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xDB);

            _cpu.Ports[0].In = () => 0x10;
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.IN(_cpu), Times.Once);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void CC_ShouldAddCyclesIfCarryFlagSet()
        {
            // Arrange
            _cpu.Flags.Carry = true;

            _memory.Setup(x => x[0x00]).Returns(0xDC);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CC(_cpu), Times.Once);

            Assert.Equal(17, _cpu.Cycles);
        }

        [Fact]
        public void SBI_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xDE);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.SBI(_cpu), Times.Once);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void RST_3_ShouldAdvanceCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xDF);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RST_3(_cpu), Times.Once);

            Assert.Equal(11, _cpu.Cycles);
        }

        [Fact]
        public void RPO_ShouldAdvancePCAndCyclesIfParityEven()
        {
            // Arrange
            _cpu.Flags.Parity = true;

            _memory.Setup(x => x[0x00]).Returns(0xE0);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RPO(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void RPO_ShouldAddCyclesIfParityOdd()
        {
            // Arrange
            _cpu.Flags.Parity = false;

            _memory.Setup(x => x[0x00]).Returns(0xE0);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RPO(_cpu), Times.Once);

            Assert.Equal(11, _cpu.Cycles);
        }

        [Fact]
        public void POP_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xE1);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.POP_H(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void JPO_ShouldAdvanceCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xE2);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.JPO(_cpu), Times.Once);

            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void XTHL_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xE3);

            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.XTHL(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(18, _cpu.Cycles);
        }

        [Fact]
        public void CPO_ShouldAdvancePCAndCyclesIfParityEven()
        {
            // Arrange
            _cpu.Flags.Parity = true;

            _memory.Setup(x => x[0x00]).Returns(0xE4);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CPO(_cpu), Times.Once);

            Assert.Equal(3, _cpu.Registers.PC);
            Assert.Equal(11, _cpu.Cycles);
        }

        [Fact]
        public void CPO_ShouldAddCyclesIfParityOdd()
        {
            // Arrange
            _cpu.Flags.Parity = false;

            _memory.Setup(x => x[0x00]).Returns(0xE4);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CPO(_cpu), Times.Once);

            Assert.Equal(17, _cpu.Cycles);
        }

        [Fact]
        public void PUSH_H_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xE5);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.PUSH_H(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(11, _cpu.Cycles);
        }

        [Fact]
        public void ANI_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xE6);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ANI(_cpu), Times.Once);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void RST_4_ShouldAdvanceCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xE7);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RST_4(_cpu), Times.Once);

            Assert.Equal(11, _cpu.Cycles);
        }

        [Fact]
        public void RPE_ShouldAdvancePCAndCyclesIfParityOdd()
        {
            // Arrange
            _cpu.Flags.Parity = false;

            _memory.Setup(x => x[0x00]).Returns(0xE8);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RPE(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void RPE_ShouldAddCyclesIfParityEven()
        {
            // Arrange
            _cpu.Flags.Parity = true;

            _memory.Setup(x => x[0x00]).Returns(0xE8);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RPE(_cpu), Times.Once);

            Assert.Equal(11, _cpu.Cycles);
        }

        [Fact]
        public void PCHL_ShouldAdvanceCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xE9);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.PCHL(_cpu), Times.Once);

            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void JPE_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xEA);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.JPE(_cpu), Times.Once);

            Assert.Equal(3, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void XCHG_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xEB);
         
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.XCHG(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void CPE_ShouldAddCyclesIfParityEven()
        {
            // Arrange
            _cpu.Flags.Parity = true;

            _memory.Setup(x => x[0x00]).Returns(0xEC);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CPE(_cpu), Times.Once);

            Assert.Equal(17, _cpu.Cycles);
        }

        [Fact]
        public void XRI_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xEE);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.XRI(_cpu), Times.Once);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void RST_5_ShouldAdvanceCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xEF);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RST_5(_cpu), Times.Once);

            Assert.Equal(11, _cpu.Cycles);
        }

        [Fact]
        public void RP_ShouldAdvancePCAndCyclesIfSignFlagSet()
        {
            // Arrange
            _cpu.Flags.Sign = true;

            _memory.Setup(x => x[0x00]).Returns(0xF0);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RP(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void RP_ShouldAddCyclesIfSignFlagReset()
        {
            // Arrange
            _cpu.Flags.Sign = false;

            _memory.Setup(x => x[0x00]).Returns(0xF0);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RP(_cpu), Times.Once);

            Assert.Equal(11, _cpu.Cycles);
        }

        [Fact]
        public void POP_PSW_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xF1);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.POP_PSW(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void JP_ShouldAdvanceCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xF2);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.JP(_cpu), Times.Once);

            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void DI_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xF3);

            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.DI(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void CP_ShouldAdvancePCAndCyclesIfSignFlagSet()
        {
            // Arrange
            _cpu.Flags.Sign = true;

            _memory.Setup(x => x[0x00]).Returns(0xF4);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CP(_cpu), Times.Once);

            Assert.Equal(3, _cpu.Registers.PC);
            Assert.Equal(11, _cpu.Cycles);
        }

        [Fact]
        public void CP_ShouldAddCyclesIfSignFlagReset()
        {
            // Arrange
            _cpu.Flags.Sign = false;

            _memory.Setup(x => x[0x00]).Returns(0xF4);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CP(_cpu), Times.Once);

            Assert.Equal(17, _cpu.Cycles);
        }

        [Fact]
        public void PUSH_PSW_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xF5);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.PUSH_PSW(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(11, _cpu.Cycles);
        }

        [Fact]
        public void ORI_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xF6);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.ORI(_cpu), Times.Once);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void RST_6_ShouldAdvanceCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xF7);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RST_6(_cpu), Times.Once);

            Assert.Equal(11, _cpu.Cycles);
        }

        [Fact]
        public void RM_ShouldAdvancePCAndCyclesIfSignFlagReset()
        {
            // Arrange
            _cpu.Flags.Sign = false;

            _memory.Setup(x => x[0x00]).Returns(0xF8);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RM(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void RP_ShouldAddCyclesIfSignFlagSet()
        {
            // Arrange
            _cpu.Flags.Sign = true;

            _memory.Setup(x => x[0x00]).Returns(0xF8);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RM(_cpu), Times.Once);

            Assert.Equal(11, _cpu.Cycles);
        }

        [Fact]
        public void SPHL_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xF9);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.SPHL(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(5, _cpu.Cycles);
        }

        [Fact]
        public void JM_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xFA);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.JM(_cpu), Times.Once);

            Assert.Equal(3, _cpu.Registers.PC);
            Assert.Equal(10, _cpu.Cycles);
        }

        [Fact]
        public void EI_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xFB);
         
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.EI(_cpu), Times.Once);

            Assert.Equal(1, _cpu.Registers.PC);
            Assert.Equal(4, _cpu.Cycles);
        }

        [Fact]
        public void CM_ShouldAddCyclesIfSignFlagSet()
        {
            // Arrange
            _cpu.Flags.Sign = true;

            _memory.Setup(x => x[0x00]).Returns(0xFC);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CM(_cpu), Times.Once);

            Assert.Equal(17, _cpu.Cycles);
        }

        [Fact]
        public void CPI_ShouldAdvancePCAndCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xFE);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.CPI(_cpu), Times.Once);

            Assert.Equal(2, _cpu.Registers.PC);
            Assert.Equal(7, _cpu.Cycles);
        }

        [Fact]
        public void RST_7_ShouldAdvanceCycles()
        {
            // Arrange
            _memory.Setup(x => x[0x00]).Returns(0xFF);
            
            // Act
            _cpu.Step();

            // Assert
            _instructionSet.Verify(x => x.RST_7(_cpu), Times.Once);

            Assert.Equal(11, _cpu.Cycles);
        }
    }
}