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
            bool userInputId = Int32.TryParse(Console.ReadLine(), out int inputId);

            if (userInputId)
            {
                var confirmprocess = allMyProcess.Where(process => process.ItemId == inputId);
                processLogger.UserInput("Give me the comment : ");
                string comment = Console.ReadLine();
                foreach (var element in confirmprocess)
                {
                    element.Comment = comment;
                }
            }
            else
            {
                throw new ArgumentException("Invalid argument");
            }
        }

        public Process SearchById()
        {
            processLogger.Info("Give me the Id: ");
            bool searchedIdBool = Int32.TryParse(Console.ReadLine(), out int searchedId );
            if (searchedIdBool)
            {
                Process searchedProcess = Process.GetProcessById(searchedId);
                processLogger.Info($" ID = {searchedProcess.Id}" +
                                   $" Name = {searchedProcess.ProcessName}" +
                                   $" Cpu Usage = {searchedProcess.TotalProcessorTime.TotalMilliseconds}" +
                                   $" Memory usage = {searchedProcess.WorkingSet64 / 1024}Kb" +
                                   $" Running Time = { searchedProcess.UserProcessorTime.TotalMilliseconds}" +
                                   $" Start Time = {searchedProcess.StartTime}" +
                                   $" Thread(s) = {searchedProcess.Threads.Count}");
                return searchedProcess;
            }
            else
            {
                throw new ArgumentException("Invalid argument");
            }
        }


    
    }
}
