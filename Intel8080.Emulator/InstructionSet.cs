using System;

namespace Intel8080.Emulator
{
    public static class InstructionSet
    {
        public static Opcode[] OpcodeTable;
        public static Action<CPU>[] OpcodeActions;

        static InstructionSet()
        {
            OpcodeTable = new Opcode[0xFF];

            // 0x0X
            OpcodeTable[0x00] = new Opcode("NOP",        1, 4,  null);
            OpcodeTable[0x01] = new Opcode("LXI B, d16", 3, 10, null);
            OpcodeTable[0x02] = new Opcode("STAX B",     1, 7,  null);
            OpcodeTable[0x03] = new Opcode("INX B",      1, 5,  null);
            OpcodeTable[0x04] = new Opcode("INR B",      1, 5,  null);
            OpcodeTable[0x05] = new Opcode("DCR B",      1, 5,  null);
            OpcodeTable[0x06] = new Opcode("MVI B, d8",  2, 7,  null);
            OpcodeTable[0x07] = new Opcode("RLC",        1, 4,  null);
            OpcodeTable[0x08] = new Opcode("*NOP",       1, 4,  null);
            OpcodeTable[0x09] = new Opcode("DAD B",      1, 10, null);
            OpcodeTable[0x0A] = new Opcode("LDAX B",     1, 7,  null);
            OpcodeTable[0x0B] = new Opcode("DCX B",      1, 5,  null);
            OpcodeTable[0x0C] = new Opcode("INR C",      1, 5,  null);
            OpcodeTable[0x0D] = new Opcode("DCR C",      1, 5,  null);
            OpcodeTable[0x0E] = new Opcode("MVI C, d8",  2, 7,  null);
            OpcodeTable[0x0F] = new Opcode("RRC",        1, 4,  null);

            // 0x1X
            OpcodeTable[0x10] = new Opcode("*NOP",       1, 4,  null);
            OpcodeTable[0x11] = new Opcode("LXI D, d16", 3, 10, null);
            OpcodeTable[0x12] = new Opcode("STAX D",     1, 7,  null);
            OpcodeTable[0x13] = new Opcode("INX D",      1, 5,  null);
            OpcodeTable[0x14] = new Opcode("INR D",      1, 5,  null);
            OpcodeTable[0x15] = new Opcode("DCR D",      1, 5,  null);
            OpcodeTable[0x16] = new Opcode("MVI D, d8",  2, 7,  null);
            OpcodeTable[0x17] = new Opcode("RAL",        1, 4,  null);
            OpcodeTable[0x18] = new Opcode("*NOP",       1, 4,  null);
            OpcodeTable[0x19] = new Opcode("DAD D",      1, 10, null);
            OpcodeTable[0x1A] = new Opcode("LDAX D",     1, 7,  null);
            OpcodeTable[0x1B] = new Opcode("DCX D",      1, 5,  null);
            OpcodeTable[0x1C] = new Opcode("INR E",      1, 5,  null);
            OpcodeTable[0x1D] = new Opcode("DCR E",      1, 5,  null);
            OpcodeTable[0x1E] = new Opcode("MVI E, d8",  2, 7,  null);
            OpcodeTable[0x1F] = new Opcode("RAR",        1, 4,  null);

            // 0x2X
            OpcodeTable[0x20] = new Opcode("*NOP",       1, 4,  null);
            OpcodeTable[0x21] = new Opcode("LXI H, d16", 3, 10, null);
            OpcodeTable[0x22] = new Opcode("SHLD a16",   3, 16, null);
            OpcodeTable[0x23] = new Opcode("INX H",      1, 5,  null);
            OpcodeTable[0x24] = new Opcode("INR H",      1, 5,  null);
            OpcodeTable[0x25] = new Opcode("DCR H",      1, 5,  null);
            OpcodeTable[0x26] = new Opcode("MVI H, d8",  2, 7,  null);
            OpcodeTable[0x27] = new Opcode("DAA",        1, 4,  null);
            OpcodeTable[0x28] = new Opcode("*NOP",       1, 4,  null);
            OpcodeTable[0x29] = new Opcode("DAD H",      1, 10, null);
            OpcodeTable[0x2A] = new Opcode("LHLD a16",   3, 16, null);
            OpcodeTable[0x2B] = new Opcode("DCX H",      1, 5,  null);
            OpcodeTable[0x2C] = new Opcode("INR L",      1, 5,  null);
            OpcodeTable[0x2D] = new Opcode("DCR L",      1, 5,  null);
            OpcodeTable[0x2E] = new Opcode("MVI L, d8",  2, 7,  null);
            OpcodeTable[0x2F] = new Opcode("CMA",        1, 4,  null);

            // 0x3X
            OpcodeTable[0x30] = new Opcode("*NOP",        1, 4,  null);
            OpcodeTable[0x31] = new Opcode("LXI SP, d16", 3, 10, null);
            OpcodeTable[0x32] = new Opcode("STA a16",     3, 13, null);
            OpcodeTable[0x33] = new Opcode("INX SP",      1, 5,  null);
            OpcodeTable[0x34] = new Opcode("INR M",       1, 10, null);
            OpcodeTable[0x35] = new Opcode("DCR M",       1, 10, null);
            OpcodeTable[0x36] = new Opcode("MVI M, d8",   2, 10, null);
            OpcodeTable[0x37] = new Opcode("STC",         1, 4,  null);
            OpcodeTable[0x38] = new Opcode("*NOP",        1, 4,  null);
            OpcodeTable[0x39] = new Opcode("DAD SP",      1, 10, null);
            OpcodeTable[0x3A] = new Opcode("LDA a16",     3, 13, null);
            OpcodeTable[0x3B] = new Opcode("DCX SP",      1, 5,  null);
            OpcodeTable[0x3C] = new Opcode("INR A",       1, 5,  null);
            OpcodeTable[0x3D] = new Opcode("DCR A",       1, 5,  null);
            OpcodeTable[0x3E] = new Opcode("MVI A, d8",   2, 7,  null);
            OpcodeTable[0x3F] = new Opcode("CMC",         1, 4,  null);

            OpcodeActions = new Action<CPU>[0xFF];

            // 0x0X
            OpcodeActions[0x00] = NOP;
            OpcodeActions[0x01] = LXI_B;
            OpcodeActions[0x02] = STAX_B;
            OpcodeActions[0x03] = INX_B;
            OpcodeActions[0x04] = INR_B;
            OpcodeActions[0x05] = DCR_B;
            OpcodeActions[0x06] = MVI_B;
            OpcodeActions[0x07] = RLC;
            OpcodeActions[0x08] = NOP;
            OpcodeActions[0x09] = DAD_B;
            OpcodeActions[0x0A] = LDAX_B;
            OpcodeActions[0x0B] = DCX_B;
            OpcodeActions[0x0C] = INR_C;
            OpcodeActions[0x0D] = DCR_C;
            OpcodeActions[0x0E] = MVI_C;
            OpcodeActions[0x0F] = RRC;

            // 0x1X
            OpcodeActions[0x10] = NOP;
            OpcodeActions[0x11] = LXI_D;
            OpcodeActions[0x12] = STAX_D;
            OpcodeActions[0x13] = INX_D;
            OpcodeActions[0x14] = INR_D;
            OpcodeActions[0x15] = DCR_D;
            OpcodeActions[0x16] = MVI_D;
            OpcodeActions[0x17] = RLC;
            OpcodeActions[0x18] = NOP;
            OpcodeActions[0x19] = DAD_D;
            OpcodeActions[0x1A] = LDAX_D;
            OpcodeActions[0x1B] = DCX_D;
            OpcodeActions[0x1C] = INR_E;
            OpcodeActions[0x1D] = DCR_E;
            OpcodeActions[0x1E] = MVI_E;
            OpcodeActions[0x1F] = RAR;

            // 0x2X
            OpcodeActions[0x20] = NOP;
            OpcodeActions[0x21] = LXI_H;
            OpcodeActions[0x22] = SHLD;
            OpcodeActions[0x23] = INX_H;
            OpcodeActions[0x24] = INR_H;
            OpcodeActions[0x25] = DCR_H;
            OpcodeActions[0x26] = MVI_H;
            OpcodeActions[0x27] = DAA;
            OpcodeActions[0x28] = NOP;
            OpcodeActions[0x29] = DAD_H;
            OpcodeActions[0x2A] = LHLD;
            OpcodeActions[0x2B] = DCX_H;
            OpcodeActions[0x2C] = INR_L;
            OpcodeActions[0x2D] = DCR_L;
            OpcodeActions[0x2E] = MVI_L;
            OpcodeActions[0x2F] = CMA;

            // 0x3X
            OpcodeActions[0x30] = NOP;
            OpcodeActions[0x31] = LXI_SP;
            OpcodeActions[0x32] = STA;
            OpcodeActions[0x33] = INX_SP;
            OpcodeActions[0x34] = INR_M;
            OpcodeActions[0x35] = DCR_M;
            OpcodeActions[0x36] = MVI_M;
            OpcodeActions[0x37] = STC;
            OpcodeActions[0x38] = NOP;
            OpcodeActions[0x39] = DAD_SP;
            OpcodeActions[0x3A] = LDA;
            OpcodeActions[0x3B] = DCX_SP;
            OpcodeActions[0x3C] = INR_A;
            OpcodeActions[0x3D] = DCR_A;
            OpcodeActions[0x3E] = MVI_A;
            OpcodeActions[0x3F] = CMC;
        }

        private static void INX(CPU cpu, ref ushort reg)
        {
            reg += 1;
        }

        private static void DCX(CPU cpu, ref ushort reg)
        {
            reg -= 1;
        }

        private static void INR(CPU cpu, ref byte reg)
        {
            cpu.Flags.CalcAuxCarryFlag(reg, 1);

            reg += 1;

            cpu.Flags.CalcSignFlag(reg);
            cpu.Flags.CalcZeroFlag(reg);
            cpu.Flags.CalcParityFlag(reg);
        }

        private static void DCR(CPU cpu, ref byte reg)
        {
            cpu.Flags.CalcAuxCarryFlagSub(reg, 1);

            reg -= 1;

            cpu.Flags.CalcSignFlag(reg);
            cpu.Flags.CalcZeroFlag(reg);
            cpu.Flags.CalcParityFlag(reg);
        }

        private static void STAX(CPU cpu, ushort reg)
        {
            cpu.Memory[reg] = cpu.Registers.A;
        }

        private static void LDAX(CPU cpu, ushort reg)
        {
            cpu.Registers.A = cpu.Memory[reg];
        }

        private static void LXI(CPU cpu, ref ushort reg)
        {
            ushort data = GetUshort(
                cpu.Memory[cpu.Registers.PC + 2],
                cpu.Memory[cpu.Registers.PC + 1]
            );

            reg = data;
        }

        private static void MVI(CPU cpu, ref byte reg)
        {
            reg = cpu.Memory[cpu.Registers.PC + 1];
        }

        private static void DAD(CPU cpu, ref ushort reg)
        {
            int result = cpu.Registers.HL + reg;

            cpu.Registers.HL = (ushort) (result & 0xFFFFFFFF);

            cpu.Flags.CalcCarryFlagRegisterPair(result);
        }

        private static ushort GetUshort(byte a, byte b)
        {
            return (ushort) ((a << 8) | b);
        }

        // 0x00   - NOP
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None
        public static void NOP(CPU cpu)
        {
            var opcode = OpcodeTable[0x00];

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x01   - LXI, B,d16
        // Bytes  - 3
        // Cycles - 10
        // Flags  - None
        public static void LXI_B(CPU cpu)
        {
            var opcode = OpcodeTable[0x01];

            LXI(cpu, ref cpu.Registers.BC);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x02   - STAX B
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public static void STAX_B(CPU cpu)
        {
            var opcode = OpcodeTable[0x02];

            STAX(cpu, cpu.Registers.BC);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x03   - INX B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void INX_B(CPU cpu)
        {
            var opcode = OpcodeTable[0x03];

            INX(cpu, ref cpu.Registers.BC);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x04   - INR B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public static void INR_B(CPU cpu)
        {
            var opcode = OpcodeTable[0x04];

            INR(cpu, ref cpu.Registers.B);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x05   - DCR B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public static void DCR_B(CPU cpu)
        {
            var opcode = OpcodeTable[0x05];

            DCR(cpu, ref cpu.Registers.B);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x06   - MVI B,d8
        // Bytes  - 2
        // Cycles - 7
        // Flags  - None
        public static void MVI_B(CPU cpu)
        {
            var opcode = OpcodeTable[0x06];

            MVI(cpu, ref cpu.Registers.B);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x07   - RLC
        // Bytes  - 1
        // Cycles - 4
        // Flags  - C
        public static void RLC(CPU cpu)
        {
            var opcode = OpcodeTable[0x07];

            cpu.Flags.Carry = ((cpu.Registers.A & 0x80) >> 7) == 1;
            cpu.Registers.A = (byte) (((cpu.Registers.A & 0x80) >> 7) | (cpu.Registers.A << 1));

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x08   - *NOP
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None
        
        // 0x09   - DAD B
        // Bytes  - 1
        // Cycles - 10
        // Flags  - C
        public static void DAD_B(CPU cpu)
        {
            var opcode = OpcodeTable[0x09];

            DAD(cpu, ref cpu.Registers.BC);
            
            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x0A   - LDAX B
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public static void LDAX_B(CPU cpu)
        {
            var opcode = OpcodeTable[0x0A];

            LDAX(cpu, cpu.Registers.BC);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x0B   - DCX B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void DCX_B(CPU cpu)
        {
            var opcode = OpcodeTable[0x0B];

            DCX(cpu, ref cpu.Registers.BC);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x0C   - INR C
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        
        public static void INR_C(CPU cpu)
        {
            var opcode = OpcodeTable[0x0C];

            INR(cpu, ref cpu.Registers.C);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x0D   - DCR C
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public static void DCR_C(CPU cpu)
        {
            var opcode = OpcodeTable[0x0D];

            DCR(cpu, ref cpu.Registers.C);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x0E   - MVI C, d8
        // Bytes  - 2
        // Cycles - 7
        // Flags  - None
        public static void MVI_C(CPU cpu)
        {
            var opcode = OpcodeTable[0x0E];

            MVI(cpu, ref cpu.Registers.C);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x0F   - RRC
        // Bytes  - 1
        // Cycles - 4
        // Flags  - C
        public static void RRC(CPU cpu)
        {
            var opcode = OpcodeTable[0x0F];

            cpu.Flags.Carry = (cpu.Registers.A & 0x01) == 1;
            cpu.Registers.A = (byte) (((cpu.Registers.A & 0x01) << 7) | (cpu.Registers.A >> 1));

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x10   - *NOP
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None

        // 0x11   - LXI D, d16
        // Bytes  - 3
        // Cycles - 10
        // Flags  - None
        public static void LXI_D(CPU cpu)
        {
            var opcode = OpcodeTable[0x11];

            LXI(cpu, ref cpu.Registers.DE);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x12   - STAX D
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public static void STAX_D(CPU cpu)
        {
            var opcode = OpcodeTable[0x12];

            STAX(cpu, cpu.Registers.DE);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x13   - INX D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void INX_D(CPU cpu)
        {
            var opcode = OpcodeTable[0x13];

            INX(cpu, ref cpu.Registers.DE);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x14   - INR D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public static void INR_D(CPU cpu)
        {
            var opcode = OpcodeTable[0x14];

            INR(cpu, ref cpu.Registers.D);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x15   - DCR D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public static void DCR_D(CPU cpu)
        {
            var opcode = OpcodeTable[0x15];

            DCR(cpu, ref cpu.Registers.D);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x16   - MVI D, d8
        // Bytes  - 2
        // Cycles - 7
        // Flags  - None
        public static void MVI_D(CPU cpu)
        {
            var opcode = OpcodeTable[0x16];

            MVI(cpu, ref cpu.Registers.D);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x17   - RAL
        // Bytes  - 1
        // Cycles - 4
        // Flags  - C
        public static void RAL(CPU cpu)
        {
            var opcode = OpcodeTable[0x17];

            bool carry = cpu.Flags.Carry;

            cpu.Flags.Carry = ((cpu.Registers.A & 0x80) >> 7) == 1;

            cpu.Registers.A <<= 1;

            if (carry) cpu.Registers.A |= 1;

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x18   - *NOP
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None

        // 0x19   - DAD D
        // Bytes  - 1
        // Cycles - 10
        // Flags  - C
        public static void DAD_D(CPU cpu)
        {
            var opcode = OpcodeTable[0x19];

            DAD(cpu, ref cpu.Registers.DE);
            
            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x1A   - LDAX D
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public static void LDAX_D(CPU cpu)
        {
            var opcode = OpcodeTable[0x1A];

            LDAX(cpu, cpu.Registers.DE);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }
        
        // 0x1B   - DCX D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void DCX_D(CPU cpu)
        {
            var opcode = OpcodeTable[0x1B];

            DCX(cpu, ref cpu.Registers.DE);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x1C   - INR E
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void INR_E(CPU cpu)
        {
            var opcode = OpcodeTable[0x1C];

            INR(cpu, ref cpu.Registers.E);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x1D   - DCR E
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void DCR_E(CPU cpu)
        {
            var opcode = OpcodeTable[0x1D];

            DCR(cpu, ref cpu.Registers.E);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x1E   - MVI E, d8
        // Bytes  - 2
        // Cycles - 7
        // Flags  - None
        public static void MVI_E(CPU cpu)
        {
            var opcode = OpcodeTable[0x1E];

            MVI(cpu, ref cpu.Registers.E);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x1F   - RAR
        // Bytes  - 1
        // Cycles - 4
        // Flags  - C
        public static void RAR(CPU cpu)
        {
            var opcode = OpcodeTable[0x1F];

            bool carry = cpu.Flags.Carry;

            cpu.Flags.Carry = (cpu.Registers.A & 0x01) == 1;

            cpu.Registers.A >>= 1;

            if (carry) cpu.Registers.A |= 0x80;

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x20   - *NOP
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None

        // 0x21   - LXI H, d16
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None
        public static void LXI_H(CPU cpu)
        {
            var opcode = OpcodeTable[0x21];

            LXI(cpu, ref cpu.Registers.HL);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x22   - SHLD a16
        // Bytes  - 3
        // Cycles - 16
        // Flags  - None
        public static void SHLD(CPU cpu)
        {
            var opcode = OpcodeTable[0x22];

            var location = GetUshort(
                cpu.Memory[cpu.Registers.PC + 2],
                cpu.Memory[cpu.Registers.PC + 1]
            );

            cpu.Memory[location] = cpu.Registers.L;
            cpu.Memory[location + 1] = cpu.Registers.H;

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x23   - INX H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void INX_H(CPU cpu)
        {
            var opcode = OpcodeTable[0x23];

            INX(cpu, ref cpu.Registers.HL);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x24   - INR H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public static void INR_H(CPU cpu)
        {
            var opcode = OpcodeTable[0x24];

            INR(cpu, ref cpu.Registers.H);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x25   - DCR H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public static void DCR_H(CPU cpu)
        {
            var opcode = OpcodeTable[0x25];

            DCR(cpu, ref cpu.Registers.H);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x26   - MVI H, d8
        // Bytes  - 2
        // Cycles - 7
        // Flags  - None
        public static void MVI_H(CPU cpu)
        {
            var opcode = OpcodeTable[0x26];

            MVI(cpu, ref cpu.Registers.H);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x27   - DAA
        // Bytes  - 1
        // Cycles - 4
        // Flags  - S Z A P C
        public static void DAA(CPU cpu)
        {
            var opcode = OpcodeTable[0x27];

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

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x28   - *NOP
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None

        // 0x29   - DAD H
        // Bytes  - 1
        // Cycles - 10
        // Flags  - C
        public static void DAD_H(CPU cpu)
        {
            var opcode = OpcodeTable[0x29];

            DAD(cpu, ref cpu.Registers.HL);
            
            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x2A   - LHLD a16
        // Bytes  - 3
        // Cycles - 16
        // Flags  - None
        public static void LHLD(CPU cpu)
        {
            var opcode = OpcodeTable[0x2A];

            var location = GetUshort(
                cpu.Memory[cpu.Registers.PC + 2],
                cpu.Memory[cpu.Registers.PC + 1]
            );

            cpu.Registers.L = cpu.Memory[location];
            cpu.Registers.H = cpu.Memory[location + 1];

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x2B   - DCX H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void DCX_H(CPU cpu)
        {
            var opcode = OpcodeTable[0x2B];

            DCX(cpu, ref cpu.Registers.HL);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x2C  - INR L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public static void INR_L(CPU cpu)
        {
            var opcode = OpcodeTable[0x2C];

            INR(cpu, ref cpu.Registers.L);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x2D  - DCR L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public static void DCR_L(CPU cpu)
        {
            var opcode = OpcodeTable[0x2D];

            DCR(cpu, ref cpu.Registers.L);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x2E   - MVI L, d8
        // Bytes  - 2
        // Cycles - 7
        // Flags  - None
        public static void MVI_L(CPU cpu)
        {
            var opcode = OpcodeTable[0x2E];

            MVI(cpu, ref cpu.Registers.L);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x2F   - CMA
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None
        public static void CMA(CPU cpu)
        {
            var opcode = OpcodeTable[0x2F];

            cpu.Registers.A = (byte) ~cpu.Registers.A;

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x30   - *NOP
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None

        // 0x31   - LXI SP, d16
        // Bytes  - 3
        // Cycles - 10
        // Flags  - None
        public static void LXI_SP(CPU cpu)
        {
            var opcode = OpcodeTable[0x31];

            LXI(cpu, ref cpu.Registers.SP);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x32   - STA a16
        // Bytes  - 3
        // Cycles - 13
        // Flags  - None
        public static void STA(CPU cpu)
        {
            var opcode = OpcodeTable[0x32];

            var location = GetUshort(
                cpu.Memory[cpu.Registers.PC + 2],
                cpu.Memory[cpu.Registers.PC + 1]
            );

            cpu.Memory[location] = cpu.Registers.A;

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x33   - INX SP
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void INX_SP(CPU cpu)
        {
            var opcode = OpcodeTable[0x33];

            INX(cpu, ref cpu.Registers.SP);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x34   - INR M
        // Bytes  - 1
        // Cycles - 10
        // Flags  - S, Z, A, P
        public static void INR_M(CPU cpu)
        {
            var opcode = OpcodeTable[0x34];

            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Flags.CalcAuxCarryFlag(cpu.Memory[location], 1);

            cpu.Memory[location] += 1;

            cpu.Flags.CalcSignFlag(cpu.Memory[location]);
            cpu.Flags.CalcZeroFlag(cpu.Memory[location]);
            cpu.Flags.CalcParityFlag(cpu.Memory[location]);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x35   - DCR M
        // Bytes  - 1
        // Cycles - 10
        // Flags  - S, Z, A, P
        public static void DCR_M(CPU cpu)
        {
            var opcode = OpcodeTable[0x35];

            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Flags.CalcAuxCarryFlagSub(cpu.Memory[location], 1);

            cpu.Memory[location] -= 1;

            cpu.Flags.CalcSignFlag(cpu.Memory[location]);
            cpu.Flags.CalcZeroFlag(cpu.Memory[location]);
            cpu.Flags.CalcParityFlag(cpu.Memory[location]);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x36   - MVI M
        // Bytes  - 2
        // Cycles - 10
        // Flags  - None
        public static void MVI_M(CPU cpu)
        {
            var opcode = OpcodeTable[0x36];

            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Memory[location] = cpu.Memory[cpu.Registers.PC + 1];

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x37   - STC
        // Bytes  - 1
        // Cycles - 4
        // Flags  - C
        public static void STC(CPU cpu)
        {
            var opcode = OpcodeTable[0x37];

            cpu.Flags.Carry = true;

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x38   - *NOP
        // Bytes  - 1
        // Cycles - 4
        // Flags  - None

        // 0x39   - DAD SP
        // Bytes  - 1
        // Cycles - 10
        // Flags  - C
        public static void DAD_SP(CPU cpu)
        {
            var opcode = OpcodeTable[0x39];

            DAD(cpu, ref cpu.Registers.SP);
            
            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x3A   - LDA a16
        // Bytes  - 3
        // Cycles - 13
        // Flags  - C
        public static void LDA(CPU cpu)
        {
            var opcode = OpcodeTable[0x3A];

            var location = GetUshort(
                cpu.Memory[cpu.Registers.PC + 2],
                cpu.Memory[cpu.Registers.PC + 1]
            );

            cpu.Registers.A = cpu.Memory[location];
            
            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x3B   - DCX SP
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void DCX_SP(CPU cpu)
        {
            var opcode = OpcodeTable[0x3B];

            DCX(cpu, ref cpu.Registers.SP);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x3C   - INR A
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public static void INR_A(CPU cpu)
        {
            var opcode = OpcodeTable[0x3C];

            INR(cpu, ref cpu.Registers.A);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x3D   - DCR A
        // Bytes  - 1
        // Cycles - 5
        // Flags  - S, Z, A, P
        public static void DCR_A(CPU cpu)
        {
            var opcode = OpcodeTable[0x3D];

            DCR(cpu, ref cpu.Registers.A);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x3E   - MVI A, d8
        // Bytes  - 2
        // Cycles - 7
        // Flags  - None
        public static void MVI_A(CPU cpu)
        {
            var opcode = OpcodeTable[0x3E];

            MVI(cpu, ref cpu.Registers.A);

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }

        // 0x3F   - CMC
        // Bytes  - 1
        // Cycles - 4
        // Flags  - C
        public static void CMC(CPU cpu)
        {
            var opcode = OpcodeTable[0x3F];

            cpu.Flags.Carry = !cpu.Flags.Carry;

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }
    }
}