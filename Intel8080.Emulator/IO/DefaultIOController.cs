using System.Collections.Generic;

namespace Intel8080.Emulator.IO
{
    internal class DefaultIOController : IIOController
    {
        private readonly Dictionary<byte, IInputDevice> _inputDevices;
        private readonly Dictionary<byte, IOutputDevice> _outputDevices;

        public DefaultIOController()
        {
            _inputDevices = new Dictionary<byte, IInputDevice>();
            _outputDevices = new Dictionary<byte, IOutputDevice>();
        }

        public void AddDevice(IInputDevice device, byte port)
        {
            _inputDevices[port] = device;
        }

        public void AddDevice(IOutputDevice device, byte port)
        {
            _outputDevices[port] = device;
        }

        public IInputDevice GetInputDevice(byte port)
        {
            return _inputDevices[port];
        }

        public IOutputDevice GetOutputDevice(byte port)
        {
            return _outputDevices[port];
        }
    }
}
