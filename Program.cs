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
            Memory mem = new Memory(new List<int> { 0, 0, 0, 1, 0, 0 }, new List<Pointer> { u1, u2 });
            PP pp = new PP(new List<string> { "add", "add", "move", "3","add","move","5","add"});
            pp.ActualMemory = mem;
            mem.PrintForDebuging();

            foreach (string el in pp.Comands)
            {
                pp.doNext();
                mem.PrintForDebuging();
            }
                
        }
    }
}
