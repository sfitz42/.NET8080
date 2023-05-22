namespace Intel8080.Emulator;

public class State
{
    public byte[] Memory { get; }

    public Registers Registers { get; } = new();

    public byte Flags { get; }

    public long Cycles { get; }

    public bool Halted { get; }

    public bool InterruptEnabled { get; }

    public State(CPU cpu)
    {
        Memory = cpu.Memory.Copy();

        Registers.A = cpu.Registers.A;
        Registers.BC = cpu.Registers.BC;
        Registers.DE = cpu.Registers.DE;
        Registers.HL = cpu.Registers.HL;
        Registers.PC = cpu.Registers.PC;
        Registers.SP = cpu.Registers.SP;

        Flags = cpu.Flags.F;

        Cycles = cpu.Cycles;
        Halted = cpu.Halted;
        InterruptEnabled = cpu.InterruptEnabled;
    }
}