using System;
using System.Collections.Generic;

namespace Turing
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello World!");
            Pointer u1 = new Pointer(0);
            Pointer u2 = new Pointer(0);
            Pointer u3 = new Pointer(0);
            Memory mem = new Memory(new List<int> { 1, 1, 1, 1, 1, 1 }, new List<Pointer> { u1, u2 });
            //Listcommands actualcommands = new Listcommands(new List<string> { "add", "add", "move", "3", "add", "move", "5", "add", "sub", "exit" });
            //Filecommands actualcommands = new Filecommands("C:/Users/veron/OneDrive/Plocha/Škola/Ročníkové práce/Turingův stroj/Turing/Turing/InsertProgramHere.txt");
            PP pp = new PP(actualcommands, mem);
            mem.Print();

            while (true)
            {
                pp.DoNext();
                Console.WriteLine(mem.Print());
            }*/

            Interactivecommands actualcommands = new Interactivecommands();
        }
    }
}
