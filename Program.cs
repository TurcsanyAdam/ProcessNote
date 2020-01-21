using System;

namespace ProcessNote
{
    class Program
    {
        static ConsoleLogger cl = new ConsoleLogger();
        static void Main(string[] args)
        {
            try
            {
                MenuHandler menu = new MenuHandler(cl);
                menu.StartMenu();
            }
            catch(Exception ex)
            {
                cl.Error(ex.Message);
            }
            

        }
    }
}
