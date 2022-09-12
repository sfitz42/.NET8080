using System;

namespace Intel8080.Emulator.Instructions
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

        public void SUB_B(CPU cpu);

        public void SUB_C(CPU cpu);

        public void SUB_D(CPU cpu);

        public void SUB_E(CPU cpu);

        public void SUB_H(CPU cpu);

        public void SUB_L(CPU cpu);

        public void SUB_M(CPU cpu);
        
        public void SUB_A(CPU cpu);

        public void SBB_B(CPU cpu);

        public void SBB_C(CPU cpu);

        public void SBB_D(CPU cpu);

        public void SBB_E(CPU cpu);

        public void SBB_H(CPU cpu);

        public void SBB_L(CPU cpu);

        public void SBB_M(CPU cpu);
        
        public void SBB_A(CPU cpu);

        public void ANA_B(CPU cpu);

        public void ANA_C(CPU cpu);

        public void ANA_D(CPU cpu);

        public void ANA_E(CPU cpu);

        public void ANA_H(CPU cpu);

        public void ANA_L(CPU cpu);

        public void ANA_M(CPU cpu);
        
        public void ANA_A(CPU cpu);

        public void XRA_B(CPU cpu);

        public void XRA_C(CPU cpu);

        public void XRA_D(CPU cpu);

        public void XRA_E(CPU cpu);

        public void XRA_H(CPU cpu);

        public void XRA_L(CPU cpu);

        public void XRA_M(CPU cpu);

        public void XRA_A(CPU cpu);

        public void ORA_B(CPU cpu);

        public void ORA_C(CPU cpu);

        public void ORA_D(CPU cpu);

        public void ORA_E(CPU cpu);

        public void ORA_H(CPU cpu);

        public void ORA_L(CPU cpu);

        public void ORA_M(CPU cpu);

        public void ORA_A(CPU cpu);

        public void CMP_B(CPU cpu);

        public void CMP_C(CPU cpu);

        public void CMP_D(CPU cpu);

        public void CMP_E(CPU cpu);

        public void CMP_H(CPU cpu);

        public void CMP_L(CPU cpu);

        public void CMP_M(CPU cpu);

        public void CMP_A(CPU cpu);

        public void RNZ(CPU cpu);

        public void POP_B(CPU cpu);

        public void JNZ(CPU cpu);

        public void JMP(CPU cpu);

        public void CNZ(CPU cpu);

        public void PUSH_B(CPU cpu);

        public void ADI(CPU cpu);

        public void RST_0(CPU cpu);

        public void RZ(CPU cpu);

        public void RET(CPU cpu);

        public void JZ(CPU cpu);

        public void CZ(CPU cpu);

        public void CALL(CPU cpu);

        public void ACI(CPU cpu);

        public void RST_1(CPU cpu);
    }
}