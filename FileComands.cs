using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Turing
{
    class FileComands : IComands
    {
        public String[] Content;
        public int Position;

        public FileComands()
        {
            using (StreamReader sr = File.OpenText(@"C:\Users\veron\OneDrive\Plocha\Škola\Ročníkové práce\Turingův stroj\Turing\Turing\InsertProgramHere.txt"))
            {
                string a = sr.ReadToEnd();
                Content = a.Split("\r\n");
            }
        }

        public string GetNextComand()
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
