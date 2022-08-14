using System;

namespace Intel8080.Emulator
{
    public class DefaultInstructionSet : IInstructionSet
    {

        private Action<CPU>[] _actions = new Action<CPU>[0x100];

        public Action<CPU> this[int index]
        {
            get => _actions[index];
        }

        public DefaultInstructionSet()
        {
            _actions = new Action<CPU>[0xFF];

            // 0x0X
            _actions[0x00] = NOP;
            _actions[0x01] = LXI_B;
            _actions[0x02] = STAX_B;
            _actions[0x03] = INX_B;
            _actions[0x04] = INR_B;
            _actions[0x05] = DCR_B;
            _actions[0x06] = MVI_B;
            _actions[0x07] = RLC;
            _actions[0x08] = NOP;
            _actions[0x09] = DAD_B;
            _actions[0x0A] = LDAX_B;
            _actions[0x0B] = DCX_B;
            _actions[0x0C] = INR_C;
            _actions[0x0D] = DCR_C;
            _actions[0x0E] = MVI_C;
            _actions[0x0F] = RRC;

            // 0x1X
            _actions[0x10] = NOP;
            _actions[0x11] = LXI_D;
            _actions[0x12] = STAX_D;
            _actions[0x13] = INX_D;
            _actions[0x14] = INR_D;
            _actions[0x15] = DCR_D;
            _actions[0x16] = MVI_D;
            _actions[0x17] = RAL;
            _actions[0x18] = NOP;
            _actions[0x19] = DAD_D;
            _actions[0x1A] = LDAX_D;
            _actions[0x1B] = DCX_D;
            _actions[0x1C] = INR_E;
            _actions[0x1D] = DCR_E;
            _actions[0x1E] = MVI_E;
            _actions[0x1F] = RAR;

            // 0x2X
            _actions[0x20] = NOP;
            _actions[0x21] = LXI_H;
            _actions[0x22] = SHLD;
            _actions[0x23] = INX_H;
            _actions[0x24] = INR_H;
            _actions[0x25] = DCR_H;
            _actions[0x26] = MVI_H;
            _actions[0x27] = DAA;
            _actions[0x28] = NOP;
            _actions[0x29] = DAD_H;
            _actions[0x2A] = LHLD;
            _actions[0x2B] = DCX_H;
            _actions[0x2C] = INR_L;
            _actions[0x2D] = DCR_L;
            _actions[0x2E] = MVI_L;
            _actions[0x2F] = CMA;

            // 0x3X
            _actions[0x30] = NOP;
            _actions[0x31] = LXI_SP;
            _actions[0x32] = STA;
            _actions[0x33] = INX_SP;
            _actions[0x34] = INR_M;
            _actions[0x35] = DCR_M;
            _actions[0x36] = MVI_M;
            _actions[0x37] = STC;
            _actions[0x38] = NOP;
            _actions[0x39] = DAD_SP;
            _actions[0x3A] = LDA;
            _actions[0x3B] = DCX_SP;
            _actions[0x3C] = INR_A;
            _actions[0x3D] = DCR_A;
            _actions[0x3E] = MVI_A;
            _actions[0x3F] = CMC;
        }

        private void INX(CPU cpu, ref ushort reg)
        {
            reg += 1;
        }

        private void DCX(CPU cpu, ref ushort reg)
        {
            reg -= 1;
        }

        private void INR(CPU cpu, ref byte reg)
        {
            cpu.Flags.CalcAuxCarryFlag(reg, 1);

            reg += 1;

            cpu.Flags.CalcSignFlag(reg);
            cpu.Flags.CalcZeroFlag(reg);
            cpu.Flags.CalcParityFlag(reg);
        }

        private void DCR(CPU cpu, ref byte reg)
        {
            cpu.Flags.CalcAuxCarryFlagSub(reg, 1);

            reg -= 1;

            cpu.Flags.CalcSignFlag(reg);
            cpu.Flags.CalcZeroFlag(reg);
            cpu.Flags.CalcParityFlag(reg);
        }

        private void STAX(CPU cpu, ushort reg)
        {
            cpu.Memory[reg] = cpu.Registers.A;
        }

        private void LDAX(CPU cpu, ushort reg)
        {
            cpu.Registers.A = cpu.Memory[reg];
        }

        private void LXI(CPU cpu, ref ushort reg)
        {
            ushort data = GetUshort(
                cpu.Memory[cpu.Registers.PC + 2],
                cpu.Memory[cpu.Registers.PC + 1]
            );

            reg = data;
        }

        private void MVI(CPU cpu, ref byte reg)
        {
            reg = cpu.Memory[cpu.Registers.PC + 1];
        }

        private void DAD(CPU cpu, ref ushort reg)
        {
            int result = cpu.Registers.HL + reg;

            cpu.Registers.HL = (ushort) (result & 0xFFFFFFFF);

            cpu.Flags.CalcCarryFlagRegisterPair(result);
        }

        private ushort GetUshort(byte a, byte b)
        {
            return (ushort) ((a << 8) | b);
        }

        // 0x00   - NOP
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None
        public virtual void NOP(CPU cpu)
        {
            return;
        }

        // 0x01   - LXI, B,d16
        // Bytes  - 3
        // Cycles - 10
        // Flags  - None
        public virtual void LXI_B(CPU cpu)
        {
            LXI(cpu, ref cpu.Registers.BC);
        }

        // 0x02   - STAX B
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public virtual void STAX_B(CPU cpu)
        {
            STAX(cpu, cpu.Registers.BC);
        }

        // 0x03   - INX B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void INX_B(CPU cpu)
        {
            INX(cpu, ref cpu.Registers.BC);
        }

        // 0x04   - INR B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public virtual void INR_B(CPU cpu)
        {
            INR(cpu, ref cpu.Registers.B);
        }

        // 0x05   - DCR B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public virtual void DCR_B(CPU cpu)
        {
            DCR(cpu, ref cpu.Registers.B);
        }

        // 0x06   - MVI B,d8
        // Bytes  - 2
        // Cycles - 7
        // Flags  - None
        public virtual void MVI_B(CPU cpu)
        {
            MVI(cpu, ref cpu.Registers.B);
        }

        // 0x07   - RLC
        // Bytes  - 1
        // Cycles - 4
        // Flags  - C
        public virtual void RLC(CPU cpu)
        {
            cpu.Flags.Carry = ((cpu.Registers.A & 0x80) >> 7) == 1;
            cpu.Registers.A = (byte) (((cpu.Registers.A & 0x80) >> 7) | (cpu.Registers.A << 1));
        }

        // 0x08   - *NOP
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None
        
        // 0x09   - DAD B
        // Bytes  - 1
        // Cycles - 10
        // Flags  - C
        public virtual void DAD_B(CPU cpu)
        {
            DAD(cpu, ref cpu.Registers.BC);
        }

        // 0x0A   - LDAX B
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public virtual void LDAX_B(CPU cpu)
        {
            LDAX(cpu, cpu.Registers.BC);
        }

        // 0x0B   - DCX B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void DCX_B(CPU cpu)
        {
            DCX(cpu, ref cpu.Registers.BC);
        }

        // 0x0C   - INR C
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        
        public virtual void INR_C(CPU cpu)
        {
            INR(cpu, ref cpu.Registers.C);
        }

        // 0x0D   - DCR C
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public virtual void DCR_C(CPU cpu)
        {
            DCR(cpu, ref cpu.Registers.C);
        }

        // 0x0E   - MVI C, d8
        // Bytes  - 2
        // Cycles - 7
        // Flags  - None
        public virtual void MVI_C(CPU cpu)
        {
            MVI(cpu, ref cpu.Registers.C);
        }

        // 0x0F   - RRC
        // Bytes  - 1
        // Cycles - 4
        // Flags  - C
        public virtual void RRC(CPU cpu)
        {
            cpu.Flags.Carry = (cpu.Registers.A & 0x01) == 1;
            cpu.Registers.A = (byte) (((cpu.Registers.A & 0x01) << 7) | (cpu.Registers.A >> 1));
        }

        // 0x10   - *NOP
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None

        // 0x11   - LXI D, d16
        // Bytes  - 3
        // Cycles - 10
        // Flags  - None
        public virtual void LXI_D(CPU cpu)
        {
            LXI(cpu, ref cpu.Registers.DE);
        }

        // 0x12   - STAX D
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public virtual void STAX_D(CPU cpu)
        {
            STAX(cpu, cpu.Registers.DE);
        }

        // 0x13   - INX D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void INX_D(CPU cpu)
        {
            INX(cpu, ref cpu.Registers.DE);
        }

        // 0x14   - INR D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public virtual void INR_D(CPU cpu)
        {
            INR(cpu, ref cpu.Registers.D);
        }

        // 0x15   - DCR D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public virtual void DCR_D(CPU cpu)
        {
            DCR(cpu, ref cpu.Registers.D);
        }

        // 0x16   - MVI D, d8
        // Bytes  - 2
        // Cycles - 7
        // Flags  - None
        public virtual void MVI_D(CPU cpu)
        {
            MVI(cpu, ref cpu.Registers.D);
        }

        // 0x17   - RAL
        // Bytes  - 1
        // Cycles - 4
        // Flags  - C
        public virtual void RAL(CPU cpu)
        {
            bool carry = cpu.Flags.Carry;

            cpu.Flags.Carry = ((cpu.Registers.A & 0x80) >> 7) == 1;

            cpu.Registers.A <<= 1;

            if (carry) cpu.Registers.A |= 1;
        }

        // 0x18   - *NOP
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None

        // 0x19   - DAD D
        // Bytes  - 1
        // Cycles - 10
        // Flags  - C
        public virtual void DAD_D(CPU cpu)
        {
            DAD(cpu, ref cpu.Registers.DE);
        }

        // 0x1A   - LDAX D
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public virtual void LDAX_D(CPU cpu)
        {
            LDAX(cpu, cpu.Registers.DE);
        }
        
        // 0x1B   - DCX D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void DCX_D(CPU cpu)
        {
            DCX(cpu, ref cpu.Registers.DE);
        }

        // 0x1C   - INR E
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void INR_E(CPU cpu)
        {
            INR(cpu, ref cpu.Registers.E);
        }

        // 0x1D   - DCR E
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void DCR_E(CPU cpu)
        {
            DCR(cpu, ref cpu.Registers.E);
        }

        // 0x1E   - MVI E, d8
        // Bytes  - 2
        // Cycles - 7
        // Flags  - None
        public virtual void MVI_E(CPU cpu)
        {
            MVI(cpu, ref cpu.Registers.E);
        }

        // 0x1F   - RAR
        // Bytes  - 1
        // Cycles - 4
        // Flags  - C
        public virtual void RAR(CPU cpu)
        {
            bool carry = cpu.Flags.Carry;

            cpu.Flags.Carry = (cpu.Registers.A & 0x01) == 1;

            cpu.Registers.A >>= 1;

            if (carry) cpu.Registers.A |= 0x80;
        }

        // 0x20   - *NOP
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None

        // 0x21   - LXI H, d16
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None
        public virtual void LXI_H(CPU cpu)
        {
            LXI(cpu, ref cpu.Registers.HL);
        }

        // 0x22   - SHLD a16
        // Bytes  - 3
        // Cycles - 16
        // Flags  - None
        public virtual void SHLD(CPU cpu)
        {
            var location = GetUshort(
                cpu.Memory[cpu.Registers.PC + 2],
                cpu.Memory[cpu.Registers.PC + 1]
            );

            cpu.Memory[location] = cpu.Registers.L;
            cpu.Memory[location + 1] = cpu.Registers.H;
        }

        // 0x23   - INX H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void INX_H(CPU cpu)
        {
            INX(cpu, ref cpu.Registers.HL);
        }

        // 0x24   - INR H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public virtual void INR_H(CPU cpu)
        {
            INR(cpu, ref cpu.Registers.H);
        }

        // 0x25   - DCR H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public virtual void DCR_H(CPU cpu)
        {
            DCR(cpu, ref cpu.Registers.H);
        }

        // 0x26   - MVI H, d8
        // Bytes  - 2
        // Cycles - 7
        // Flags  - None
        public virtual void MVI_H(CPU cpu)
        {
            MVI(cpu, ref cpu.Registers.H);
        }

        // 0x27   - DAA
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S Z A P C
        public virtual void DAA(CPU cpu)
        {
            byte low = (byte) (cpu.Registers.A & 0x0F);

            if (low > 0x09 | cpu.Flags.AuxiliaryCarry)
            {
                cpu.Flags.CalcAuxCarryFlag(low, 6);

                cpu.Registers.A += 6;
            }

            byte high = (byte)((cpu.Registers.A & 0xF0) >> 4);

            if (high > 0x09 | cpu.Flags.AuxiliaryCarry)
            {
                ushort result = (ushort) ((high + 6) << 4);

                cpu.Flags.CalcCarryFlag(result);

                cpu.Registers.A &= 0x0F;
                cpu.Registers.A |= (byte) (result & 0xF0);
            }

            cpu.Flags.CalcSignFlag(cpu.Registers.A);
            cpu.Flags.CalcZeroFlag(cpu.Registers.A);
            cpu.Flags.CalcParityFlag(cpu.Registers.A);
        }

        // 0x28   - *NOP
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None

        // 0x29   - DAD H
        // Bytes  - 1
        // Cycles - 10
        // Flags  - C
        public virtual void DAD_H(CPU cpu)
        {
            DAD(cpu, ref cpu.Registers.HL);
        }

        // 0x2A   - LHLD a16
        // Bytes  - 3
        // Cycles - 16
        // Flags  - None
        public virtual void LHLD(CPU cpu)
        {
            var location = GetUshort(
                cpu.Memory[cpu.Registers.PC + 2],
                cpu.Memory[cpu.Registers.PC + 1]
            );

            cpu.Registers.L = cpu.Memory[location];
            cpu.Registers.H = cpu.Memory[location + 1];
        }

        // 0x2B   - DCX H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void DCX_H(CPU cpu)
        {
            DCX(cpu, ref cpu.Registers.HL);
        }

        // 0x2C  - INR L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public virtual void INR_L(CPU cpu)
        {
            INR(cpu, ref cpu.Registers.L);
        }

        // 0x2D  - DCR L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public virtual void DCR_L(CPU cpu)
        {
            DCR(cpu, ref cpu.Registers.L);
        }

        // 0x2E   - MVI L, d8
        // Bytes  - 2
        // Cycles - 7
        // Flags  - None
        public virtual void MVI_L(CPU cpu)
        {
            MVI(cpu, ref cpu.Registers.L);
        }

        // 0x2F   - CMA
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None
        public virtual void CMA(CPU cpu)
        {
            cpu.Registers.A = (byte) ~cpu.Registers.A;
        }

        // 0x30   - *NOP
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None

        // 0x31   - LXI SP, d16
        // Bytes  - 3
        // Cycles - 10
        // Flags  - None
        public virtual void LXI_SP(CPU cpu)
        {
            LXI(cpu, ref cpu.Registers.SP);
        }

        // 0x32   - STA a16
        // Bytes  - 3
        // Cycles - 13
        // Flags  - None
        public virtual void STA(CPU cpu)
        {
            var location = GetUshort(
                cpu.Memory[cpu.Registers.PC + 2],
                cpu.Memory[cpu.Registers.PC + 1]
            );

            cpu.Memory[location] = cpu.Registers.A;
        }

        // 0x33   - INX SP
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void INX_SP(CPU cpu)
        {
            INX(cpu, ref cpu.Registers.SP);
        }

        // 0x34   - INR M
        // Bytes  - 1
        // Cycles - 10
        // Flags  - S, Z, A, P
        public virtual void INR_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Flags.CalcAuxCarryFlag(cpu.Memory[location], 1);

            cpu.Memory[location] += 1;

            cpu.Flags.CalcSignFlag(cpu.Memory[location]);
            cpu.Flags.CalcZeroFlag(cpu.Memory[location]);
            cpu.Flags.CalcParityFlag(cpu.Memory[location]);
        }

        // 0x35   - DCR M
        // Bytes  - 1
        // Cycles - 10
        // Flags  - S, Z, A, P
        public virtual void DCR_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Flags.CalcAuxCarryFlagSub(cpu.Memory[location], 1);

            cpu.Memory[location] -= 1;

            cpu.Flags.CalcSignFlag(cpu.Memory[location]);
            cpu.Flags.CalcZeroFlag(cpu.Memory[location]);
            cpu.Flags.CalcParityFlag(cpu.Memory[location]);
        }

        // 0x36   - MVI M
        // Bytes  - 2
        // Cycles - 10
        // Flags  - None
        public virtual void MVI_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Memory[location] = cpu.Memory[cpu.Registers.PC + 1];
        }

        // 0x37   - STC
        // Bytes  - 1
        // Cycles - 4
        // Flags  - C
        public virtual void STC(CPU cpu)
        {
            cpu.Flags.Carry = true;
        }

        // 0x38   - *NOP
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None

        // 0x39   - DAD SP
        // Bytes  - 1
        // Cycles - 10
        // Flags  - C
        public virtual void DAD_SP(CPU cpu)
        {
            DAD(cpu, ref cpu.Registers.SP);
        }

        // 0x3A   - LDA a16
        // Bytes  - 3
        // Cycles - 13
        // Flags  - C
        public virtual void LDA(CPU cpu)
        {
            var location = GetUshort(
                cpu.Memory[cpu.Registers.PC + 2],
                cpu.Memory[cpu.Registers.PC + 1]
            );

            cpu.Registers.A = cpu.Memory[location];
        }

        // 0x3B   - DCX SP
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void DCX_SP(CPU cpu)
        {
            DCX(cpu, ref cpu.Registers.SP);
        }

        // 0x3C   - INR A
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public virtual void INR_A(CPU cpu)
        {
            INR(cpu, ref cpu.Registers.A);
        }

        // 0x3D   - DCR A
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public virtual void DCR_A(CPU cpu)
        {
            DCR(cpu, ref cpu.Registers.A);
        }

        // 0x3E   - MVI A, d8
        // Bytes  - 2
        // Cycles - 7
        // Flags  - None
        public virtual void MVI_A(CPU cpu)
        {
            MVI(cpu, ref cpu.Registers.A);
        }

        // 0x3F   - CMC
        // Bytes  - 1
        // Cycles - 4
        // Flags  - C
        public virtual void CMC(CPU cpu)
        {
            cpu.Flags.Carry = !cpu.Flags.Carry;
        }
    }
}