namespace Intel8080.Emulator.Instructions
{
    public partial class DefaultInstructionSet : IInstructionSet
    {
        private void CALL(CPU cpu, ushort address)
        {
            PushStack(cpu, (ushort) (cpu.Registers.PC + 1));

            cpu.Registers.PC = address;
        }

        public virtual void CALL(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            CALL(cpu, location);
        }

        public virtual void CNZ(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (!cpu.Flags.Zero)
            {
                CALL(cpu, location);

                cpu.Cycles += 6;
            }
        }


        public virtual void CZ(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (cpu.Flags.Zero)
            {
                CALL(cpu, location);

                cpu.Cycles += 6;
            }
        }

        public virtual void CNC(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (!cpu.Flags.Carry)
            {
                CALL(cpu, location);

                cpu.Cycles += 6;
            }
        }


        public virtual void CC(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (cpu.Flags.Carry)
            {
                CALL(cpu, location);

                cpu.Cycles += 6;
            }
        }

        public virtual void CPO(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (!cpu.Flags.Parity)
            {
                CALL(cpu, location);

                cpu.Cycles += 6;
            }
        }


        public virtual void CPE(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (cpu.Flags.Parity)
            {
                CALL(cpu, location);

                cpu.Cycles += 6;
            }
        }

        public virtual void CP(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (!cpu.Flags.Sign)
            {
                CALL(cpu, location);

                cpu.Cycles += 6;
            }
        }


        public virtual void CM(CPU cpu)
        {
            var location = cpu.ReadNextUshort();

            if (cpu.Flags.Sign)
            {
                CALL(cpu, location);

                cpu.Cycles += 6;
            }
        }

        public virtual void RST_0(CPU cpu)
        {
            CALL(cpu, 0x00);
        }

        public virtual void RST_1(CPU cpu)
        {
            CALL(cpu, 0x08);
        }

        public virtual void RST_2(CPU cpu)
        {
            CALL(cpu, 0x10);
        }

        public virtual void RST_3(CPU cpu)
        {
            CALL(cpu, 0x18);
        }

        public virtual void RST_4(CPU cpu)
        {
            CALL(cpu, 0x20);
        }

        public virtual void RST_5(CPU cpu)
        {
            CALL(cpu, 0x28);
        }

        public virtual void RST_6(CPU cpu)
        {
            CALL(cpu, 0x30);
        }

        public virtual void RST_7(CPU cpu)
        {
            CALL(cpu, 0x38);
        }
    }
}