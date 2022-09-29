using System;
using System.IO;
using Intel8080.Emulator;

namespace Intel8080.TestRoms
{
    class Program
    {
        private static CPU _cpu;
        private static MainMemory _memory;

        private static bool _testFinished = false;

        static void Main(string[] args)
        {
            _memory = new MainMemory(0x10000);
            _cpu = new CPU(_memory, 2);

            _cpu.Ports[0].In = () => 0;
            _cpu.Ports[0].Out = Port_0_Out;

            _cpu.Ports[1].In = () => 0;
            _cpu.Ports[1].Out = Port_1_Out;

            _memory.LoadRom("Roms/TST8080.COM", 0x100);

            _cpu.Registers.PC = 0x100;

            _memory[0x0000] = 0xD3;
            _memory[0x0001] = 0x00;

            _memory[0x0005] = 0xD3;
            _memory[0x0006] = 0x01;
            _memory[0x0007] = 0xC9;

            while (!_testFinished)
            {
                _cpu.Step();
            }
        }

        static void Port_0_Out(byte data)
        {
            _testFinished = true;
        }

        static void Port_1_Out(byte data)
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
                    Console.Write((char)_memory[addr++]);
                } while (_memory[addr] != '$');
            }
        }
    }
}
