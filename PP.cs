using System;
using System.Collections.Generic;
using System.Text;

namespace Turing
{
    class PP
    {
        public List<string> Comands;
        public int Position = 0;
        public Memory ActualMemory;

        public PP(List<string> comands)
        {
            Comands = comands;
        }

        public void doNext()
        {
            switch(Comands[Position])
            {
                case "if":
                    if (ActualMemory.GetValueAtPosition(ActualMemory.GetFirstPointerValue())==0)
                    {
                        Position = Position + 1;
                    }
                    break;
                case "move":
                    Position = Position + 1;
                    ActualMemory.MovePointers(Int32.Parse(Comands[Position]));
                    break;
                case "go":
                    Position = Int32.Parse(Comands[Position + 1]);
                    break;
                case "add":
                    ActualMemory.Add();
                    break;
                case "print":
                    Console.WriteLine(ActualMemory.GetValueAtPosition(ActualMemory.GetFirstPointerValue()));
                    break;
            }
            Position = Position + 1;
        }
    }
}
