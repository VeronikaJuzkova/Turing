using System;
using System.Collections.Generic;
using System.Text;

namespace Turing
{
    class Head
    {
        public ICommands Commands;
        public Memory ActualMemory;
        private bool PrintState;

        public Head(ICommands commands, Memory actualMemory, bool printState)
        {
            Commands = commands;
            ActualMemory = actualMemory;
            PrintState = printState;
        }

        public void DoNext()
        {
            string actualCommand = Commands.GetNextCommand();
            switch (actualCommand)
            {
                case "if":
                    if (ActualMemory.GetValueUnderPointer(ActualMemory.GetFirstPointer()) == 0)
                    {
                        Commands.Skip();
                    }
                    break;
                case "move":
                    int moveParameter = Commands.GetParameter();
                    if (moveParameter == -1)
                    {
                        moveParameter = ActualMemory.GetValueUnderPointer(ActualMemory.GetFirstPointer());
                    }
                    ActualMemory.MovePointers(moveParameter);
                    break;
                case "go":
                    int goParameter = Commands.GetParameter();
                    if (goParameter == -1)
                    {
                        goParameter = ActualMemory.GetValueUnderPointer(ActualMemory.GetFirstPointer());
                    }
                    Commands.Go(goParameter);
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
                    if (PrintState)
                    {
                        Console.WriteLine("Program terminated.");
                    }
                    System.Environment.Exit(0);
                    break;
            }
            if (PrintState)
            {
                Console.WriteLine(actualCommand);
                Console.WriteLine(ActualMemory.ToString());
            }
        }
    }
}
