using System;

namespace ProcessNote
{
    class Program
    {
        static ConsoleLogger cl = new ConsoleLogger();
        static void Main(string[] args)
        {
            MenuHandler menu = new MenuHandler(cl);
            menu.StartMenu();
            

        }
    }
}
