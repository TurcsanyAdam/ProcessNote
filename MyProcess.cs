using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ProcessNote
{
    public class MyProcess
    {
        public static void GetRunningProcesses()
        {
            Process[] localAll = Process.GetProcesses();
            foreach (Process item in localAll)
            {
                Console.WriteLine(item);
            }

        }
    }
}
