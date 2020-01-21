﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;


namespace ProcessNote
{
    class ProcessHandler
    {
        private Ilogger processLogger;

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
                }
            }
        }
        public MyProcess MakeProcessObject(Process process,string comment)
        {
            MyProcess myprocess = new MyProcess(process.Id, process.ProcessName, process.TotalProcessorTime, process.WorkingSet64
                                                , process.UserProcessorTime, process.StartTime, process.Threads.Count, comment);
            return myprocess;
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
