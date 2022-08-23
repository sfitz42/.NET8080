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

            // 0x4X
            _actions[0x40] = MOV_B_B;
            _actions[0x41] = MOV_B_C;
            _actions[0x42] = MOV_B_D;
            _actions[0x43] = MOV_B_E;
            _actions[0x44] = MOV_B_H;
            _actions[0x45] = MOV_B_L;
            _actions[0x46] = MOV_B_M;
            _actions[0x47] = MOV_B_A;
            _actions[0x48] = MOV_C_B;
            _actions[0x49] = MOV_C_C;
            _actions[0x4A] = MOV_C_D;
            _actions[0x4B] = MOV_C_E;
            _actions[0x4C] = MOV_C_H;
            _actions[0x4D] = MOV_C_L;
            _actions[0x4E] = MOV_C_M;
            _actions[0x4F] = MOV_C_A;

            // 0x5X
            _actions[0x50] = MOV_D_B;
            _actions[0x51] = MOV_D_C;
            _actions[0x52] = MOV_D_D;
            _actions[0x53] = MOV_D_E;
            _actions[0x54] = MOV_D_H;
            _actions[0x55] = MOV_D_L;
            _actions[0x56] = MOV_D_M;
            _actions[0x57] = MOV_D_A;
            _actions[0x58] = MOV_E_B;
            _actions[0x59] = MOV_E_C;
            _actions[0x5A] = MOV_E_D;
            _actions[0x5B] = MOV_E_E;
            _actions[0x5C] = MOV_E_H;
            _actions[0x5D] = MOV_E_L;
            _actions[0x5E] = MOV_E_M;
            _actions[0x5F] = MOV_E_A;

            // 0x6x
            _actions[0x60] = MOV_H_B;
            _actions[0x61] = MOV_H_C;
            _actions[0x62] = MOV_H_D;
            _actions[0x63] = MOV_H_E;
            _actions[0x64] = MOV_H_H;
            _actions[0x65] = MOV_H_L;
            _actions[0x66] = MOV_H_M;
            _actions[0x67] = MOV_H_A;
            _actions[0x68] = MOV_L_B;
            _actions[0x69] = MOV_L_C;
            _actions[0x6A] = MOV_L_D;
            _actions[0x6B] = MOV_L_E;
            _actions[0x6C] = MOV_L_H;
            _actions[0x6D] = MOV_L_L;
            _actions[0x6E] = MOV_L_M;
            _actions[0x6F] = MOV_L_A;

            // 0x7x
            _actions[0x70] = MOV_M_B;
            _actions[0x71] = MOV_M_C;
            _actions[0x72] = MOV_M_D;
            _actions[0x73] = MOV_M_E;
            _actions[0x74] = MOV_M_H;
            _actions[0x75] = MOV_M_L;
            _actions[0x76] = HLT;
            _actions[0x77] = MOV_M_A;
            _actions[0x78] = MOV_A_B;
            _actions[0x79] = MOV_A_C;
            _actions[0x7A] = MOV_A_D;
            _actions[0x7B] = MOV_A_E;
            _actions[0x7C] = MOV_A_H;
            _actions[0x7D] = MOV_A_L;
            _actions[0x7E] = MOV_A_M;
            _actions[0x7F] = MOV_A_A;

            // 0x8x
            _actions[0x80] = ADD_B;
            _actions[0x81] = ADD_C;
            _actions[0x82] = ADD_D;
            _actions[0x83] = ADD_E;
            _actions[0x84] = ADD_H;
            _actions[0x85] = ADD_L;
            _actions[0x86] = ADD_M;
            _actions[0x87] = ADD_A;
            _actions[0x88] = ADC_B;
            _actions[0x89] = ADC_C;
            _actions[0x8A] = ADC_D;
            _actions[0x8B] = ADC_E;
            _actions[0x8C] = ADC_H;
            _actions[0x8D] = ADC_L;
            _actions[0x8E] = ADC_M;
            _actions[0x8F] = ADC_A;
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

        private void MOV(ref byte targetReg, ref byte sourceReg)
        {
            targetReg = sourceReg;
        }

        private void ADD(CPU cpu, ref byte reg)
        {
            cpu.Flags.CalcAuxCarryFlag(cpu.Registers.A, reg);

            ushort result = (ushort) (cpu.Registers.A + reg);

            cpu.Registers.A = (byte) (result  & 0xFF);

            cpu.Flags.CalcSignFlag(cpu.Registers.A);
            cpu.Flags.CalcZeroFlag(cpu.Registers.A);
            cpu.Flags.CalcParityFlag(cpu.Registers.A);
            cpu.Flags.CalcCarryFlag(result);
        }

        private void ADC(CPU cpu, ref byte reg)
        {
            int carry = cpu.Flags.Carry ? 1 : 0;

            cpu.Flags.CalcAuxCarryFlag(cpu.Registers.A, reg + carry);

            ushort result = (ushort) (cpu.Registers.A + reg +carry);

            cpu.Registers.A = (byte) (result  & 0xFF);

            cpu.Flags.CalcSignFlag(cpu.Registers.A);
            cpu.Flags.CalcZeroFlag(cpu.Registers.A);
            cpu.Flags.CalcParityFlag(cpu.Registers.A);
            cpu.Flags.CalcCarryFlag(result);
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

        // 0x40   - MOV B, B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_B_B(CPU cpu)
        {
            MOV(ref cpu.Registers.B, ref cpu.Registers.B);
        }

        // 0x41   - MOV B, C
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_B_C(CPU cpu)
        {
            MOV(ref cpu.Registers.B, ref cpu.Registers.C);
        }

        // 0x42   - MOV B, D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_B_D(CPU cpu)
        {
            MOV(ref cpu.Registers.B, ref cpu.Registers.D);
        }

        // 0x43   - MOV B, E
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_B_E(CPU cpu)
        {
            MOV(ref cpu.Registers.B, ref cpu.Registers.E);
        }

        // 0x44   - MOV B, H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_B_H(CPU cpu)
        {
            MOV(ref cpu.Registers.B, ref cpu.Registers.H);
        }

        // 0x45   - MOV B, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_B_L(CPU cpu)
        {
            MOV(ref cpu.Registers.B, ref cpu.Registers.L);
        }

        // 0x46   - MOV B, M
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public virtual void MOV_B_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Registers.B = cpu.Memory[location];
        }

        // 0x47   - MOV B, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_B_A(CPU cpu)
        {
            MOV(ref cpu.Registers.B, ref cpu.Registers.A);
        }
        
        // 0x48   - MOV C, B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_C_B(CPU cpu)
        {
            MOV(ref cpu.Registers.C, ref cpu.Registers.B);
        }

        // 0x49   - MOV C, C
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_C_C(CPU cpu)
        {
            MOV(ref cpu.Registers.C, ref cpu.Registers.C);
        }

        // 0x4A   - MOV C, D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_C_D(CPU cpu)
        {
            MOV(ref cpu.Registers.C, ref cpu.Registers.D);
        }

        // 0x4B   - MOV C, E
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_C_E(CPU cpu)
        {
            MOV(ref cpu.Registers.C, ref cpu.Registers.E);
        }

        // 0x4C   - MOV C, H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_C_H(CPU cpu)
        {
            MOV(ref cpu.Registers.C, ref cpu.Registers.H);
        }

        // 0x4D   - MOV C, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_C_L(CPU cpu)
        {
            MOV(ref cpu.Registers.C, ref cpu.Registers.L);
        }

        // 0x4E   - MOV C, M
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public virtual void MOV_C_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Registers.C = cpu.Memory[location];
        }

        // 0x4F   - MOV C, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_C_A(CPU cpu)
        {
            MOV(ref cpu.Registers.C, ref cpu.Registers.A);
        }
        
        // 0x50   - MOV D, B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_D_B(CPU cpu)
        {
            MOV(ref cpu.Registers.D, ref cpu.Registers.B);
        }

        // 0x51   - MOV D, C
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_D_C(CPU cpu)
        {
            MOV(ref cpu.Registers.D, ref cpu.Registers.C);
        }

        // 0x52   - MOV D, D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_D_D(CPU cpu)
        {
            MOV(ref cpu.Registers.D, ref cpu.Registers.D);
        }

        // 0x53   - MOV D, E
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_D_E(CPU cpu)
        {
            MOV(ref cpu.Registers.D, ref cpu.Registers.E);
        }

        // 0x54   - MOV D, H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_D_H(CPU cpu)
        {
            MOV(ref cpu.Registers.D, ref cpu.Registers.H);
        }

        // 0x55   - MOV D, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_D_L(CPU cpu)
        {
            MOV(ref cpu.Registers.D, ref cpu.Registers.L);
        }

        // 0x56   - MOV D, M
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public virtual void MOV_D_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Registers.D = cpu.Memory[location];
        }

        // 0x57   - MOV D, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_D_A(CPU cpu)
        {
            MOV(ref cpu.Registers.D, ref cpu.Registers.A);
        }

        // 0x58   - MOV E, B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_E_B(CPU cpu)
        {
            MOV(ref cpu.Registers.E, ref cpu.Registers.B);
        }

        // 0x59   - MOV E, C
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_E_C(CPU cpu)
        {
            MOV(ref cpu.Registers.E, ref cpu.Registers.C);
        }

        // 0x5A   - MOV E, D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_E_D(CPU cpu)
        {
            MOV(ref cpu.Registers.E, ref cpu.Registers.D);
        }

        // 0x5B   - MOV E, E
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_E_E(CPU cpu)
        {
            MOV(ref cpu.Registers.E, ref cpu.Registers.E);
        }

        // 0x5C   - MOV E, H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_E_H(CPU cpu)
        {
            MOV(ref cpu.Registers.E, ref cpu.Registers.H);
        }

        // 0x5D   - MOV E, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_E_L(CPU cpu)
        {
            MOV(ref cpu.Registers.E, ref cpu.Registers.L);
        }

        // 0x5E   - MOV E, M
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public virtual void MOV_E_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Registers.E = cpu.Memory[location];
        }

        // 0x5F   - MOV E, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_E_A(CPU cpu)
        {
            MOV(ref cpu.Registers.E, ref cpu.Registers.A);
        }

        // 0x60   - MOV H, B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_H_B(CPU cpu)
        {
            MOV(ref cpu.Registers.H, ref cpu.Registers.B);
        }

        // 0x61   - MOV H, C
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_H_C(CPU cpu)
        {
            MOV(ref cpu.Registers.H, ref cpu.Registers.C);
        }

        // 0x62   - MOV H, D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_H_D(CPU cpu)
        {
            MOV(ref cpu.Registers.H, ref cpu.Registers.D);
        }

        // 0x63   - MOV H, E
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_H_E(CPU cpu)
        {
            MOV(ref cpu.Registers.H, ref cpu.Registers.E);
        }

        // 0x64   - MOV H, H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_H_H(CPU cpu)
        {
            MOV(ref cpu.Registers.H, ref cpu.Registers.H);
        }

        // 0x65   - MOV H, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_H_L(CPU cpu)
        {
            MOV(ref cpu.Registers.H, ref cpu.Registers.L);
        }

        // 0x66   - MOV H, M
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public virtual void MOV_H_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Registers.H = cpu.Memory[location];
        }

        // 0x67   - MOV H, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_H_A(CPU cpu)
        {
            MOV(ref cpu.Registers.H, ref cpu.Registers.A);
        }

        // 0x68   - MOV L, B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_L_B(CPU cpu)
        {
            MOV(ref cpu.Registers.L, ref cpu.Registers.B);
        }

        // 0x69   - MOV L, C
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_L_C(CPU cpu)
        {
            MOV(ref cpu.Registers.L, ref cpu.Registers.C);
        }

        // 0x6A   - MOV L, D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_L_D(CPU cpu)
        {
            MOV(ref cpu.Registers.L, ref cpu.Registers.D);
        }

        // 0x6B   - MOV L, E
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_L_E(CPU cpu)
        {
            MOV(ref cpu.Registers.L, ref cpu.Registers.E);
        }

        // 0x6C   - MOV L, H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_L_H(CPU cpu)
        {
            MOV(ref cpu.Registers.L, ref cpu.Registers.H);
        }

        // 0x6D   - MOV L, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_L_L(CPU cpu)
        {
            MOV(ref cpu.Registers.L, ref cpu.Registers.L);
        }

        // 0x6E   - MOV L, M
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public virtual void MOV_L_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Registers.L = cpu.Memory[location];
        }

        // 0x6F   - MOV L, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_L_A(CPU cpu)
        {
            MOV(ref cpu.Registers.L, ref cpu.Registers.A);
        }

        // 0x70   - MOV M, B
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public virtual void MOV_M_B(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Memory[location] = cpu.Registers.B;
        }

        // 0x71   - MOV M, C
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public virtual void MOV_M_C(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Memory[location] = cpu.Registers.C;
        }

        // 0x72   - MOV M, D
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public virtual void MOV_M_D(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Memory[location] = cpu.Registers.D;
        }

        // 0x73   - MOV M, E
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public virtual void MOV_M_E(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Memory[location] = cpu.Registers.E;
        }

        // 0x74   - MOV M, H
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public virtual void MOV_M_H(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Memory[location] = cpu.Registers.H;
        }

        // 0x75   - MOV M, L
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public virtual void MOV_M_L(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Memory[location] = cpu.Registers.L;
        }

        // 0x76   - HLT
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public virtual void HLT(CPU cpu)
        {
            cpu.Halted = true;
        }

        // 0x77   - MOV M, A
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public virtual void MOV_M_A(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Memory[location] = cpu.Registers.A;
        }

        // 0x78   - MOV A, B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_A_B(CPU cpu)
        {
            MOV(ref cpu.Registers.A, ref cpu.Registers.B);
        }

        // 0x79   - MOV A, C
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_A_C(CPU cpu)
        {
            MOV(ref cpu.Registers.A, ref cpu.Registers.C);
        }

        // 0x7A   - MOV A, D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_A_D(CPU cpu)
        {
            MOV(ref cpu.Registers.A, ref cpu.Registers.D);
        }

        // 0x7B   - MOV A, E
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_A_E(CPU cpu)
        {
            MOV(ref cpu.Registers.A, ref cpu.Registers.E);
        }

        // 0x7C   - MOV A, H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_A_H(CPU cpu)
        {
            MOV(ref cpu.Registers.A, ref cpu.Registers.H);
        }

        // 0x7D   - MOV A, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_A_L(CPU cpu)
        {
            MOV(ref cpu.Registers.A, ref cpu.Registers.L);
        }

        // 0x7E   - MOV A, M
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public virtual void MOV_A_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Registers.A = cpu.Memory[location];
        }

        // 0x7F   - MOV A, A
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void MOV_A_A(CPU cpu)
        {
            MOV(ref cpu.Registers.A, ref cpu.Registers.A);
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

            byte value = cpu.Memory[location];

            cpu.Flags.CalcAuxCarryFlag(cpu.Registers.A, value);

            ushort result = (ushort) (cpu.Registers.A + value);

            cpu.Registers.A = (byte) (result  & 0xFF);

            cpu.Flags.CalcSignFlag(cpu.Registers.A);
            cpu.Flags.CalcZeroFlag(cpu.Registers.A);
            cpu.Flags.CalcParityFlag(cpu.Registers.A);
            cpu.Flags.CalcCarryFlag(result);
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

            byte value = cpu.Memory[location];

            int carry = cpu.Flags.Carry ? 1 : 0;

            cpu.Flags.CalcAuxCarryFlag(cpu.Registers.A, value + carry);

            ushort result = (ushort) (cpu.Registers.A + value + carry);

            cpu.Registers.A = (byte) (result  & 0xFF);

            cpu.Flags.CalcSignFlag(cpu.Registers.A);
            cpu.Flags.CalcZeroFlag(cpu.Registers.A);
            cpu.Flags.CalcParityFlag(cpu.Registers.A);
            cpu.Flags.CalcCarryFlag(result);
        }

        // 0x8F   - ADC A
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S, Z, A, P, C
        public virtual void ADC_A(CPU cpu)
        {
            ADC(cpu, ref cpu.Registers.A);
        }
    }
}