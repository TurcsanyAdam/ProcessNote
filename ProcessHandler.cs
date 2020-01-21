using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;


namespace ProcessNote
{
    class ProcessHandler
    {
        private Ilogger processLogger;
        public List<MyProcess> allMyProcess = new List<MyProcess>();
        public ProcessHandler(Ilogger ProcessLogger)
        {
            processLogger = ProcessLogger;
        }

        public void ListProcess()
        {
            Process[] localAll = Process.GetProcesses();
            foreach (Process item in localAll)
            {
                if (item.Id != 0)
                {
                    processLogger.Info($"id = {item.Id} Name = {item.ProcessName}");
                    MyProcess myprocess = new MyProcess(item.Id, item.ProcessName, item.TotalProcessorTime, item.WorkingSet64
                                                , item.UserProcessorTime, item.StartTime, item.Threads.Count, "");
                    allMyProcess.Add(myprocess);
                }
            }
        }
        public void CommentAProcess()
        {
            processLogger.UserInput("Give me the process Id you want to comment : ");
            int userInputId = Convert.ToInt32(Console.ReadLine());
            var confirmprocess = allMyProcess.Where(process => process.ItemId == userInputId);
            processLogger.UserInput("Give me the comment : ");
            string comment = Console.ReadLine();
            foreach( var element in confirmprocess)
            {
                element.Comment = comment;
            }
        }

        public Process SearchById()
        {
            processLogger.Info("Give me the Id: ");
            int searchedId = Convert.ToInt32(Console.ReadLine());
            Process searchedProcess = Process.GetProcessById(searchedId);
            processLogger.Info($" ID = {searchedProcess.Id} Name = {searchedProcess.ProcessName}");
            return searchedProcess;
        }


    
    }
}
