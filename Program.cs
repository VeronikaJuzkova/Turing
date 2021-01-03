using System;
using System.Collections.Generic;

namespace Turing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Pointer u1 = new Pointer(0);
            Pointer u2 = new Pointer(0);
            Pointer u3 = new Pointer(0);
            Memory mem = new Memory(new List<int> { 1, 1, 1, 1, 1, 1 }, new List<Pointer> { u1, u2 });
            //ListComands actualComands = new ListComands(new List<string> { "add", "add", "move", "3", "add", "move", "5", "add", "sub", "exit" });
            FileComands actualComands = new FileComands();
            PP pp = new PP(actualComands, mem);
            mem.PrintForDebuging();

            while (true)
            {
                pp.doNext();
                mem.PrintForDebuging();
            }
        }
    }
}
