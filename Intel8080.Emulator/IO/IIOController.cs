using System.Collections;
using System.Collections.Generic;

namespace Intel8080.Emulator.IO
{
    public interface IIOController
    {
        public void AddDevice(IInputDevice device, byte port);

        public void AddDevice(IOutputDevice device, byte port);

        public IInputDevice GetInputDevice(byte port);

        public IOutputDevice GetOutputDevice(byte port);
    }
}
