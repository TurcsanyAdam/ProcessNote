using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ProcessNote
{
    public class MyProcess
    {
        public int ItemId { get; private set; }
        public long CpuUsage { get; private set; }
        public long MemoryUsage { get; private set; }
        public TimeSpan RunnigTime { get; private set; }
        public DateTime StartTime { get; private set; }
        public int ThreadCount { get; private set; }

        private Ilogger logger;

        public MyProcess(int aItemId,long aCpuUsage, long aMemoryUsage, TimeSpan aRunningTime, DateTime aStartTime, int aThreadCount, Ilogger logger)
        {
            ItemId = aItemId;
            CpuUsage = aCpuUsage;
            MemoryUsage = aMemoryUsage;
            RunnigTime = aRunningTime;
            StartTime = aStartTime;
            ThreadCount = aThreadCount;
            this.logger = logger;
        }


        //item.Id
        //WorkingSet64
        //StartTime
        //TotalProcessorTime
        //ProcessName
        public static void GetRunningProcesses()
        {
            Process[] localAll = Process.GetProcesses();
            foreach (Process item in localAll)
            {
                
                Console.WriteLine( item.Id + " " + item.ProcessName + " " + (item.WorkingSet64 / 1048576) );
                
            }
            Console.WriteLine("Choose a process id: ");
            int procesid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Process.GetProcessById(procesid).ProcessName);



        }


    }
}
