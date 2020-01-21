using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessNote
{
    class ConsoleLogger:Ilogger
    {
        public void Info(string message)
        {
            string info = "INFO ";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(info);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(message);
        }

        public void Error(string message)
        {
            string error = "Error ";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(error);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(message);
        }

        public void UserInput(string message)
        {
            string input = "INPUT";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(input);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(message);
        }
    }
}
