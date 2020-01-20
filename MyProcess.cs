using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ProcessNote
{
    public class MyProcess
    {
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
