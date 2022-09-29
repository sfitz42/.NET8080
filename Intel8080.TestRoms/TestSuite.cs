using Intel8080.Emulator;
using System;
using System.Collections.Generic;

namespace Intel8080.TestRoms
{
    public class TestSuite
    {
        private readonly CPU _cpu;
        private readonly MainMemory _memory;
        private bool _testFinished = false;

        private readonly List<string> _testRoms = new List<string>()
        {
            "../../../Roms/TST8080.COM",
            "../../../Roms/CPUTEST.COM",
            "../../../Roms/8080PRE.COM",
            "../../../Roms/8080EXM.COM"
        };

        public TestSuite()
        {
            _memory = new MainMemory(0x10000);
            _cpu = new CPU(_memory, 2);

            _cpu.Ports[0].In = () => 0;
            _cpu.Ports[0].Out = Port_0_Out;

            _cpu.Ports[1].In = () => 0;
            _cpu.Ports[1].Out = Port_1_Out;
        }

        public void RunTests()
        {
            foreach (var rom in _testRoms)
            {
                _cpu.Reset();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Starting test: {rom}");
                Console.ForegroundColor = ConsoleColor.White;

                _memory.LoadRom(rom, 0x0100);

                RunTest();

                Console.WriteLine();
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All tests completed.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void RunTest()
        {
            _testFinished = false;

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

        private void Port_0_Out(byte data)
        {
            _testFinished = true;
        }

        private void Port_1_Out(byte data)
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
