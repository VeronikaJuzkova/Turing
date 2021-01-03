using System;
using System.Collections.Generic;
using System.Text;

namespace Turing
{
    class InteractiveComands : IComands
    {
        List<string> existingComands = new List<string> { "if", "move", "go", "add", "sub", "print" };
        public InteractiveComands() { }

        public string GetNextComand()
        {
            Console.WriteLine("Write comand.");
            string actualComand = Console.ReadLine();
            while (!existingComands.Contains(actualComand))
            {
                Console.WriteLine("Please write an existing comand.");
                actualComand = Console.ReadLine();
            }
            return actualComand;
        }

        public int GetParameter()
        {
            Console.WriteLine("Write parameter.");
            while (true)
            {
                try
                {
                    return Int32.Parse(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Parameter must be a natural number");
                }

            }
        }

        public void Go(int where)
        {
            Console.WriteLine("You cannot use that keyword in an iteractive mode.");
        }

        public void Skip()
        {
            Console.WriteLine("Write comand.");
        }
    }
}
