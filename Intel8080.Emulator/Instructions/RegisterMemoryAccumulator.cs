using System;

namespace Intel8080.Emulator.Instructions
{
    public partial class DefaultInstructionSet : IInstructionSet
    {
        private void ADD(CPU cpu, ref byte reg)
        {
            cpu.Flags.CalcAuxCarryFlag(cpu.Registers.A, reg);

            var result = (ushort)(cpu.Registers.A + reg);

            cpu.Flags.CalcAuxCarryFlag(cpu.Registers.A, reg);
            cpu.Flags.CalcCarryFlag(result);

            var resultByte = (byte)(result & 0x00FF);

            cpu.Flags.CalcSignFlag(resultByte);
            cpu.Flags.CalcZeroFlag(resultByte);
            cpu.Flags.CalcParityFlag(resultByte);

            cpu.Registers.A = resultByte;
        }

        private void ADC(CPU cpu, ref byte reg)
        {
            var carry = cpu.Flags.Carry ? 1 : 0;

            var result = (ushort)(cpu.Registers.A + reg + carry);

            cpu.Flags.CalcAuxCarryFlag(cpu.Registers.A, reg, carry);
            cpu.Flags.CalcCarryFlag(result);

            var resultByte = (byte)(result & 0x00FF);

            cpu.Flags.CalcSignFlag(resultByte);
            cpu.Flags.CalcZeroFlag(resultByte);
            cpu.Flags.CalcParityFlag(resultByte);

            cpu.Registers.A = resultByte;
        }

        private void SUB(CPU cpu, ref byte reg)
        {
            var data = (byte)~reg;

            var borrow = 1;

            var result = (ushort)(cpu.Registers.A + data + borrow);

            cpu.Flags.CalcAuxCarryFlag(cpu.Registers.A, data, borrow);
            cpu.Flags.CalcCarryFlag(result);

            var resultByte = (byte)(result & 0x00FF);

            cpu.Flags.CalcSignFlag(resultByte);
            cpu.Flags.CalcZeroFlag(resultByte);
            cpu.Flags.CalcParityFlag(resultByte);

            cpu.Registers.A = resultByte;

            cpu.Flags.Carry = !cpu.Flags.Carry;
        }

        private void SBB(CPU cpu, ref byte reg)
        {
            var data = (byte)~reg;

            var borrow = !cpu.Flags.Carry ? 1 : 0;

            var result = (ushort)(cpu.Registers.A + data + borrow);

            cpu.Flags.CalcAuxCarryFlag(cpu.Registers.A, data, borrow);
            cpu.Flags.CalcCarryFlag(result);

            var resultByte = (byte)(result & 0x00FF);

            cpu.Flags.CalcSignFlag(resultByte);
            cpu.Flags.CalcZeroFlag(resultByte);
            cpu.Flags.CalcParityFlag(resultByte);

            cpu.Registers.A = resultByte;

            cpu.Flags.Carry = !cpu.Flags.Carry;
        }

        private void ANA(CPU cpu, ref byte reg)
        {
            cpu.Flags.AuxiliaryCarry = ((cpu.Registers.A & 0x08) | (reg & 0x08)) != 0;

            cpu.Registers.A &= reg;

            cpu.Flags.CalcSignFlag(cpu.Registers.A);
            cpu.Flags.CalcZeroFlag(cpu.Registers.A);
            cpu.Flags.CalcParityFlag(cpu.Registers.A);
            cpu.Flags.Carry = false;
        }

        private void XRA(CPU cpu, ref byte reg)
        {
            cpu.Registers.A ^= reg;

            cpu.Flags.CalcSignFlag(cpu.Registers.A);
            cpu.Flags.CalcZeroFlag(cpu.Registers.A);
            cpu.Flags.CalcParityFlag(cpu.Registers.A);
            cpu.Flags.Carry = false;
            cpu.Flags.AuxiliaryCarry = false;
        }

        private void ORA(CPU cpu, ref byte reg)
        {
            cpu.Registers.A |= reg;

            cpu.Flags.CalcSignFlag(cpu.Registers.A);
            cpu.Flags.CalcZeroFlag(cpu.Registers.A);
            cpu.Flags.CalcParityFlag(cpu.Registers.A);
            cpu.Flags.Carry = false;
            cpu.Flags.AuxiliaryCarry = false;
        }

        private void CMP(CPU cpu, ref byte reg)
        {
            var data = (byte)~reg;

            var result = (ushort)(cpu.Registers.A + data + 1);

            cpu.Flags.CalcAuxCarryFlag(cpu.Registers.A, data, 1);
            cpu.Flags.CalcCarryFlag(result);

            var resultByte = (byte)(result & 0x00FF);

            cpu.Flags.CalcSignFlag(resultByte);
            cpu.Flags.CalcZeroFlag(resultByte);
            cpu.Flags.CalcParityFlag(resultByte);

            cpu.Flags.Carry = !cpu.Flags.Carry;
        }

        // 0x80   - ADD B
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void ADD_B(CPU cpu)
        {
            ADD(cpu, ref cpu.Registers.B);
        }

        // 0x81   - ADD C
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void ADD_C(CPU cpu)
        {
            ADD(cpu, ref cpu.Registers.C);
        }

        // 0x82   - ADD D
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void ADD_D(CPU cpu)
        {
            ADD(cpu, ref cpu.Registers.D);
        }

        // 0x83   - ADD E
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void ADD_E(CPU cpu)
        {
            ADD(cpu, ref cpu.Registers.E);
        }

        // 0x84   - ADD H
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void ADD_H(CPU cpu)
        {
            ADD(cpu, ref cpu.Registers.H);
        }

        // 0x85   - ADD L
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void ADD_L(CPU cpu)
        {
            ADD(cpu, ref cpu.Registers.L);
        }

        // 0x86   - ADD M
        // Bytes  - 1
        // Cycles - 7
        // Flags  - S, Z, A, P, C
        public virtual void ADD_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            byte val = cpu.Memory[location];

            ADD(cpu, ref val);
        }

        // 0x87   - ADD A
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void ADD_A(CPU cpu)
        {
            ADD(cpu, ref cpu.Registers.A);
        }

        // 0x88   - ADC B
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void ADC_B(CPU cpu)
        {
            ADC(cpu, ref cpu.Registers.B);
        }

        // 0x89   - ADC C
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void ADC_C(CPU cpu)
        {
            ADC(cpu, ref cpu.Registers.C);
        }

        // 0x8A   - ADC D
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void ADC_D(CPU cpu)
        {
            ADC(cpu, ref cpu.Registers.D);
        }

        // 0x8B   - ADC E
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void ADC_E(CPU cpu)
        {
            ADC(cpu, ref cpu.Registers.E);
        }

        // 0x8C   - ADC H
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void ADC_H(CPU cpu)
        {
            ADC(cpu, ref cpu.Registers.H);
        }

        // 0x8D   - ADC L
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void ADC_L(CPU cpu)
        {
            ADC(cpu, ref cpu.Registers.L);
        }

        // 0x8E   - ADD M
        // Bytes  - 1
        // Cycles - 7
        // Flags  - S, Z, A, P, C
        public virtual void ADC_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            byte val = cpu.Memory[location];

            ADC(cpu, ref val);
        }

        // 0x8F   - ADC A
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void ADC_A(CPU cpu)
        {
            ADC(cpu, ref cpu.Registers.A);
        }

        // 0x90   - SUB B
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void SUB_B(CPU cpu)
        {
            SUB(cpu, ref cpu.Registers.B);
        }

        // 0x91   - SUB C
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void SUB_C(CPU cpu)
        {
            SUB(cpu, ref cpu.Registers.C);
        }

        // 0x92   - SUB D
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void SUB_D(CPU cpu)
        {
            SUB(cpu, ref cpu.Registers.D);
        }

        // 0x93   - SUB E
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void SUB_E(CPU cpu)
        {
            SUB(cpu, ref cpu.Registers.E);
        }

        // 0x94   - SUB H
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void SUB_H(CPU cpu)
        {
            SUB(cpu, ref cpu.Registers.H);
        }

        // 0x95   - SUB L
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void SUB_L(CPU cpu)
        {
            SUB(cpu, ref cpu.Registers.L);
        }

        // 0x96   - SUB M
        // Bytes  - 1
        // Cycles - 7
        // Flags  - S, Z, A, P, C
        public virtual void SUB_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            var val = cpu.Memory[location];

            SUB(cpu, ref val);
        }

        // 0x97   - SUB A
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void SUB_A(CPU cpu)
        {
            SUB(cpu, ref cpu.Registers.A);
        }

        // 0x98   - SBB B
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void SBB_B(CPU cpu)
        {
            SBB(cpu, ref cpu.Registers.B);
        }

        // 0x99   - SBB C
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void SBB_C(CPU cpu)
        {
            SBB(cpu, ref cpu.Registers.C);
        }

        // 0x9A   - SBB D
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void SBB_D(CPU cpu)
        {
            SBB(cpu, ref cpu.Registers.D);
        }

        // 0x9B   - SBB E
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void SBB_E(CPU cpu)
        {
            SBB(cpu, ref cpu.Registers.E);
        }

        // 0x9C   - SBB H
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void SBB_H(CPU cpu)
        {
            SBB(cpu, ref cpu.Registers.H);
        }

        // 0x9D   - SBB L
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void SBB_L(CPU cpu)
        {
            SBB(cpu, ref cpu.Registers.L);
        }

        // 0x9E   - SBB M
        // Bytes  - 1
        // Cycles - 7
        // Flags  - S, Z, A, P, C
        public virtual void SBB_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            var val = cpu.Memory[location];

            SBB(cpu, ref val);
        }

        // 0x9D   - SBB A
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void SBB_A(CPU cpu)
        {
            SBB(cpu, ref cpu.Registers.A);
        }

        // 0xA0   - ANA B
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void ANA_B(CPU cpu)
        {
            ANA(cpu, ref cpu.Registers.B);
        }

        // 0xA1   - ANA C
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void ANA_C(CPU cpu)
        {
            ANA(cpu, ref cpu.Registers.C);
        }

        // 0xA2   - ANA D
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void ANA_D(CPU cpu)
        {
            ANA(cpu, ref cpu.Registers.D);
        }

        // 0xA3   - ANA E
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void ANA_E(CPU cpu)
        {
            ANA(cpu, ref cpu.Registers.E);
        }

        // 0xA4   - ANA H
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void ANA_H(CPU cpu)
        {
            ANA(cpu, ref cpu.Registers.H);
        }

        // 0xA5   - ANA L
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void ANA_L(CPU cpu)
        {
            ANA(cpu, ref cpu.Registers.L);
        }

        // 0xA6   - ANA M
        // Bytes  - 1
        // Cycles - 7
        // Flags  - S, Z, A, P, C
        public virtual void ANA_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);
            var val = cpu.Memory[location];

            ANA(cpu, ref val);
        }

        // 0xA7   - ANA A
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void ANA_A(CPU cpu)
        {
            ANA(cpu, ref cpu.Registers.A);
        }

        public virtual void XRA_B(CPU cpu)
        {
            XRA(cpu, ref cpu.Registers.B);
        }

        public virtual void XRA_C(CPU cpu)
        {
            XRA(cpu, ref cpu.Registers.C);
        }

        public virtual void XRA_D(CPU cpu)
        {
            XRA(cpu, ref cpu.Registers.D);
        }

        public virtual void XRA_E(CPU cpu)
        {
            XRA(cpu, ref cpu.Registers.E);
        }

        public virtual void XRA_H(CPU cpu)
        {
            XRA(cpu, ref cpu.Registers.H);
        }

        public virtual void XRA_L(CPU cpu)
        {
            XRA(cpu, ref cpu.Registers.L);
        }

        public virtual void XRA_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);
            var val = cpu.Memory[location];

            XRA(cpu, ref val);
        }

        public virtual void XRA_A(CPU cpu)
        {
            XRA(cpu, ref cpu.Registers.A);
        }

        public virtual void ORA_B(CPU cpu)
        {
            ORA(cpu, ref cpu.Registers.B);
        }

        public virtual void ORA_C(CPU cpu)
        {
            ORA(cpu, ref cpu.Registers.C);
        }

        public virtual void ORA_D(CPU cpu)
        {
            ORA(cpu, ref cpu.Registers.D);
        }

        public virtual void ORA_E(CPU cpu)
        {
            ORA(cpu, ref cpu.Registers.E);
        }

        public virtual void ORA_H(CPU cpu)
        {
            ORA(cpu, ref cpu.Registers.H);
        }

        public virtual void ORA_L(CPU cpu)
        {
            ORA(cpu, ref cpu.Registers.L);
        }

        public virtual void ORA_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);
            var val = cpu.Memory[location];

            ORA(cpu, ref val);
        }

        public virtual void ORA_A(CPU cpu)
        {
            ORA(cpu, ref cpu.Registers.A);
        }

        public virtual void CMP_B(CPU cpu)
        {
            CMP(cpu, ref cpu.Registers.B);
        }

        public virtual void CMP_C(CPU cpu)
        {
            CMP(cpu, ref cpu.Registers.C);
        }

        public virtual void CMP_D(CPU cpu)
        {
            CMP(cpu, ref cpu.Registers.D);
        }

        public virtual void CMP_E(CPU cpu)
        {
            CMP(cpu, ref cpu.Registers.E);
        }

        public virtual void CMP_H(CPU cpu)
        {
            CMP(cpu, ref cpu.Registers.H);
        }

        public virtual void CMP_L(CPU cpu)
        {
            CMP(cpu, ref cpu.Registers.L);
        }

        public virtual void CMP_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);
            var val = cpu.Memory[location];

            CMP(cpu, ref val);
        }

        public virtual void CMP_A(CPU cpu)
        {
            CMP(cpu, ref cpu.Registers.A);
        }
    }
}