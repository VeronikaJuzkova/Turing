using System;
using System.Collections.Generic;
using System.Text;

namespace Turing
{
    class InteractiveProgram
    {
        static void main(string[] args)
        {
            // Getting starting parameters
            Console.WriteLine("Hello!");
            Console.WriteLine("How many pointers would you like to use?");
            int NumberOfPointers = -1;
            while (NumberOfPointers <= 0)
            {
                try
                {
                    NumberOfPointers = Int32.Parse(Console.ReadLine());
                    if (NumberOfPointers <= 0)
                    {
                        Console.WriteLine("The count of pointers must be a natural number.");
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("The count of pointers must be a natural number.");
                }
            }

            Console.WriteLine("How many cells do you want to have in memory?");
            int MemorySize = -1;
            while (MemorySize <= 0)
            {
                try
                {
                    MemorySize = Int32.Parse(Console.ReadLine());
                    if (MemorySize <= 0)
                    {
                        Console.WriteLine("The count of cells in the memory must be a natural number.");
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("The count of cells in the memory must be a natural number.");
                }
            }


            // Creating memory
            List<Pointer> actualPointers = new List<Pointer>();
            for (int i = 0; i < NumberOfPointers; i++)
            {
                actualPointers.Add(new Pointer(0));
            }
            List<int> actualCells = new List<int>();
            for (int i = 0; i < MemorySize; i++)
            {
                actualCells.Add(1);
            }
            Memory actualMemory = new Memory(actualCells, actualPointers);

            InteractiveComands actualComands = new InteractiveComands();

            PP actualPP = new PP(actualComands, actualMemory);

            while (true)
            {
                actualPP.doNext();
            }
        }
    }
}
