using System;
using System.Collections.Generic;
using System.Text;

namespace Turing
{
    class Interactivecommands : Icommands
    {
        readonly List<string> existingcommands = new List<string> { "if", "move", "go", "add", "sub", "print", "exit", "help" };
        public Interactivecommands()
        {
            // Getting starting parameters
            Console.WriteLine("Hello!");
            WriteInstruction("How many pointers would you like to use?");
            int NumberOfPointers = -1;
            while (NumberOfPointers <= 0)
            {
                try
                {
                    NumberOfPointers = Int32.Parse(ReadInput());
                    if (NumberOfPointers <= 0)
                    {
                        WriteWarning("The count of pointers must be a natural number.");
                        WriteInstruction("How many pointers would you like to use?");
                    }
                }
                catch (System.FormatException)
                {
                    WriteWarning("The count of pointers must be a natural number.");
                    WriteInstruction("How many pointers would you like to use?");
                }
            }

            WriteInstruction("How many cells do you want to have in memory?");
            int MemorySize = -1;
            while (MemorySize <= 0)
            {
                try
                {
                    MemorySize = Int32.Parse(ReadInput());
                    if (MemorySize <= 0)
                    {
                        WriteWarning("The count of cells in the memory must be a natural number.");
                        WriteInstruction("How many cells do you want to have in memory?");
                    }
                }
                catch (System.FormatException)
                {
                    WriteWarning("The count of cells in the memory must be a natural number.");
                    WriteInstruction("How many cells do you want to have in memory?");
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

            PP actualPP = new PP(this, actualMemory);

            // running
            while (true)
            {
                WriteState(actualMemory.Print());
                actualPP.DoNext();
            }
        }

        public string? GetNextcommand()
        {
            WriteInstruction("Write command.");
            string actualcommand = ReadInput();
            while (!existingcommands.Contains(actualcommand))
            {
                WriteWarning("Please write an existing command.");
                WriteInfo("Existing commands are: if, move, go, add, sub, print, exit and help.");
                actualcommand = ReadInput();
            }
            if (actualcommand == "help")
            {
                Help();
                return null;
            }
            return actualcommand;
        }

        public int GetParameter()
        {
            WriteInstruction("Write parameter.");
            while (true)
            {
                try
                {
                    int tbr =  Int32.Parse(ReadInput());
                }
                catch (System.FormatException)
                {
                    WriteWarning("Parameter must be a natural number");
                    WriteInstruction("Write parameter.");
                }

            }
        }

        public void Go(int where)
        {
            WriteWarning("You cannot use that keyword in an iteractive mode.");
        }

        public void Skip()
        {
            WriteInstruction("Write command.");
        }

        private void Help()
        {
            WriteInfo("Type name of the command you need to help with and I will tell you what it does.");
            WriteInfo("Existing commands are: if, move, go, add, sub, print, exit and help.");
            string actualCommand = ReadInput();
            switch (actualCommand)
            {
                case "if":
                    WriteInfo("When you use this command, program will skip the next given command, if the value under the first pointer is zero.");
                    break;
                case "move":
                    WriteInfo("This command will move first poiter to the place, you will specify in the parameter.");
                    WriteInfo("Second poiter will move to the position, where used to be first pointer. Third pointer will move to the position, where used to be secon poiter ect.");
                    break;
                case "go":
                    WriteInfo("This command will make the program continue from specified position.");
                    WriteInfo("Unfortunately it is not possible to use this function in iteractive mode.");
                    break;
                case "add":
                    WriteInfo("This command will sum values under all pointers and will write the result to the cell under the first poiter.");
                    break;
                case "sub":
                    WriteInfo("This command will take values under every pointer except the first one and will subtract it from the value under the first pointer.");
                    break;
                case "print":
                    WriteInfo("This command will print the value under the first pointer on standard output.");
                    break;
                case "exit":
                    WriteInfo("This command will end the program.");
                    break;
            }

            while (true)
            {
                WriteInstruction("Do you need to help with any other command?");
                string actualAnswer = ReadInput();
                if (actualAnswer == "yes")
                {
                    Help();
                    break;
                }
                else if (actualAnswer == "no")
                {
                    break;
                }
                else
                {
                    WriteWarning("Please answer 'yes' or 'no'.");
                }
            }
        }

        private void WriteInstruction(string instruction)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(instruction);
        }

        private void WriteWarning(string warning)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(warning);
        }

        private void WriteInfo(string info)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(info);
        }

        private void WriteState(string state)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(state);
        }

        private string ReadInput()
        {
            Console.ForegroundColor = ConsoleColor.White;
            string tbr = Console.ReadLine().ToLower();
            Console.WriteLine();
            return tbr;
        }
    }
}
