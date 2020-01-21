using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace ProcessNote
{
    [Serializable()]
    public class MyProcess: ISerializable
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

        public  MyProcess()
        {

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Item ID", ItemId);
            info.AddValue("Item Name", ItemName);
            info.AddValue("Cpu Usage", CpuUsage);
            info.AddValue("Memory Usage", MemoryUsage);
            info.AddValue("Running Time", RunnigTime);
            info.AddValue("Start Time", StartTime);
            info.AddValue("Thread Count", ThreadCount);
            info.AddValue("Comment", Comment);
        }

        public MyProcess(SerializationInfo info, StreamingContext context)
        {
            ItemId = (int)info.GetValue("Item ID", typeof(int));
            ItemName = (string)info.GetValue("Item Name", typeof(string));
            CpuUsage = (TimeSpan)info.GetValue("Cpu Usage", typeof(TimeSpan));
            MemoryUsage = (long)info.GetValue("Memory Usage", typeof(long));
            RunnigTime = (TimeSpan)info.GetValue("Running Time", typeof(TimeSpan));
            StartTime = (DateTime)info.GetValue("Start Time", typeof(DateTime));
            ThreadCount = (int)info.GetValue("Thread Count", typeof(int));
            Comment = (string)info.GetValue("Comment", typeof(string));

        }
    }


    
}
