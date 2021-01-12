using System;
using System.Collections.Generic;
using System.Text;

namespace Turing
{
    class Listcommands : Icommands 
    {
        public List<string> Content;
        public int Position;

        public Listcommands(List<string> content)
        {
            Content = content;
            Position = 0;
        }

        public string GetNextcommand()
        {
            string tbr = Content[Position];
            Position++;
            return tbr;
        }

        public int GetParameter()
        {
            int tbr = Int32.Parse(Content[Position]);
            Position++;
            return tbr;
        }

        public void Go(int where)
        {
            Position = where;
        }

        public void Skip()
        {
            Position = Position + 1;
        }
    }
}
