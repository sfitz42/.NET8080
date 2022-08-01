namespace Intel8080.Emulator
{
    public interface IMemory
    {
        public byte this[int index] { get; set; }
    }
}