

using System;

namespace Procesor_Intel_8086_3
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("8086 Intel Symulator");
            Console.WriteLine();
            Console.WriteLine(" Commands: ");
            Console.WriteLine("   exit");
            Console.WriteLine("   reset");
            Console.WriteLine("   random");
            Console.WriteLine("   set <register> <value>");
            Console.WriteLine("   xchg <register> <register>");
            Console.WriteLine("   move <register> <register>");
            Console.WriteLine();
            Console.WriteLine();

            CPU8086Simulation simulation = new CPU8086Simulation();
            simulation.Run();
        }
    }
}
