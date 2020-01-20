using System;

namespace ProcessNote
{
    class Program
    {
        static ConsoleLogger cl = new ConsoleLogger();
        static void Main(string[] args)
        {
            ProcessHandler Ph = new ProcessHandler(cl);
            Ph.ListProcess();
            

        }
    }
}
