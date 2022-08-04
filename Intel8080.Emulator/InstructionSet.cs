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
            OpcodeActions[0x0C] = INR_B;
            OpcodeActions[0x0D] = DCR_B;
            OpcodeActions[0x0E] = MVI_C;
            OpcodeActions[0x0F] = RRC;

            // 0x1X
            OpcodeActions[0x10] = NOP;
            OpcodeActions[0x11] = LXI_D;
            OpcodeActions[0x12] = STAX_D;
            OpcodeActions[0x13] = INX_B;
            OpcodeActions[0x14] = INR_B;
            OpcodeActions[0x15] = DCR_B;
            OpcodeActions[0x16] = MVI_B;
            OpcodeActions[0x17] = RLC;
            OpcodeActions[0x18] = NOP;
            OpcodeActions[0x19] = DAD_B;
            OpcodeActions[0x1A] = LDAX_B;
            OpcodeActions[0x1B] = DCX_B;
            OpcodeActions[0x1C] = INR_B;
            OpcodeActions[0x1D] = DCR_B;
            OpcodeActions[0x1E] = MVI_C;
            OpcodeActions[0x1F] = RRC;
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

            cpu.Registers.B = cpu.Memory[cpu.Registers.PC + 2];
            cpu.Registers.C = cpu.Memory[cpu.Registers.PC + 1];

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

            cpu.Memory[cpu.Registers.BC] = cpu.Registers.A;

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

            cpu.Registers.BC += 1;

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

            cpu.Registers.Flags.CalcAuxCarryFlag(cpu.Registers.B, 1);

            cpu.Registers.B += 1;

            cpu.Registers.Flags.CalcSignFlag(cpu.Registers.B);
            cpu.Registers.Flags.CalcZeroFlag(cpu.Registers.B);
            cpu.Registers.Flags.CalcParityFlag(cpu.Registers.B);

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

            cpu.Registers.Flags.CalcAuxCarryFlagSub(cpu.Registers.B, 1);

            cpu.Registers.B -= 1;

            cpu.Registers.Flags.CalcSignFlag(cpu.Registers.B);
            cpu.Registers.Flags.CalcZeroFlag(cpu.Registers.B);
            cpu.Registers.Flags.CalcParityFlag(cpu.Registers.B);

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

            cpu.Registers.B = cpu.Memory[cpu.Registers.PC + 1];

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

            cpu.Registers.Flags.Carry = ((cpu.Registers.A & 0x80) >> 7) == 1;
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

            int result = cpu.Registers.HL + cpu.Registers.BC;

            cpu.Registers.HL = (ushort) (result & 0xFFFFFFFF);

            cpu.Registers.Flags.CalcCarryFlagRegisterPair(result);
            
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

            cpu.Registers.A = cpu.Memory[cpu.Registers.BC];

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

            cpu.Registers.BC -= 1;

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

            cpu.Registers.Flags.CalcAuxCarryFlag(cpu.Registers.C, 1);

            cpu.Registers.C += 1;

            cpu.Registers.Flags.CalcSignFlag(cpu.Registers.C);
            cpu.Registers.Flags.CalcZeroFlag(cpu.Registers.C);
            cpu.Registers.Flags.CalcParityFlag(cpu.Registers.C);

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

            cpu.Registers.Flags.CalcAuxCarryFlagSub(cpu.Registers.C, 1);

            cpu.Registers.C -= 1;

            cpu.Registers.Flags.CalcSignFlag(cpu.Registers.C);
            cpu.Registers.Flags.CalcZeroFlag(cpu.Registers.C);
            cpu.Registers.Flags.CalcParityFlag(cpu.Registers.C);

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

            cpu.Registers.C = cpu.Memory[cpu.Registers.PC + 1];

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

            cpu.Registers.Flags.Carry = (cpu.Registers.A & 0x01) == 1;
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

            cpu.Registers.D = cpu.Memory[cpu.Registers.PC + 2];
            cpu.Registers.E = cpu.Memory[cpu.Registers.PC + 1];

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

            cpu.Memory[cpu.Registers.DE] = cpu.Registers.A;

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

            cpu.Registers.DE += 1;

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

            cpu.Registers.Flags.CalcAuxCarryFlag(cpu.Registers.D, 1);

            cpu.Registers.D += 1;

            cpu.Registers.Flags.CalcSignFlag(cpu.Registers.D);
            cpu.Registers.Flags.CalcZeroFlag(cpu.Registers.D);
            cpu.Registers.Flags.CalcParityFlag(cpu.Registers.D);

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

            cpu.Registers.Flags.CalcAuxCarryFlagSub(cpu.Registers.D, 1);

            cpu.Registers.D -= 1;

            cpu.Registers.Flags.CalcSignFlag(cpu.Registers.D);
            cpu.Registers.Flags.CalcZeroFlag(cpu.Registers.D);
            cpu.Registers.Flags.CalcParityFlag(cpu.Registers.D);

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

            cpu.Registers.D = cpu.Memory[cpu.Registers.PC + 1];

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

            bool carry = cpu.Registers.Flags.Carry;

            cpu.Registers.Flags.Carry = ((cpu.Registers.A & 0x80) >> 7) == 1;

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

            int result = cpu.Registers.HL + cpu.Registers.DE;

            cpu.Registers.HL = (ushort) (result & 0xFFFFFFFF);

            cpu.Registers.Flags.CalcCarryFlagRegisterPair(result);
            
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

            cpu.Registers.A = cpu.Memory[cpu.Registers.DE];

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

            cpu.Registers.DE -= 1;

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

            cpu.Registers.Flags.CalcAuxCarryFlag(cpu.Registers.E, 1);

            cpu.Registers.E += 1;

            cpu.Registers.Flags.CalcSignFlag(cpu.Registers.E);
            cpu.Registers.Flags.CalcZeroFlag(cpu.Registers.E);
            cpu.Registers.Flags.CalcParityFlag(cpu.Registers.E);

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

            cpu.Registers.Flags.CalcAuxCarryFlagSub(cpu.Registers.E, 1);

            cpu.Registers.E -= 1;

            cpu.Registers.Flags.CalcSignFlag(cpu.Registers.E);
            cpu.Registers.Flags.CalcZeroFlag(cpu.Registers.E);
            cpu.Registers.Flags.CalcParityFlag(cpu.Registers.E);

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

            cpu.Registers.E = cpu.Memory[cpu.Registers.PC + 1];

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

            bool carry = cpu.Registers.Flags.Carry;

            cpu.Registers.Flags.Carry = (cpu.Registers.A & 0x01) == 1;

            cpu.Registers.A >>= 1;

            if (carry) cpu.Registers.A |= 0x80;

            cpu.Registers.PC += opcode.Length;
            cpu.Cycles += opcode.Cycles;
        }
    }
}