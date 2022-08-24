using System.Numerics;

namespace Intel8080.Emulator
{
    public class Flags
    {
        private const byte SignMask = 0x80;
        private const byte ZeroMask = 0x40;
        private const byte AuxCarryMask = 0x10;
        private const byte ParityMask = 0x04;
        private const byte CarryMask = 0x01;

        public byte F { get; private set; } = 0x00;
        public bool Sign { get => GetFlag(SignMask); set => SetFlag(value, SignMask); }
        public bool Zero { get => GetFlag(ZeroMask); set => SetFlag(value, ZeroMask); }
        public bool AuxiliaryCarry { get => GetFlag(AuxCarryMask); set => SetFlag(value, AuxCarryMask); }
        public bool Parity { get => GetFlag(ParityMask); set => SetFlag(value, ParityMask); }
        public bool Carry { get => GetFlag(CarryMask); set => SetFlag(value, CarryMask); }

        public void CalcSignFlag(byte value)
        {
            Sign = (value >> 7) == 1;
        }

        public void CalcZeroFlag(byte value)
        {
            Zero = (value == 0);
        }

        public void CalcAuxCarryFlag(int a, int b)
        {
            int result = (a & 0xF) + (b & 0xF) & 0x10;

            AuxiliaryCarry = result != 0;
        }

        public void CalcAuxCarryFlagSub(int a, int b)
        {
            int result = (a & 0xF) - (b & 0xF) & 0x10;

            AuxiliaryCarry = result != 0;
        }

        public void CalcParityFlag(byte value)
        {
            var setBits = BitOperations.PopCount(value);

            Parity = (value == 0) || ((setBits % 2) == 0);
        }

        public void CalcCarryFlag(ushort value)
        {
            Carry = (value > 0xFF);
        }

        public void CalcCarryFlagSub(ushort value)
        {
            Carry = !(value > 0xFF);
        }

        public void CalcCarryFlagRegisterPair(int value)
        {
            Carry = (value > 0xFFFF);
        }

        public void Clear()
        {
            F = 0x00;
        }

        private bool GetFlag(byte mask)
        {
            return (F & mask) == mask;
        }

        private void SetFlag(bool value, byte mask)
        {
            F = (byte) (value ? (F | mask) : (F & ~(mask)));
        }
    }
}