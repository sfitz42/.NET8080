namespace Intel8080.Emulator.Instructions
{
    public static partial class DefaultInstructionSet
    {
        private static void MOV(ref byte targetReg, ref byte sourceReg)
        {
            targetReg = sourceReg;
        }

        private static void STAX(CPU cpu, ushort reg)
        {
            cpu.Memory[reg] = cpu.Registers.A;
        }

        private static void LDAX(CPU cpu, ushort reg)
        {
            cpu.Registers.A = cpu.Memory[reg];
        }

        // 0x40   - MOV B, B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_B_B(CPU cpu)
        {
            MOV(ref cpu.Registers.B, ref cpu.Registers.B);
        }

        // 0x41   - MOV B, C
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_B_C(CPU cpu)
        {
            MOV(ref cpu.Registers.B, ref cpu.Registers.C);
        }

        // 0x42   - MOV B, D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_B_D(CPU cpu)
        {
            MOV(ref cpu.Registers.B, ref cpu.Registers.D);
        }

        // 0x43   - MOV B, E
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_B_E(CPU cpu)
        {
            MOV(ref cpu.Registers.B, ref cpu.Registers.E);
        }

        // 0x44   - MOV B, H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_B_H(CPU cpu)
        {
            MOV(ref cpu.Registers.B, ref cpu.Registers.H);
        }

        // 0x45   - MOV B, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_B_L(CPU cpu)
        {
            MOV(ref cpu.Registers.B, ref cpu.Registers.L);
        }

        // 0x46   - MOV B, M
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public static void MOV_B_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Registers.B = cpu.Memory[location];
        }

        // 0x47   - MOV B, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_B_A(CPU cpu)
        {
            MOV(ref cpu.Registers.B, ref cpu.Registers.A);
        }
        
        // 0x48   - MOV C, B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_C_B(CPU cpu)
        {
            MOV(ref cpu.Registers.C, ref cpu.Registers.B);
        }

        // 0x49   - MOV C, C
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_C_C(CPU cpu)
        {
            MOV(ref cpu.Registers.C, ref cpu.Registers.C);
        }

        // 0x4A   - MOV C, D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_C_D(CPU cpu)
        {
            MOV(ref cpu.Registers.C, ref cpu.Registers.D);
        }

        // 0x4B   - MOV C, E
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_C_E(CPU cpu)
        {
            MOV(ref cpu.Registers.C, ref cpu.Registers.E);
        }

        // 0x4C   - MOV C, H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_C_H(CPU cpu)
        {
            MOV(ref cpu.Registers.C, ref cpu.Registers.H);
        }

        // 0x4D   - MOV C, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_C_L(CPU cpu)
        {
            MOV(ref cpu.Registers.C, ref cpu.Registers.L);
        }

        // 0x4E   - MOV C, M
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public static void MOV_C_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Registers.C = cpu.Memory[location];
        }

        // 0x4F   - MOV C, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_C_A(CPU cpu)
        {
            MOV(ref cpu.Registers.C, ref cpu.Registers.A);
        }
        
        // 0x50   - MOV D, B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_D_B(CPU cpu)
        {
            MOV(ref cpu.Registers.D, ref cpu.Registers.B);
        }

        // 0x51   - MOV D, C
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_D_C(CPU cpu)
        {
            MOV(ref cpu.Registers.D, ref cpu.Registers.C);
        }

        // 0x52   - MOV D, D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_D_D(CPU cpu)
        {
            MOV(ref cpu.Registers.D, ref cpu.Registers.D);
        }

        // 0x53   - MOV D, E
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_D_E(CPU cpu)
        {
            MOV(ref cpu.Registers.D, ref cpu.Registers.E);
        }

        // 0x54   - MOV D, H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_D_H(CPU cpu)
        {
            MOV(ref cpu.Registers.D, ref cpu.Registers.H);
        }

        // 0x55   - MOV D, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_D_L(CPU cpu)
        {
            MOV(ref cpu.Registers.D, ref cpu.Registers.L);
        }

        // 0x56   - MOV D, M
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public static void MOV_D_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Registers.D = cpu.Memory[location];
        }

        // 0x57   - MOV D, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_D_A(CPU cpu)
        {
            MOV(ref cpu.Registers.D, ref cpu.Registers.A);
        }

        // 0x58   - MOV E, B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_E_B(CPU cpu)
        {
            MOV(ref cpu.Registers.E, ref cpu.Registers.B);
        }

        // 0x59   - MOV E, C
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_E_C(CPU cpu)
        {
            MOV(ref cpu.Registers.E, ref cpu.Registers.C);
        }

        // 0x5A   - MOV E, D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_E_D(CPU cpu)
        {
            MOV(ref cpu.Registers.E, ref cpu.Registers.D);
        }

        // 0x5B   - MOV E, E
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_E_E(CPU cpu)
        {
            MOV(ref cpu.Registers.E, ref cpu.Registers.E);
        }

        // 0x5C   - MOV E, H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_E_H(CPU cpu)
        {
            MOV(ref cpu.Registers.E, ref cpu.Registers.H);
        }

        // 0x5D   - MOV E, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_E_L(CPU cpu)
        {
            MOV(ref cpu.Registers.E, ref cpu.Registers.L);
        }

        // 0x5E   - MOV E, M
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public static void MOV_E_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Registers.E = cpu.Memory[location];
        }

        // 0x5F   - MOV E, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_E_A(CPU cpu)
        {
            MOV(ref cpu.Registers.E, ref cpu.Registers.A);
        }

        // 0x60   - MOV H, B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_H_B(CPU cpu)
        {
            MOV(ref cpu.Registers.H, ref cpu.Registers.B);
        }

        // 0x61   - MOV H, C
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_H_C(CPU cpu)
        {
            MOV(ref cpu.Registers.H, ref cpu.Registers.C);
        }

        // 0x62   - MOV H, D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_H_D(CPU cpu)
        {
            MOV(ref cpu.Registers.H, ref cpu.Registers.D);
        }

        // 0x63   - MOV H, E
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_H_E(CPU cpu)
        {
            MOV(ref cpu.Registers.H, ref cpu.Registers.E);
        }

        // 0x64   - MOV H, H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_H_H(CPU cpu)
        {
            MOV(ref cpu.Registers.H, ref cpu.Registers.H);
        }

        // 0x65   - MOV H, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_H_L(CPU cpu)
        {
            MOV(ref cpu.Registers.H, ref cpu.Registers.L);
        }

        // 0x66   - MOV H, M
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public static void MOV_H_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Registers.H = cpu.Memory[location];
        }

        // 0x67   - MOV H, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_H_A(CPU cpu)
        {
            MOV(ref cpu.Registers.H, ref cpu.Registers.A);
        }

        // 0x68   - MOV L, B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_L_B(CPU cpu)
        {
            MOV(ref cpu.Registers.L, ref cpu.Registers.B);
        }

        // 0x69   - MOV L, C
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_L_C(CPU cpu)
        {
            MOV(ref cpu.Registers.L, ref cpu.Registers.C);
        }

        // 0x6A   - MOV L, D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_L_D(CPU cpu)
        {
            MOV(ref cpu.Registers.L, ref cpu.Registers.D);
        }

        // 0x6B   - MOV L, E
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_L_E(CPU cpu)
        {
            MOV(ref cpu.Registers.L, ref cpu.Registers.E);
        }

        // 0x6C   - MOV L, H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_L_H(CPU cpu)
        {
            MOV(ref cpu.Registers.L, ref cpu.Registers.H);
        }

        // 0x6D   - MOV L, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_L_L(CPU cpu)
        {
            MOV(ref cpu.Registers.L, ref cpu.Registers.L);
        }

        // 0x6E   - MOV L, M
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public static void MOV_L_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Registers.L = cpu.Memory[location];
        }

        // 0x6F   - MOV L, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_L_A(CPU cpu)
        {
            MOV(ref cpu.Registers.L, ref cpu.Registers.A);
        }

        // 0x70   - MOV M, B
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public static void MOV_M_B(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Memory[location] = cpu.Registers.B;
        }

        // 0x71   - MOV M, C
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public static void MOV_M_C(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Memory[location] = cpu.Registers.C;
        }

        // 0x72   - MOV M, D
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public static void MOV_M_D(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Memory[location] = cpu.Registers.D;
        }

        // 0x73   - MOV M, E
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public static void MOV_M_E(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Memory[location] = cpu.Registers.E;
        }

        // 0x74   - MOV M, H
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public static void MOV_M_H(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Memory[location] = cpu.Registers.H;
        }

        // 0x75   - MOV M, L
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public static void MOV_M_L(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Memory[location] = cpu.Registers.L;
        }

        // 0x77   - MOV M, A
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public static void MOV_M_A(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Memory[location] = cpu.Registers.A;
        }

        // 0x78   - MOV A, B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_A_B(CPU cpu)
        {
            MOV(ref cpu.Registers.A, ref cpu.Registers.B);
        }

        // 0x79   - MOV A, C
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_A_C(CPU cpu)
        {
            MOV(ref cpu.Registers.A, ref cpu.Registers.C);
        }

        // 0x7A   - MOV A, D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_A_D(CPU cpu)
        {
            MOV(ref cpu.Registers.A, ref cpu.Registers.D);
        }

        // 0x7B   - MOV A, E
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_A_E(CPU cpu)
        {
            MOV(ref cpu.Registers.A, ref cpu.Registers.E);
        }

        // 0x7C   - MOV A, H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_A_H(CPU cpu)
        {
            MOV(ref cpu.Registers.A, ref cpu.Registers.H);
        }

        // 0x7D   - MOV A, L
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_A_L(CPU cpu)
        {
            MOV(ref cpu.Registers.A, ref cpu.Registers.L);
        }

        // 0x7E   - MOV A, M
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public static void MOV_A_M(CPU cpu)
        {
            var location = GetUshort(cpu.Registers.H, cpu.Registers.L);

            cpu.Registers.A = cpu.Memory[location];
        }

        // 0x7F   - MOV A, A
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public static void MOV_A_A(CPU cpu)
        {
            MOV(ref cpu.Registers.A, ref cpu.Registers.A);
        }

        // 0x02   - STAX B
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public static void STAX_B(CPU cpu)
        {
            STAX(cpu, cpu.Registers.BC);
        }

        // 0x12   - STAX D
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public static void STAX_D(CPU cpu)
        {
            STAX(cpu, cpu.Registers.DE);
        }

        // 0x0A   - LDAX B
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public static void LDAX_B(CPU cpu)
        {
            LDAX(cpu, cpu.Registers.BC);
        }

        // 0x1A   - LDAX D
        // Bytes  - 1
        // Cycles - 7
        // Flags  - None
        public static void LDAX_D(CPU cpu)
        {
            LDAX(cpu, cpu.Registers.DE);
        }
    }
}