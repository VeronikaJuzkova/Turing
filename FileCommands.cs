using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Turing
{
    class FileCommands : ICommands
    {
        private readonly string Path;
        public String[] Content;
        public int Position;

        public FileCommands(string path)
        {
            Path = path;
            using (StreamReader sr = File.OpenText(Path))
            {
                string a = sr.ReadToEnd();
                Content = a.Split("\r\n");
            }
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
