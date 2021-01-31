using System;
using System.Collections.Generic;
using System.Text;

namespace Turing
{
    class ListCommands : ICommands 
    {
        public List<string> Content;
        public int Position;

        public ListCommands(List<string> content)
        {
            Content = content;
            Position = 0;
        }

        public string GetNextCommand()
        {
            string tbr = Content[Position];
            Position++;
            return tbr;
        }

        public int GetParameter()
        {
            string stringParameter = Content[Position];
            if (stringParameter == "print")
            {
                Position++;
                return -1;
            }
            int intParameter = Int32.Parse(stringParameter);
            Position++;
            return intParameter;
        }

        public void Go(int where)
        {
            Position = where;
        }

        public void Skip()
        {
            Position += 1;
        }
    }
}
