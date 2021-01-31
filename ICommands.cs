using System;
using System.Collections.Generic;
using System.Text;

namespace Turing
{
    interface ICommands
    {
        string GetNextCommand();

        int GetParameter();

        void Go(int where);

        void Skip();
    }
}
