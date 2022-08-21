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

        public void MOV_B_B(CPU cpu);

        public void MOV_B_C(CPU cpu);

        public void MOV_B_D(CPU cpu);

        public void MOV_B_E(CPU cpu);

        public void MOV_B_H(CPU cpu);

        public void MOV_B_L(CPU cpu);

        public void MOV_B_M(CPU cpu);

        public void MOV_B_A(CPU cpu);

        public void MOV_C_B(CPU cpu);

        public void MOV_C_C(CPU cpu);

        public void MOV_C_D(CPU cpu);

        public void MOV_C_E(CPU cpu);

        public void MOV_C_H(CPU cpu);

        public void MOV_C_L(CPU cpu);

        public void MOV_C_M(CPU cpu);

        public void MOV_C_A(CPU cpu);

        public void MOV_D_B(CPU cpu);

        public void MOV_D_C(CPU cpu);

        public void MOV_D_D(CPU cpu);

        public void MOV_D_E(CPU cpu);

        public void MOV_D_H(CPU cpu);

        public void MOV_D_L(CPU cpu);

        public void MOV_D_M(CPU cpu);

        public void MOV_D_A(CPU cpu);

        public void MOV_E_B(CPU cpu);

        public void MOV_E_C(CPU cpu);

        public void MOV_E_D(CPU cpu);

        public void MOV_E_E(CPU cpu);

        public void MOV_E_H(CPU cpu);

        public void MOV_E_L(CPU cpu);

        public void MOV_E_M(CPU cpu);

        public void MOV_E_A(CPU cpu);

        public void MOV_H_B(CPU cpu);

        public void MOV_H_C(CPU cpu);

        public void MOV_H_D(CPU cpu);

        public void MOV_H_E(CPU cpu);

        public void MOV_H_H(CPU cpu);

        public void MOV_H_L(CPU cpu);

        public void MOV_H_M(CPU cpu);

        public void MOV_H_A(CPU cpu);

        public void MOV_L_B(CPU cpu);

        public void MOV_L_C(CPU cpu);

        public void MOV_L_D(CPU cpu);

        public void MOV_L_E(CPU cpu);

        public void MOV_L_H(CPU cpu);

        public void MOV_L_L(CPU cpu);

        public void MOV_L_M(CPU cpu);

        public void MOV_L_A(CPU cpu);

        public void MOV_M_B(CPU cpu);

        public void MOV_M_C(CPU cpu);

        public void MOV_M_D(CPU cpu);

        public void MOV_M_E(CPU cpu);

        public void MOV_M_H(CPU cpu);

        public void MOV_M_L(CPU cpu);

        public void HLT(CPU cpu);

        public void MOV_M_A(CPU cpu);

        public void MOV_A_B(CPU cpu);

        public void MOV_A_C(CPU cpu);

        public void MOV_A_D(CPU cpu);

        public void MOV_A_E(CPU cpu);

        public void MOV_A_H(CPU cpu);

        public void MOV_A_L(CPU cpu);

        public void MOV_A_M(CPU cpu);

        public void MOV_A_A(CPU cpu);

        public void ADD_B(CPU cpu);

        public void ADD_C(CPU cpu);

        public void ADD_D(CPU cpu);

        public void ADD_E(CPU cpu);

        public void ADD_H(CPU cpu);

        public void ADD_L(CPU cpu);

        public void ADD_M(CPU cpu);
        
        public void ADD_A(CPU cpu);

        public void ADC_B(CPU cpu);

        public void ADC_C(CPU cpu);

        public void ADC_D(CPU cpu);

        public void ADC_E(CPU cpu);

        public void ADC_H(CPU cpu);

        public void ADC_L(CPU cpu);

        public void ADC_M(CPU cpu);
        
        public void ADC_A(CPU cpu);
    }
}