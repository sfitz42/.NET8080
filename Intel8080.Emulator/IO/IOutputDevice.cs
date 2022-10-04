using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel8080.Emulator.IO
{
    public interface IOutputDevice
    {
        public void Write(byte data);
    }
}
