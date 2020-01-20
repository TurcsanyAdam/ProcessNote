using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessNote
{
    interface Ilogger
    {
        public void Info(string message);

        public void Error(string message);
    }
}
