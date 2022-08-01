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

            OpcodeActions = new Action<CPU>[0xFF];

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
    }
}