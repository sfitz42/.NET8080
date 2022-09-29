namespace Intel8080.Emulator.Instructions
{
    public partial class DefaultInstructionSet : IInstructionSet
    {
        private void PUSH(CPU cpu, ref ushort reg)
        {
            PushStack(cpu, reg);
        }

        private void POP(CPU cpu, ref ushort reg)
        {
            var data = PopStack(cpu);

            reg = data;
        }

        private void DAD(CPU cpu, ref ushort reg)
        {
            int result = cpu.Registers.HL + reg;

            cpu.Registers.HL = (ushort) (result & 0xFFFFFFFF);

            cpu.Flags.CalcCarryFlagRegisterPair(result);
        }

        private void INX(CPU cpu, ref ushort reg)
        {
            reg += 1;
        }

        private void DCX(CPU cpu, ref ushort reg)
        {
            reg -= 1;
        }

        // 0x09   - DAD B
        // Bytes  - 1
        // Cycles - 10
        // Flags  - C
        public virtual void DAD_B(CPU cpu)
        {
            DAD(cpu, ref cpu.Registers.BC);
        }

        // 0x19   - DAD D
        // Bytes  - 1
        // Cycles - 10
        // Flags  - C
        public virtual void DAD_D(CPU cpu)
        {
            DAD(cpu, ref cpu.Registers.DE);
        }

        // 0x29   - DAD H
        // Bytes  - 1
        // Cycles - 10
        // Flags  - C
        public virtual void DAD_H(CPU cpu)
        {
            DAD(cpu, ref cpu.Registers.HL);
        }

        // 0x39   - DAD SP
        // Bytes  - 1
        // Cycles - 10
        // Flags  - C
        public virtual void DAD_SP(CPU cpu)
        {
            DAD(cpu, ref cpu.Registers.SP);
        }

        // 0x03   - INX B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void INX_B(CPU cpu)
        {
            INX(cpu, ref cpu.Registers.BC);
        }

        // 0x13   - INX D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void INX_D(CPU cpu)
        {
            INX(cpu, ref cpu.Registers.DE);
        }

        // 0x23   - INX H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void INX_H(CPU cpu)
        {
            INX(cpu, ref cpu.Registers.HL);
        }

        // 0x33   - INX SP
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void INX_SP(CPU cpu)
        {
            INX(cpu, ref cpu.Registers.SP);
        }

        // 0x0B   - DCX B
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void DCX_B(CPU cpu)
        {
            DCX(cpu, ref cpu.Registers.BC);
        }

        // 0x1B   - DCX D
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void DCX_D(CPU cpu)
        {
            DCX(cpu, ref cpu.Registers.DE);
        }

        // 0x2B   - DCX H
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void DCX_H(CPU cpu)
        {
            DCX(cpu, ref cpu.Registers.HL);
        }

        // 0x3B   - DCX SP
        // Bytes  - 1
        // Cycles - 5
        // Flags  - None
        public virtual void DCX_SP(CPU cpu)
        {
            DCX(cpu, ref cpu.Registers.SP);
        }

        public virtual void POP_B(CPU cpu)
        {
            POP(cpu, ref cpu.Registers.BC);
        }

        public virtual void PUSH_B(CPU cpu)
        {
            PUSH(cpu, ref cpu.Registers.BC);
        }

        public virtual void POP_D(CPU cpu)
        {
            POP(cpu, ref cpu.Registers.DE);
        }

        public virtual void PUSH_D(CPU cpu)
        {
            PUSH(cpu, ref cpu.Registers.DE);
        }

        public virtual void POP_H(CPU cpu)
        {
            POP(cpu, ref cpu.Registers.HL);
        }

        public virtual void PUSH_H(CPU cpu)
        {
            PUSH(cpu, ref cpu.Registers.HL);
        }

        public virtual void POP_PSW(CPU cpu)
        {
            var data = PopStack(cpu);

            cpu.Registers.A = (byte) ((data & 0xFF00) >> 8);

            var flags = (byte) (data & 0x00FF);

            cpu.Flags.SetFlagsPSW(flags);
        }

        public virtual void PUSH_PSW(CPU cpu)
        {
            var data = GetUshort(
                cpu.Registers.A,
                cpu.Flags.F
            );

            PUSH(cpu, ref data);
        }

        public virtual void XCHG(CPU cpu)
        {
            var temp = cpu.Registers.HL;
            
            cpu.Registers.HL = cpu.Registers.DE;
            cpu.Registers.DE = temp;
        }

        public virtual void XTHL(CPU cpu)
        {
            var temp = cpu.Registers.HL;

            cpu.Registers.HL = cpu.ReadUshort(cpu.Registers.SP);

            cpu.Memory[cpu.Registers.SP] = (byte) (temp & 0xFF);
            cpu.Memory[cpu.Registers.SP + 1] = (byte) ((temp & 0xFF00) >> 8);
        }

        public virtual void SPHL(CPU cpu)
        {
            cpu.Registers.SP = cpu.Registers.HL;
        }
    }
}