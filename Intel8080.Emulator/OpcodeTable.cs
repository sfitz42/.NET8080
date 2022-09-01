namespace Intel8080.Emulator
{
    public static class OpcodeTable
    {
        public static Opcode[] Opcodes;

        static OpcodeTable()
        {
            Opcodes = new Opcode[0x100];

            // 0x0X
            Opcodes[0x00] = new Opcode("NOP",        1, 4,  null);
            Opcodes[0x01] = new Opcode("LXI B, d16", 3, 10, null);
            Opcodes[0x02] = new Opcode("STAX B",     1, 7,  null);
            Opcodes[0x03] = new Opcode("INX B",      1, 5,  null);
            Opcodes[0x04] = new Opcode("INR B",      1, 5,  null);
            Opcodes[0x05] = new Opcode("DCR B",      1, 5,  null);
            Opcodes[0x06] = new Opcode("MVI B, d8",  2, 7,  null);
            Opcodes[0x07] = new Opcode("RLC",        1, 4,  null);
            Opcodes[0x08] = new Opcode("*NOP",       1, 4,  null);
            Opcodes[0x09] = new Opcode("DAD B",      1, 10, null);
            Opcodes[0x0A] = new Opcode("LDAX B",     1, 7,  null);
            Opcodes[0x0B] = new Opcode("DCX B",      1, 5,  null);
            Opcodes[0x0C] = new Opcode("INR C",      1, 5,  null);
            Opcodes[0x0D] = new Opcode("DCR C",      1, 5,  null);
            Opcodes[0x0E] = new Opcode("MVI C, d8",  2, 7,  null);
            Opcodes[0x0F] = new Opcode("RRC",        1, 4,  null);

            // 0x1X
            Opcodes[0x10] = new Opcode("*NOP",       1, 4,  null);
            Opcodes[0x11] = new Opcode("LXI D, d16", 3, 10, null);
            Opcodes[0x12] = new Opcode("STAX D",     1, 7,  null);
            Opcodes[0x13] = new Opcode("INX D",      1, 5,  null);
            Opcodes[0x14] = new Opcode("INR D",      1, 5,  null);
            Opcodes[0x15] = new Opcode("DCR D",      1, 5,  null);
            Opcodes[0x16] = new Opcode("MVI D, d8",  2, 7,  null);
            Opcodes[0x17] = new Opcode("RAL",        1, 4,  null);
            Opcodes[0x18] = new Opcode("*NOP",       1, 4,  null);
            Opcodes[0x19] = new Opcode("DAD D",      1, 10, null);
            Opcodes[0x1A] = new Opcode("LDAX D",     1, 7,  null);
            Opcodes[0x1B] = new Opcode("DCX D",      1, 5,  null);
            Opcodes[0x1C] = new Opcode("INR E",      1, 5,  null);
            Opcodes[0x1D] = new Opcode("DCR E",      1, 5,  null);
            Opcodes[0x1E] = new Opcode("MVI E, d8",  2, 7,  null);
            Opcodes[0x1F] = new Opcode("RAR",        1, 4,  null);

            // 0x2X
            Opcodes[0x20] = new Opcode("*NOP",       1, 4,  null);
            Opcodes[0x21] = new Opcode("LXI H, d16", 3, 10, null);
            Opcodes[0x22] = new Opcode("SHLD a16",   3, 16, null);
            Opcodes[0x23] = new Opcode("INX H",      1, 5,  null);
            Opcodes[0x24] = new Opcode("INR H",      1, 5,  null);
            Opcodes[0x25] = new Opcode("DCR H",      1, 5,  null);
            Opcodes[0x26] = new Opcode("MVI H, d8",  2, 7,  null);
            Opcodes[0x27] = new Opcode("DAA",        1, 4,  null);
            Opcodes[0x28] = new Opcode("*NOP",       1, 4,  null);
            Opcodes[0x29] = new Opcode("DAD H",      1, 10, null);
            Opcodes[0x2A] = new Opcode("LHLD a16",   3, 16, null);
            Opcodes[0x2B] = new Opcode("DCX H",      1, 5,  null);
            Opcodes[0x2C] = new Opcode("INR L",      1, 5,  null);
            Opcodes[0x2D] = new Opcode("DCR L",      1, 5,  null);
            Opcodes[0x2E] = new Opcode("MVI L, d8",  2, 7,  null);
            Opcodes[0x2F] = new Opcode("CMA",        1, 4,  null);

            // 0x3X
            Opcodes[0x30] = new Opcode("*NOP",        1, 4,  null);
            Opcodes[0x31] = new Opcode("LXI SP, d16", 3, 10, null);
            Opcodes[0x32] = new Opcode("STA a16",     3, 13, null);
            Opcodes[0x33] = new Opcode("INX SP",      1, 5,  null);
            Opcodes[0x34] = new Opcode("INR M",       1, 10, null);
            Opcodes[0x35] = new Opcode("DCR M",       1, 10, null);
            Opcodes[0x36] = new Opcode("MVI M, d8",   2, 10, null);
            Opcodes[0x37] = new Opcode("STC",         1, 4,  null);
            Opcodes[0x38] = new Opcode("*NOP",        1, 4,  null);
            Opcodes[0x39] = new Opcode("DAD SP",      1, 10, null);
            Opcodes[0x3A] = new Opcode("LDA a16",     3, 13, null);
            Opcodes[0x3B] = new Opcode("DCX SP",      1, 5,  null);
            Opcodes[0x3C] = new Opcode("INR A",       1, 5,  null);
            Opcodes[0x3D] = new Opcode("DCR A",       1, 5,  null);
            Opcodes[0x3E] = new Opcode("MVI A, d8",   2, 7,  null);
            Opcodes[0x3F] = new Opcode("CMC",         1, 4,  null);

            // 0x4X
            Opcodes[0x40] = new Opcode("MOV B, B",    1, 5,  null);
            Opcodes[0x41] = new Opcode("MOV B, C",    1, 5,  null);
            Opcodes[0x42] = new Opcode("MOV B, D",    1, 5,  null);
            Opcodes[0x43] = new Opcode("MOV B, E",    1, 5,  null);
            Opcodes[0x44] = new Opcode("MOV B, H",    1, 5,  null);
            Opcodes[0x45] = new Opcode("MOV B, L",    1, 5,  null);
            Opcodes[0x46] = new Opcode("MOV B, M",    1, 7,  null);
            Opcodes[0x47] = new Opcode("MOV B, A",    1, 5,  null);
            Opcodes[0x48] = new Opcode("MOV C, B",    1, 5,  null);
            Opcodes[0x49] = new Opcode("MOV C, C",    1, 5,  null);
            Opcodes[0x4A] = new Opcode("MOV C, D",    1, 5,  null);
            Opcodes[0x4B] = new Opcode("MOV C, E",    1, 5,  null);
            Opcodes[0x4C] = new Opcode("MOV C, H",    1, 5,  null);
            Opcodes[0x4D] = new Opcode("MOV C, L",    1, 5,  null);
            Opcodes[0x4E] = new Opcode("MOV C, M",    1, 7,  null);
            Opcodes[0x4F] = new Opcode("MOV C, A",    1, 5,  null);

            // 0x5X
            Opcodes[0x50] = new Opcode("MOV D, B",    1, 5,  null);
            Opcodes[0x51] = new Opcode("MOV D, C",    1, 5,  null);
            Opcodes[0x52] = new Opcode("MOV D, D",    1, 5,  null);
            Opcodes[0x53] = new Opcode("MOV D, E",    1, 5,  null);
            Opcodes[0x54] = new Opcode("MOV D, H",    1, 5,  null);
            Opcodes[0x55] = new Opcode("MOV D, L",    1, 5,  null);
            Opcodes[0x56] = new Opcode("MOV D, M",    1, 7,  null);
            Opcodes[0x57] = new Opcode("MOV D, A",    1, 5,  null);
            Opcodes[0x58] = new Opcode("MOV E, B",    1, 5,  null);
            Opcodes[0x59] = new Opcode("MOV E, C",    1, 5,  null);
            Opcodes[0x5A] = new Opcode("MOV E, D",    1, 5,  null);
            Opcodes[0x5B] = new Opcode("MOV E, E",    1, 5,  null);
            Opcodes[0x5C] = new Opcode("MOV E, H",    1, 5,  null);
            Opcodes[0x5D] = new Opcode("MOV E, L",    1, 5,  null);
            Opcodes[0x5E] = new Opcode("MOV E, M",    1, 7,  null);
            Opcodes[0x5F] = new Opcode("MOV E, A",    1, 5,  null);

            // 0x6X
            Opcodes[0x60] = new Opcode("MOV H, B",    1, 5,  null);
            Opcodes[0x61] = new Opcode("MOV H, C",    1, 5,  null);
            Opcodes[0x62] = new Opcode("MOV H, D",    1, 5,  null);
            Opcodes[0x63] = new Opcode("MOV H, E",    1, 5,  null);
            Opcodes[0x64] = new Opcode("MOV H, H",    1, 5,  null);
            Opcodes[0x65] = new Opcode("MOV H, L",    1, 5,  null);
            Opcodes[0x66] = new Opcode("MOV H, M",    1, 7,  null);
            Opcodes[0x67] = new Opcode("MOV H, A",    1, 5,  null);
            Opcodes[0x68] = new Opcode("MOV L, B",    1, 5,  null);
            Opcodes[0x69] = new Opcode("MOV L, C",    1, 5,  null);
            Opcodes[0x6A] = new Opcode("MOV L, D",    1, 5,  null);
            Opcodes[0x6B] = new Opcode("MOV L, E",    1, 5,  null);
            Opcodes[0x6C] = new Opcode("MOV L, H",    1, 5,  null);
            Opcodes[0x6D] = new Opcode("MOV L, L",    1, 5,  null);
            Opcodes[0x6E] = new Opcode("MOV L, M",    1, 7,  null);
            Opcodes[0x6F] = new Opcode("MOV L, A",    1, 5,  null);
            
            // 0x7X
            Opcodes[0x70] = new Opcode("MOV M, B",    1, 7,  null);
            Opcodes[0x71] = new Opcode("MOV M, C",    1, 7,  null);
            Opcodes[0x72] = new Opcode("MOV M, D",    1, 7,  null);
            Opcodes[0x73] = new Opcode("MOV M, E",    1, 7,  null);
            Opcodes[0x74] = new Opcode("MOV M, H",    1, 7,  null);
            Opcodes[0x75] = new Opcode("MOV M, L",    1, 7,  null);
            Opcodes[0x76] = new Opcode("HLT",         1, 7,  null);
            Opcodes[0x77] = new Opcode("MOV M, A",    1, 7,  null);
            Opcodes[0x78] = new Opcode("MOV A, B",    1, 5,  null);
            Opcodes[0x79] = new Opcode("MOV A, C",    1, 5,  null);
            Opcodes[0x7A] = new Opcode("MOV A, D",    1, 5,  null);
            Opcodes[0x7B] = new Opcode("MOV A, E",    1, 5,  null);
            Opcodes[0x7C] = new Opcode("MOV A, H",    1, 5,  null);
            Opcodes[0x7D] = new Opcode("MOV A, L",    1, 5,  null);
            Opcodes[0x7E] = new Opcode("MOV A, M",    1, 7,  null);
            Opcodes[0x7F] = new Opcode("MOV A, A",    1, 5,  null);

            // 0x8X
            Opcodes[0x80] = new Opcode("ADD B",       1, 4,  null);
            Opcodes[0x81] = new Opcode("ADD C",       1, 4,  null);
            Opcodes[0x82] = new Opcode("ADD D",       1, 4,  null);
            Opcodes[0x83] = new Opcode("ADD E",       1, 4,  null);
            Opcodes[0x84] = new Opcode("ADD H",       1, 4,  null);
            Opcodes[0x85] = new Opcode("ADD L",       1, 4,  null);
            Opcodes[0x86] = new Opcode("ADD M",       1, 7,  null);
            Opcodes[0x87] = new Opcode("ADD A",       1, 4,  null);
            Opcodes[0x88] = new Opcode("ADC B",       1, 4,  null);
            Opcodes[0x89] = new Opcode("ADC C",       1, 4,  null);
            Opcodes[0x8A] = new Opcode("ADC D",       1, 4,  null);
            Opcodes[0x8B] = new Opcode("ADC E",       1, 4,  null);
            Opcodes[0x8C] = new Opcode("ADC H",       1, 4,  null);
            Opcodes[0x8D] = new Opcode("ADC L",       1, 4,  null);
            Opcodes[0x8E] = new Opcode("ADC M",       1, 7,  null);
            Opcodes[0x8F] = new Opcode("ADC A",       1, 4,  null);

            // 0x9X
            Opcodes[0x90] = new Opcode("SUB B",       1, 4,  null);
            Opcodes[0x91] = new Opcode("SUB C",       1, 4,  null);
            Opcodes[0x92] = new Opcode("SUB D",       1, 4,  null);
            Opcodes[0x93] = new Opcode("SUB E",       1, 4,  null);
            Opcodes[0x94] = new Opcode("SUB H",       1, 4,  null);
            Opcodes[0x95] = new Opcode("SUB L",       1, 4,  null);
            Opcodes[0x96] = new Opcode("SUB M",       1, 7,  null);
            Opcodes[0x97] = new Opcode("SUB A",       1, 4,  null);
            Opcodes[0x98] = new Opcode("SBB B",       1, 4,  null);
            Opcodes[0x99] = new Opcode("SBB C",       1, 4,  null);
            Opcodes[0x9A] = new Opcode("SBB D",       1, 4,  null);
            Opcodes[0x9B] = new Opcode("SBB E",       1, 4,  null);
            Opcodes[0x9C] = new Opcode("SBB H",       1, 4,  null);
            Opcodes[0x9D] = new Opcode("SBB L",       1, 4,  null);
            Opcodes[0x9E] = new Opcode("SBB M",       1, 7,  null);
            Opcodes[0x9F] = new Opcode("SBB A",       1, 4,  null);

            // 0xAX
            Opcodes[0xA0] = new Opcode("ANA B",       1, 4,  null);
            Opcodes[0xA1] = new Opcode("ANA C",       1, 4,  null);
            Opcodes[0xA2] = new Opcode("ANA D",       1, 4,  null);
            Opcodes[0xA3] = new Opcode("ANA E",       1, 4,  null);
            Opcodes[0xA4] = new Opcode("ANA H",       1, 4,  null);
            Opcodes[0xA5] = new Opcode("ANA L",       1, 4,  null);
            Opcodes[0xA6] = new Opcode("ANA M",       1, 7,  null);
            Opcodes[0xA7] = new Opcode("ANA A",       1, 4,  null);
            Opcodes[0xA8] = new Opcode("XRA B",       1, 4,  null);
            Opcodes[0xA9] = new Opcode("XRA C",       1, 4,  null);
            Opcodes[0xAA] = new Opcode("XRA D",       1, 4,  null);
            Opcodes[0xAB] = new Opcode("XRA E",       1, 4,  null);
            Opcodes[0xAC] = new Opcode("XRA H",       1, 4,  null);
            Opcodes[0xAD] = new Opcode("XRA L",       1, 4,  null);
            Opcodes[0xAE] = new Opcode("XRA M",       1, 7,  null);
            Opcodes[0xAF] = new Opcode("XRA A",       1, 4,  null);
        }
    }
}
