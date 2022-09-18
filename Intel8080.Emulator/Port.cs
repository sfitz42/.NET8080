using System;

namespace Intel8080.Emulator
{
    public class Port
    {
        public Func<byte> In = null!;
        
        public Action<byte> Out = null!;
    }
}