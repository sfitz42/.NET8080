using System.Collections.Generic;
using Intel8080.Emulator;
using Xunit;

namespace Intel8080.Tests
{
    public class RegisterTests
    {
        private Registers _registers;

        public static IEnumerable<object[]> SingleRegisterTestData => new List<object[]>
        {
            new object[] { 0xFF00, 0xFF, 0x00 },
            new object[] { 0x4200, 0x42, 0x00 },
            new object[] { 0x00FF, 0x00, 0xFF },
            new object[] { 0x0042, 0x00, 0x42 },
            new object[] { 0x12FF, 0x12, 0xFF },
            new object[] { 0xFFFF, 0xFF, 0xFF },
            new object[] { 0x0000, 0x00, 0x00}
        };

        public static IEnumerable<object[]> RegisterPairTestData => new List<object[]>
        {
            new object[] { 0xFFFF, 0xFF, 0xFF },
            new object[] { 0x4200, 0x42, 0x00 },
            new object[] { 0x0042, 0x00, 0x42 }
        };

        public RegisterTests()
        {
            _registers = new Registers();
        }

        [Fact]
        public void Store_Accumulator()
        {
            // Act
            _registers.A = 0xFF;

            // Assert
            Assert.Equal(0xFF, _registers.A);
        }

        [Fact]
        public void Store_ProgramCounter()
        {
            // Act
            _registers.PC = 0xFFFF;

            // Assert
            Assert.Equal(0xFFFF, _registers.PC);
        }

        [Fact]
        public void Store_StackPointer()
        {
            // Act
            _registers.SP = 0xFFFF;

            // Assert
            Assert.Equal(0xFFFF, _registers.SP);
        }

        [Theory]
        [MemberData(nameof(SingleRegisterTestData))]
        public void Store_BC_SingleRegister(ushort BC, byte B, byte C)
        {
            // Act
            _registers.B = B;
            _registers.C = C;

            // Assert
            Assert.Equal(BC, _registers.BC);
            Assert.Equal(B, _registers.B);
            Assert.Equal(C, _registers.C);
        }

        [Theory]
        [MemberData(nameof(RegisterPairTestData))]
        public void Store_BC_RegisterPair(ushort BC, byte B, byte C)
        {
            // Act
            _registers.BC = BC;

            // Assert
            Assert.Equal(BC, _registers.BC);
            Assert.Equal(B, _registers.B);
            Assert.Equal(C, _registers.C);
        }

        [Theory]
        [MemberData(nameof(SingleRegisterTestData))]
        public void Store_DE_SingleRegister(ushort DE, byte D, byte E)
        {
            // Act
            _registers.D = D;
            _registers.E = E;

            // Assert
            Assert.Equal(DE, _registers.DE);
            Assert.Equal(D, _registers.D);
            Assert.Equal(E, _registers.E);
        }

        [Theory]
        [MemberData(nameof(RegisterPairTestData))]
        public void Store_DE_RegisterPair(ushort DE, byte D, byte E)
        {
            // Act
            _registers.DE = DE;

            // Assert
            Assert.Equal(DE, _registers.DE);
            Assert.Equal(D, _registers.D);
            Assert.Equal(E, _registers.E);
        }

        [Theory]
        [MemberData(nameof(SingleRegisterTestData))]
        public void Store_HL_SingleRegister(ushort HL, byte H, byte L)
        {
            // Act
            _registers.H = H;
            _registers.L = L;

            // Assert
            Assert.Equal(HL, _registers.HL);
            Assert.Equal(H, _registers.H);
            Assert.Equal(L, _registers.L);
        }

        [Theory]
        [MemberData(nameof(RegisterPairTestData))]
        public void Store_HL_RegisterPair(ushort HL, byte H, byte L)
        {
            // Act
            _registers.HL = HL;

            // Assert
            Assert.Equal(HL, _registers.HL);
            Assert.Equal(H, _registers.H);
            Assert.Equal(L, _registers.L);
        }
    }
}