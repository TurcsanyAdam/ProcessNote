using System;
using System.Collections.Generic;

using System.Text;

namespace ProcessNote
{
    public class MyProcess
    {
        public int ItemId { get; private set; }
        public string ItemName { get; private set; }
        public TimeSpan CpuUsage { get; private set; }
        public long MemoryUsage { get; private set; }
        public TimeSpan RunnigTime { get; private set; }
        public DateTime StartTime { get; private set; }
        public int ThreadCount { get; private set; }
        public string Comment { get; set; }
        

        public MyProcess(int aItemId, string Name, TimeSpan aCpuUsage, long aMemoryUsage, TimeSpan aRunningTime, DateTime aStartTime, int aThreadCount, string Comment)
        {
            ItemId = aItemId;
            ItemName = Name;
            CpuUsage = aCpuUsage;
            MemoryUsage = aMemoryUsage;
            RunnigTime = aRunningTime;
            StartTime = aStartTime;
            ThreadCount = aThreadCount;
            this.Comment = Comment;

        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"id = {ItemId}, Name = {ItemName}, Cpu Usage = {CpuUsage.TotalMilliseconds}, Memory usage = {MemoryUsage / 1024}Kb," +
                      $"Running Time = { RunnigTime.TotalMilliseconds}, Start Time = {StartTime}, Thread(s) = {ThreadCount}");
            return sb.ToString();
        }



    }


    
}
