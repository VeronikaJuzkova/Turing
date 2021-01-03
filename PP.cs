using System;
using System.Collections.Generic;
using System.Text;

namespace Turing
{
    class PP
    {
        public IComands Comands;
        public Memory ActualMemory;

        public PP(IComands comands, Memory actualMemory)
        {
            Comands = comands;
            ActualMemory = actualMemory;
        }

        public void doNext()
        {
            switch(Comands.GetNextComand())
            {
                case "if":
                    if (ActualMemory.GetValueUnderPointer(ActualMemory.GetFirstPointer()) == 0)
                    {
                        Comands.Skip();
                    }
                    break;
                case "move":
                    ActualMemory.MovePointers(Comands.GetParameter());
                    break;
                case "go":
                    Comands.Go(Comands.GetParameter());
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
