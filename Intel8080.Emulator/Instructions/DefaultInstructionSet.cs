using System;

namespace Intel8080.Emulator.Instructions
{
    public static partial class DefaultInstructionSet
    {
        public static readonly Action<CPU>[] Actions;

        static DefaultInstructionSet()
        {
            Actions = new Action<CPU>[0x100];

            // 0x0X
            Actions[0x00] = NOP;
            Actions[0x01] = LXI_B;
            Actions[0x02] = STAX_B;
            Actions[0x03] = INX_B;
            Actions[0x04] = INR_B;
            Actions[0x05] = DCR_B;
            Actions[0x06] = MVI_B;
            Actions[0x07] = RLC;
            Actions[0x08] = NOP;
            Actions[0x09] = DAD_B;
            Actions[0x0A] = LDAX_B;
            Actions[0x0B] = DCX_B;
            Actions[0x0C] = INR_C;
            Actions[0x0D] = DCR_C;
            Actions[0x0E] = MVI_C;
            Actions[0x0F] = RRC;

            // 0x1X
            Actions[0x10] = NOP;
            Actions[0x11] = LXI_D;
            Actions[0x12] = STAX_D;
            Actions[0x13] = INX_D;
            Actions[0x14] = INR_D;
            Actions[0x15] = DCR_D;
            Actions[0x16] = MVI_D;
            Actions[0x17] = RAL;
            Actions[0x18] = NOP;
            Actions[0x19] = DAD_D;
            Actions[0x1A] = LDAX_D;
            Actions[0x1B] = DCX_D;
            Actions[0x1C] = INR_E;
            Actions[0x1D] = DCR_E;
            Actions[0x1E] = MVI_E;
            Actions[0x1F] = RAR;

            // 0x2X
            Actions[0x20] = NOP;
            Actions[0x21] = LXI_H;
            Actions[0x22] = SHLD;
            Actions[0x23] = INX_H;
            Actions[0x24] = INR_H;
            Actions[0x25] = DCR_H;
            Actions[0x26] = MVI_H;
            Actions[0x27] = DAA;
            Actions[0x28] = NOP;
            Actions[0x29] = DAD_H;
            Actions[0x2A] = LHLD;
            Actions[0x2B] = DCX_H;
            Actions[0x2C] = INR_L;
            Actions[0x2D] = DCR_L;
            Actions[0x2E] = MVI_L;
            Actions[0x2F] = CMA;

            // 0x3X
            Actions[0x30] = NOP;
            Actions[0x31] = LXI_SP;
            Actions[0x32] = STA;
            Actions[0x33] = INX_SP;
            Actions[0x34] = INR_M;
            Actions[0x35] = DCR_M;
            Actions[0x36] = MVI_M;
            Actions[0x37] = STC;
            Actions[0x38] = NOP;
            Actions[0x39] = DAD_SP;
            Actions[0x3A] = LDA;
            Actions[0x3B] = DCX_SP;
            Actions[0x3C] = INR_A;
            Actions[0x3D] = DCR_A;
            Actions[0x3E] = MVI_A;
            Actions[0x3F] = CMC;

            // 0x4X
            Actions[0x40] = MOV_B_B;
            Actions[0x41] = MOV_B_C;
            Actions[0x42] = MOV_B_D;
            Actions[0x43] = MOV_B_E;
            Actions[0x44] = MOV_B_H;
            Actions[0x45] = MOV_B_L;
            Actions[0x46] = MOV_B_M;
            Actions[0x47] = MOV_B_A;
            Actions[0x48] = MOV_C_B;
            Actions[0x49] = MOV_C_C;
            Actions[0x4A] = MOV_C_D;
            Actions[0x4B] = MOV_C_E;
            Actions[0x4C] = MOV_C_H;
            Actions[0x4D] = MOV_C_L;
            Actions[0x4E] = MOV_C_M;
            Actions[0x4F] = MOV_C_A;

            // 0x5X
            Actions[0x50] = MOV_D_B;
            Actions[0x51] = MOV_D_C;
            Actions[0x52] = MOV_D_D;
            Actions[0x53] = MOV_D_E;
            Actions[0x54] = MOV_D_H;
            Actions[0x55] = MOV_D_L;
            Actions[0x56] = MOV_D_M;
            Actions[0x57] = MOV_D_A;
            Actions[0x58] = MOV_E_B;
            Actions[0x59] = MOV_E_C;
            Actions[0x5A] = MOV_E_D;
            Actions[0x5B] = MOV_E_E;
            Actions[0x5C] = MOV_E_H;
            Actions[0x5D] = MOV_E_L;
            Actions[0x5E] = MOV_E_M;
            Actions[0x5F] = MOV_E_A;

            // 0x6x
            Actions[0x60] = MOV_H_B;
            Actions[0x61] = MOV_H_C;
            Actions[0x62] = MOV_H_D;
            Actions[0x63] = MOV_H_E;
            Actions[0x64] = MOV_H_H;
            Actions[0x65] = MOV_H_L;
            Actions[0x66] = MOV_H_M;
            Actions[0x67] = MOV_H_A;
            Actions[0x68] = MOV_L_B;
            Actions[0x69] = MOV_L_C;
            Actions[0x6A] = MOV_L_D;
            Actions[0x6B] = MOV_L_E;
            Actions[0x6C] = MOV_L_H;
            Actions[0x6D] = MOV_L_L;
            Actions[0x6E] = MOV_L_M;
            Actions[0x6F] = MOV_L_A;

            // 0x7x
            Actions[0x70] = MOV_M_B;
            Actions[0x71] = MOV_M_C;
            Actions[0x72] = MOV_M_D;
            Actions[0x73] = MOV_M_E;
            Actions[0x74] = MOV_M_H;
            Actions[0x75] = MOV_M_L;
            Actions[0x76] = HLT;
            Actions[0x77] = MOV_M_A;
            Actions[0x78] = MOV_A_B;
            Actions[0x79] = MOV_A_C;
            Actions[0x7A] = MOV_A_D;
            Actions[0x7B] = MOV_A_E;
            Actions[0x7C] = MOV_A_H;
            Actions[0x7D] = MOV_A_L;
            Actions[0x7E] = MOV_A_M;
            Actions[0x7F] = MOV_A_A;

            // 0x8x
            Actions[0x80] = ADD_B;
            Actions[0x81] = ADD_C;
            Actions[0x82] = ADD_D;
            Actions[0x83] = ADD_E;
            Actions[0x84] = ADD_H;
            Actions[0x85] = ADD_L;
            Actions[0x86] = ADD_M;
            Actions[0x87] = ADD_A;
            Actions[0x88] = ADC_B;
            Actions[0x89] = ADC_C;
            Actions[0x8A] = ADC_D;
            Actions[0x8B] = ADC_E;
            Actions[0x8C] = ADC_H;
            Actions[0x8D] = ADC_L;
            Actions[0x8E] = ADC_M;
            Actions[0x8F] = ADC_A;

            // 0x9x
            Actions[0x90] = SUB_B;
            Actions[0x91] = SUB_C;
            Actions[0x92] = SUB_D;
            Actions[0x93] = SUB_E;
            Actions[0x94] = SUB_H;
            Actions[0x95] = SUB_L;
            Actions[0x96] = SUB_M;
            Actions[0x97] = SUB_A;
            Actions[0x98] = SBB_B;
            Actions[0x99] = SBB_C;
            Actions[0x9A] = SBB_D;
            Actions[0x9B] = SBB_E;
            Actions[0x9C] = SBB_H;
            Actions[0x9D] = SBB_L;
            Actions[0x9E] = SBB_M;
            Actions[0x9F] = SBB_A;

            // 0xAx
            Actions[0xA0] = ANA_B;
            Actions[0xA1] = ANA_C;
            Actions[0xA2] = ANA_D;
            Actions[0xA3] = ANA_E;
            Actions[0xA4] = ANA_H;
            Actions[0xA5] = ANA_L;
            Actions[0xA6] = ANA_M;
            Actions[0xA7] = ANA_A;
            Actions[0xA8] = XRA_B;
            Actions[0xA9] = XRA_C;
            Actions[0xAA] = XRA_D;
            Actions[0xAB] = XRA_E;
            Actions[0xAC] = XRA_H;
            Actions[0xAD] = XRA_L;
            Actions[0xAE] = XRA_M;
            Actions[0xAF] = XRA_A;

            // 0xBx
            Actions[0xB0] = ORA_B;
            Actions[0xB1] = ORA_C;
            Actions[0xB2] = ORA_D;
            Actions[0xB3] = ORA_E;
            Actions[0xB4] = ORA_H;
            Actions[0xB5] = ORA_L;
            Actions[0xB6] = ORA_M;
            Actions[0xB7] = ORA_A;
            Actions[0xB8] = CMP_B;
            Actions[0xB9] = CMP_C;
            Actions[0xBA] = CMP_D;
            Actions[0xBB] = CMP_E;
            Actions[0xBC] = CMP_H;
            Actions[0xBD] = CMP_L;
            Actions[0xBE] = CMP_M;
            Actions[0xBF] = CMP_A;

            // 0xCX
            Actions[0xC0] = RNZ;
            Actions[0xC1] = POP_B;
            Actions[0xC2] = JNZ;
            Actions[0xC3] = JMP;
            Actions[0xC4] = CNZ;
            Actions[0xC5] = PUSH_B;
            Actions[0xC6] = ADI;
            Actions[0xC7] = RST_0;
            Actions[0xC8] = RZ;
            Actions[0xC9] = RET;
            Actions[0xCA] = JZ;
            Actions[0xCB] = JMP;
            Actions[0xCC] = CZ;
            Actions[0xCD] = CALL;
            Actions[0xCE] = ACI;
            Actions[0xCF] = RST_1;

            // 0xDX
            Actions[0xD0] = RNC;
            Actions[0xD1] = POP_D;
            Actions[0xD2] = JNC;
            Actions[0xD3] = OUT;
            Actions[0xD4] = CNC;
            Actions[0xD5] = PUSH_D;
            Actions[0xD6] = SUI;
            Actions[0xD7] = RST_2;
            Actions[0xD8] = RC;
            Actions[0xD9] = RET;
            Actions[0xDA] = JC;
            Actions[0xDB] = IN;
            Actions[0xDC] = CC;
            Actions[0xDD] = CALL;
            Actions[0xDE] = SBI;
            Actions[0xDF] = RST_3;

            // 0xEX
            Actions[0xE0] = RPO;
            Actions[0xE1] = POP_H;
            Actions[0xE2] = JPO;
            Actions[0xE3] = XTHL;
            Actions[0xE4] = CPO;
            Actions[0xE5] = PUSH_H;
            Actions[0xE6] = ANI;
            Actions[0xE7] = RST_4;
            Actions[0xE8] = RPE;
            Actions[0xE9] = PCHL;
            Actions[0xEA] = JPE;
            Actions[0xEB] = XCHG;
            Actions[0xEC] = CPE;
            Actions[0xED] = CALL;
            Actions[0xEE] = XRI;
            Actions[0xEF] = RST_5;

            // 0xFX
            Actions[0xF0] = RP;
            Actions[0xF1] = POP_PSW;
            Actions[0xF2] = JP;
            Actions[0xF3] = DI;
            Actions[0xF4] = CP;
            Actions[0xF5] = PUSH_PSW;
            Actions[0xF6] = ORI;
            Actions[0xF7] = RST_6;
            Actions[0xF8] = RM;
            Actions[0xF9] = SPHL;
            Actions[0xFA] = JM;
            Actions[0xFB] = EI;
            Actions[0xFC] = CM;
            Actions[0xFD] = CALL;
            Actions[0xFE] = CPI;
            Actions[0xFF] = RST_7;
        }

        private static ushort PopStack(CPU cpu)
        {
            ushort val = GetUshort(
                cpu.Memory[cpu.Registers.SP + 1],
                cpu.Memory[cpu.Registers.SP]
            );

            cpu.Registers.SP += 2;

            return val;
        }

        private static void PushStack(CPU cpu, ushort data)
        {
            cpu.Registers.SP -= 2;

            cpu.Memory[cpu.Registers.SP + 1] = (byte) ((data & 0xFF00) >> 8);
            cpu.Memory[cpu.Registers.SP] = (byte) (data & 0x00FF);
        }

        private static ushort GetUshort(byte a, byte b)
        {
            return (ushort) ((a << 8) | b);
        }
    }
}