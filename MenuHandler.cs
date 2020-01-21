using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ProcessNote
{
    class MenuHandler
    {
        private Ilogger MhLogger;
        private List<MyProcess> allprocess;

        public MenuHandler(Ilogger logger)
        {
            MhLogger = logger;
        }
        public void Menu()
        {

            ProcessHandler processhandler = new ProcessHandler(MhLogger);
            while (true)
            {
                string menu =
                "\n1 - List all running processes\n" +
                "2 - Searh process by PID\n" +
                "3 - Comment process by PID\n" +
                "4 - Save all info to XML\n" +
                "5 - Exit programme";
                Console.WriteLine(menu);
                Console.Write("Enter a number to navigate the menu: ");
                int userChocie = int.Parse(Console.ReadLine());

                switch (userChocie)
                {
                    case 1:
                        processhandler.ListProcess();
                        break;
                    case 2:
                        processhandler.SearchById();
                        break;
                    case 3:
                        Process myProcess = processhandler.SearchById();
                        Console.Write("Enter your comment here: ");
                        string comment = Console.ReadLine();
                        processhandler.MakeProcessObject(myProcess, comment);
                        break;
                    case 4:
                        XmlHandler.WriteToXml();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
