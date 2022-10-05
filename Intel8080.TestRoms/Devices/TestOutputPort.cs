using Intel8080.Emulator;
using Intel8080.Emulator.IO;
using System;

namespace Intel8080.TestRoms.IODevices
{
    internal class TestOutputPort : IOutputDevice
    {
        public const int PortNo = 0x01;

        private readonly CPU _cpu;

        public TestOutputPort(CPU cpu)
        {
            _cpu = cpu;
        }

        public void Write(byte data)
        {
            byte operation = _cpu.Registers.C;

            if (operation == 2)
            {
                char c = (char)_cpu.Registers.E;

                Console.Write(c);
            }
            else if (operation == 9)
            {
                ushort addr = (ushort)((_cpu.Registers.D << 8) | _cpu.Registers.E);
                do
                {
                    Console.Write((char)_cpu.Memory[addr++]);
                } while (_cpu.Memory[addr] != '$');
            }
        }
    }
}
