using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Turing
{
    class Filecommands : Icommands
    {
        private readonly string Path;
        public String[] Content;
        public int Position;

        public Filecommands(string path)
        {
            Path = path;
            using (StreamReader sr = File.OpenText(Path))
            {
                string a = sr.ReadToEnd();
                Content = a.Split("\r\n");
            }
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
