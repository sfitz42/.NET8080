namespace Intel8080.Emulator
{
    public static class OpcodeTable
    {
        public static Opcode[] Opcodes;

        static OpcodeTable()
        {
            Opcodes = new Opcode[0xFF];

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
        }
    }
}
