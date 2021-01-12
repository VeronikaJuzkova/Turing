using System;
using System.Collections.Generic;
using System.Text;

namespace Turing
{
    interface Icommands
    {
        string GetNextcommand();

        int GetParameter();

        void Go(int where);

        void Skip();
    }
}
