using Intel8080.Emulator.IO;

namespace Intel8080.TestRoms.IODevices
{
    internal class TestCompletePort : IOutputDevice
    {
        public const int PortNo = 0x00;

        public bool TestComplete { get; set; } = false;

        public void Write(byte data)
        {
            TestComplete = true;
        }
    }
}
