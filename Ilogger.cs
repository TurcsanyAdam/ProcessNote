using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessNote
{
    interface Ilogger
    {
        void Info(string message);

        void Error(string message);
    }
}
