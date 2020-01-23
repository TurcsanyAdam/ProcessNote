using System;
using System.Collections.Generic;
using System.Text;


namespace ProcessNote_DLL
{
    public interface Ilogger
    {
        void Info(string message);

        void Error(string message);
        void UserInput(string message);
    }
}
