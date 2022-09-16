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
    }
}