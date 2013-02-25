using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace networking2
{
    interface IProgressContext
    {
        void UpdateProgress(double progress);
        void UpdateStatus(string status);
        void Finish();
        bool Canceled { get; }
    }
}
