using System;

namespace Intel8080.Emulator.Instructions
{
    public partial class DefaultInstructionSet : IInstructionSet
    {
        private Action<CPU>[] _actions = new Action<CPU>[0x100];

        public Action<CPU> this[int index]
        {
            get => _actions[index];
        }

        public DefaultInstructionSet()
        {
            _actions = new Action<CPU>[0x100];

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

            // 0x9x
            _actions[0x90] = SUB_B;
            _actions[0x91] = SUB_C;
            _actions[0x92] = SUB_D;
            _actions[0x93] = SUB_E;
            _actions[0x94] = SUB_H;
            _actions[0x95] = SUB_L;
            _actions[0x96] = SUB_M;
            _actions[0x97] = SUB_A;
            _actions[0x98] = SBB_B;
            _actions[0x99] = SBB_C;
            _actions[0x9A] = SBB_D;
            _actions[0x9B] = SBB_E;
            _actions[0x9C] = SBB_H;
            _actions[0x9D] = SBB_L;
            _actions[0x9E] = SBB_M;
            _actions[0x9F] = SBB_A;

            // 0xAx
            _actions[0xA0] = ANA_B;
            _actions[0xA1] = ANA_C;
            _actions[0xA2] = ANA_D;
            _actions[0xA3] = ANA_E;
            _actions[0xA4] = ANA_H;
            _actions[0xA5] = ANA_L;
            _actions[0xA6] = ANA_M;
            _actions[0xA7] = ANA_A;
            _actions[0xA8] = XRA_B;
            _actions[0xA9] = XRA_C;
            _actions[0xAA] = XRA_D;
            _actions[0xAB] = XRA_E;
            _actions[0xAC] = XRA_H;
            _actions[0xAD] = XRA_L;
            _actions[0xAE] = XRA_M;
            _actions[0xAF] = XRA_A;

            // 0xBx
            _actions[0xB0] = ORA_B;
            _actions[0xB1] = ORA_C;
            _actions[0xB2] = ORA_D;
            _actions[0xB3] = ORA_E;
            _actions[0xB4] = ORA_H;
            _actions[0xB5] = ORA_L;
            _actions[0xB6] = ORA_M;
            _actions[0xB7] = ORA_A;
            _actions[0xB8] = CMP_B;
            _actions[0xB9] = CMP_C;
            _actions[0xBA] = CMP_D;
            _actions[0xBB] = CMP_E;
            _actions[0xBC] = CMP_H;
            _actions[0xBD] = CMP_L;
            _actions[0xBE] = CMP_M;
            _actions[0xBF] = CMP_A;

            // 0xCX
            _actions[0xC0] = RNZ;
            _actions[0xC1] = POP_B;
            _actions[0xC2] = JNZ;
            _actions[0xC3] = JMP;
            _actions[0xC4] = CNZ;
            _actions[0xC5] = PUSH_B;
            _actions[0xC6] = ADI;
            _actions[0xC7] = RST_0;
            _actions[0xC8] = RZ;
            _actions[0xC9] = RET;
            _actions[0xCA] = JZ;
            _actions[0xCB] = JMP;
            _actions[0xCC] = CZ;
            _actions[0xCD] = CALL;
            _actions[0xCE] = ACI;
            _actions[0xCF] = RST_1;

            // 0xDX
            _actions[0xD0] = RNC;
            _actions[0xD1] = POP_D;
            _actions[0xD2] = JNC;
            _actions[0xD3] = OUT;
            _actions[0xD4] = CNC;
            _actions[0xD5] = PUSH_D;
            _actions[0xD6] = SUI;
            _actions[0xD7] = RST_2;
            _actions[0xD8] = RC;
            _actions[0xD9] = RET;
            _actions[0xDA] = JC;
            _actions[0xDB] = IN;
            _actions[0xDC] = CC;
            _actions[0xDD] = CALL;
            _actions[0xDE] = SBI;
            _actions[0xDF] = RST_3;

            // 0xEX
            _actions[0xE0] = RPO;
            _actions[0xE1] = POP_H;
            _actions[0xE2] = JPO;
            _actions[0xE3] = XTHL;
            _actions[0xE4] = CPO;
            _actions[0xE5] = PUSH_H;
            _actions[0xE6] = ANI;
            _actions[0xE7] = RST_4;
            _actions[0xE8] = RPE;
            _actions[0xE9] = PCHL;
            _actions[0xEA] = JPE;
            _actions[0xEB] = XCHG;
            _actions[0xEC] = CPE;
            _actions[0xED] = CALL;
            _actions[0xEE] = XRI;
            _actions[0xEF] = RST_5;

            // 0xFX
            _actions[0xF0] = RP;
            _actions[0xF1] = POP_PSW;
            _actions[0xF2] = JP;
            _actions[0xF3] = DI;
            _actions[0xF4] = CP;
            _actions[0xF5] = PUSH_PSW;
            _actions[0xF6] = ORI;
            _actions[0xF7] = RST_6;
            _actions[0xF8] = RM;
            _actions[0xF9] = SPHL;
            _actions[0xFA] = JM;
            _actions[0xFB] = EI;
            _actions[0xFC] = CM;
            _actions[0xFD] = CALL;
            _actions[0xFE] = CPI;
            _actions[0xFF] = RST_7;
        }

        private ushort PopStack(CPU cpu)
        {
            ushort val = GetUshort(
                cpu.Memory[cpu.Registers.SP + 1],
                cpu.Memory[cpu.Registers.SP]
            );

            cpu.Registers.SP += 2;

            return val;
        }

        private void PushStack(CPU cpu, ushort data)
        {
            cpu.Registers.SP -= 2;

            cpu.Memory[cpu.Registers.SP + 1] = (byte) ((data & 0xFF00) >> 8);
            cpu.Memory[cpu.Registers.SP] = (byte) (data & 0x00FF);
        }

        private ushort GetUshort(byte a, byte b)
        {
            return (ushort) ((a << 8) | b);
        }
    }
}