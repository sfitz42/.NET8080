using Intel8080.Emulator;
using Intel8080.TestRoms.IODevices;
using System;
using System.Collections.Generic;

namespace Intel8080.TestRoms
{
    public class TestSuite
    {
        private readonly CPU _cpu;
        private readonly MainMemory _memory;
        private readonly TestCompletePort _testCompletePort;
        private readonly TestOutputPort _textOutputPort;

        private readonly List<string> _testRoms = new List<string>()
        {
            "Roms/TST8080.COM",
            "Roms/CPUTEST.COM",
            "Roms/8080PRE.COM",
            "Roms/8080EXM.COM"
        };

        public TestSuite()
        {
            _memory = new MainMemory(0x10000);
            _cpu = new CPU(_memory);

            _testCompletePort = new TestCompletePort();
            _textOutputPort = new TestOutputPort(_cpu);

            _cpu.IOController.AddDevice(_testCompletePort, TestCompletePort.PortNo);
            _cpu.IOController.AddDevice(_textOutputPort, TestOutputPort.PortNo);
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
            _testCompletePort.TestComplete = false;

            _cpu.Registers.PC = 0x100;

            _memory[0x0000] = 0xD3;
            _memory[0x0001] = 0x00;

            _memory[0x0005] = 0xD3;
            _memory[0x0006] = 0x01;
            _memory[0x0007] = 0xC9;

            while (!_testCompletePort.TestComplete)
            {
                _cpu.Step();
            }
        }
    }
}
