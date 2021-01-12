using System;
using System.Collections.Generic;
using System.Text;

namespace Turing
{
    class PP
    {
        public Icommands Commands;
        public Memory ActualMemory;

        public PP(Icommands commands, Memory actualMemory)
        {
            Commands = commands;
            ActualMemory = actualMemory;
        }

        public void DoNext()
        {
            switch(Commands.GetNextcommand())
            {
                case "if":
                    if (ActualMemory.GetValueUnderPointer(ActualMemory.GetFirstPointer()) == 0)
                    {
                        Commands.Skip();
                    }
                    break;
                case "move":
                    ActualMemory.MovePointers(Commands.GetParameter());
                    break;
                case "go":
                    Commands.Go(Commands.GetParameter());
                    break;
                case "add":
                    ActualMemory.Add();
                    break;
                case "sub":
                    ActualMemory.Subtract();
                    break;
                case "print":
                    Console.WriteLine(ActualMemory.GetValueUnderPointer(ActualMemory.GetFirstPointer()));
                    break;
                case "exit":
                    Console.WriteLine("Program terminated.");
                    System.Environment.Exit(0);
                    break;
            }
        }
    }
}
