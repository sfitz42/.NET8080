using System;

namespace Intel8080.Emulator
{
    public interface IInstructionSet
    {
        public Action<CPU> this[int index] { get; }

        public void NOP(CPU cpu);

        public void LXI_B(CPU cpu);

        public void STAX_B(CPU cpu);

        public void INX_B(CPU cpu);

        public void INR_B(CPU cpu);

        public void DCR_B(CPU cpu);

        public void MVI_B(CPU cpu);

        public void RLC(CPU cpu);

        public void DAD_B(CPU cpu);

        public void LDAX_B(CPU cpu);

        public void DCX_B(CPU cpu);

        public void INR_C(CPU cpu);

        public void DCR_C(CPU cpu);

        public void MVI_C(CPU cpu);

        public void RRC(CPU cpu);

        public void LXI_D(CPU cpu);

        public void STAX_D(CPU cpu);

        public void INX_D(CPU cpu);

        public void INR_D(CPU cpu);

        public void DCR_D(CPU cpu);

        public void MVI_D(CPU cpu);

        public void RAL(CPU cpu);

        public void DAD_D(CPU cpu);

        public void LDAX_D(CPU cpu);

        public void DCX_D(CPU cpu);

        public void INR_E(CPU cpu);

        public void DCR_E(CPU cpu);
        
        public void MVI_E(CPU cpu);

        public void RAR(CPU cpu);

        public void LXI_H(CPU cpu);

        public void SHLD(CPU cpu);

        public void INX_H(CPU cpu);

        public void INR_H(CPU cpu);

        public void DCR_H(CPU cpu);

        public void MVI_H(CPU cpu);

        public void DAA(CPU cpu);

        public void DAD_H(CPU cpu);

        public void LHLD(CPU cpu);

        public void DCX_H(CPU cpu);

        public void INR_L(CPU cpu);

        public void DCR_L(CPU cpu);

        public void MVI_L(CPU cpu);

        public void CMA(CPU cpu);

        public void LXI_SP(CPU cpu);

        public void STA(CPU cpu);

        public void INX_SP(CPU cpu);

        public void INR_M(CPU cpu);

        public void DCR_M(CPU cpu);

        public void MVI_M(CPU cpu);

        public void STC(CPU cpu);

        public void DAD_SP(CPU cpu);

        public void LDA(CPU cpu);

        public void DCX_SP(CPU cpu);

        public void INR_A(CPU cpu);

        public void DCR_A(CPU cpu);

        public void MVI_A(CPU cpu);

        public void CMC(CPU cpu);
    }
}