namespace Intel8080.Emulator.Instructions
{
    public static partial class DefaultInstructionSet
    {
        private static void CALL(CPU cpu, ushort address)
        {
            PushStack(cpu, cpu.Registers.PC);

            cpu.Registers.PC = address;
        }

        public static void CALL(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            CALL(cpu, location);
        }

        public static void CNZ(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (!cpu.Flags.Zero)
            {
                CALL(cpu, location);

                cpu.Cycles += 6;
            }
        }


        public static void CZ(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (cpu.Flags.Zero)
            {
                CALL(cpu, location);

                cpu.Cycles += 6;
            }
        }

        public static void CNC(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (!cpu.Flags.Carry)
            {
                CALL(cpu, location);

                cpu.Cycles += 6;
            }
        }


        public static void CC(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (cpu.Flags.Carry)
            {
                CALL(cpu, location);

                cpu.Cycles += 6;
            }
        }

        public static void CPO(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (!cpu.Flags.Parity)
            {
                CALL(cpu, location);

                cpu.Cycles += 6;
            }
        }


        public static void CPE(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (cpu.Flags.Parity)
            {
                CALL(cpu, location);

                cpu.Cycles += 6;
            }
        }

        public static void CP(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (!cpu.Flags.Sign)
            {
                CALL(cpu, location);

                cpu.Cycles += 6;
            }
        }


        public static void CM(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (cpu.Flags.Sign)
            {
                CALL(cpu, location);

                cpu.Cycles += 6;
            }
        }

        public static void RST_0(CPU cpu)
        {
            CALL(cpu, 0x00);
        }

        public static void RST_1(CPU cpu)
        {
            CALL(cpu, 0x08);
        }

        public static void RST_2(CPU cpu)
        {
            CALL(cpu, 0x10);
        }

        public static void RST_3(CPU cpu)
        {
            CALL(cpu, 0x18);
        }

        public static void RST_4(CPU cpu)
        {
            CALL(cpu, 0x20);
        }

        public static void RST_5(CPU cpu)
        {
            CALL(cpu, 0x28);
        }

        public static void RST_6(CPU cpu)
        {
            CALL(cpu, 0x30);
        }

        public static void RST_7(CPU cpu)
        {
            CALL(cpu, 0x38);
        }
    }
}