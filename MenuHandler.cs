using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ProcessNote
{
    class MenuHandler
    {
        private Ilogger MhLogger;
        public MenuHandler(Ilogger logger)
        {
            MhLogger = logger;
        }

        public void StartMenu()
        {
            Console.Clear();
            while (true)
            {
                string menu =
                "1 - Working with currently running processes\n" +
                "2 - Working from XML\n" +
                "3 - Exit programme";
                Console.WriteLine(menu);
                Console.Write("Enter a number to navigate the menu: ");
                int userChocie = int.Parse(Console.ReadLine());

                switch (userChocie)
                {
                    case 1:
                        MenuRunningProcess();
                        break;
                    case 2:
                        MenuWithXML();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default: throw new ArgumentException("This is an invalid argument");
                }
            }
        }
        public void MenuRunningProcess()
        {
            Console.Clear();
            ProcessHandler processhandler = new ProcessHandler(MhLogger);
            while (true)
            {
                string menu =
                "1 - List all running processes\n" +
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
                        Serializer.SerializeProcess(processhandler.allMyProcess);
                        break;
                    case 2:
                        processhandler.SearchById();
                        break;
                    case 3:
                        processhandler.CommentAProcess();
                        break;
                    case 4:
                        Serializer.SaveData(processhandler);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public void MenuWithXML()
        {
            Console.Clear();
            MhLogger.Info("You are now working with offline!");
            ProcessHandler processhandler = new ProcessHandler(MhLogger);

            Serializer.DeserializerProcess(processhandler);
            while (true)
            {
                string menu =
                "1 - List all processes from XML\n" +
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
                        foreach(MyProcess myProcess in processhandler.allMyProcess)
                        {
                            MhLogger.Info(myProcess.ToString());
                        }
                        break;
                    case 2:
                        processhandler.SearchById();
                        break;
                    case 3:
                        processhandler.CommentAProcess();
                        break;
                    case 4:
                        Serializer.SaveData(processhandler);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default: throw new ArgumentException("This is an invalid argument");
                }
            }
        }
    }
}
