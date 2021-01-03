using System;
using System.Collections.Generic;
using System.Text;

namespace Turing
{
    interface IComands
    {
        string GetNextComand();

        int GetParameter();

        void Go(int where);

        void Skip();
    }
}
