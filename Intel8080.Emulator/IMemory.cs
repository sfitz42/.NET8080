namespace Intel8080.Emulator
{
    public interface IMemory
    {
        byte this[int index] { get; set; }

        byte[] Copy();
    }
}