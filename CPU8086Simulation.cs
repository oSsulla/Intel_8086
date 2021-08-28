using System;
using System.Collections.Generic;

namespace Procesor_Intel_8086_3
{
    public class CPU8086Simulation
    {
        List<Register> registers = new List<Register>();

        bool changed = true;
        bool run = false;

        public void Run()
        {
            registers = new List<Register>() {
                new Register("A"),
                new Register("B"),
                new Register("C"),
                new Register("D"),
            };

            run = true;

            while (run)
            {
                if (changed)
                {
                    DisplayRegisters();
                    changed = false;
                }

                Console.WriteLine();
                Console.Write("> ");
                string[] input = Console.ReadLine().Trim().Split(" ");
                Console.WriteLine();
                changed = true;

                try
                {
                    run = HandleInput(input);
                } catch (Exception ex)
                {
                    DisplayError(ex.Message);
                    changed = false;
                }
            }
        }

        private bool HandleInput(string[] input)
        {
            switch (input[0].ToLower().Trim())
            {
                case "exit":
                    return false;
                case "set":
                    Set(input);
                    break;
                case "move":
                    Move(input);
                    break;
                case "xchg":
                    Swap(input);
                    break;
                case "reset":
                    foreach(var r in registers)
                        r.Reset();
                    break;
                case "random":
                    foreach (var r in registers)
                        r.Random();
                    break;
                default:
                    throw new ArgumentException($"There is no command: \"{input[0]}\"");
            }
            return true;
        }

        private void Swap(string[] input)
        {
            RequireArguments(input, 2);
            IRegister registerA = GetRegister(input[1]);
            IRegister registerB = GetRegister(input[2]);
            CheckRegisterComatibility(registerA, registerB);

            registerA.Swap(registerB);
        }

        private void Move(string[] input)
        {
            RequireArguments(input, 2);
            IRegister registerA = GetRegister(input[1]);
            IRegister registerB = GetRegister(input[2]);
            CheckRegisterComatibility(registerA, registerB);

            registerA.Move(registerB);
        }

        private void Set(string[] input)
        {
            RequireArguments(input, 2);
            IRegister register = GetRegister(input[1]);
            register.CheckValue(input[2]);
            register.Value = input[2];
        }

        private void RequireArguments(string[] input, int i)
        {
            if(input.Length < i + 1)
            {
                throw new ArgumentException($"Too few arguments! ({i} at least arguments are expected)");
            }
        }

        private void CheckRegisterComatibility(IRegister a, IRegister b)
        {
            if ((a is not Register || b is not Register) && (a is not SubRegister || b is not SubRegister))
            {
                throw new ArgumentException($"Chosen registers are not of the same length!");
            }
        }

        private IRegister GetRegister(string name)
        {
            foreach(var register in registers)
            {
                if (register.Name.ToLower() == name.ToLower())
                    return register;
                if (register.LowRegister.Name.ToLower() == name.ToLower())
                    return register.LowRegister;
                if (register.HighRegister.Name.ToLower() == name.ToLower())
                    return register.HighRegister;
            }

            throw new ArgumentException($"There is no register called {name}");
        }

        private void DisplayRegisters()
        {
            foreach(Register register in registers)
            {
                Console.WriteLine($"{register.Name}: {register.Value}  #  {register.HighRegister.Name}: {register.HighRegister.Value}  {register.LowRegister.Name}: {register.LowRegister.Value}");
            }
            Console.WriteLine();
        }

        private void DisplayError(string message)
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {message}");
            Console.ForegroundColor = color;
        }
    }
}
