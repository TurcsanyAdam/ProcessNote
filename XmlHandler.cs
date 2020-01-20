using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Diagnostics;

namespace ProcessNote
{
    public class XmlHandler
    {
        public static void WriteToXml()
        {
            Process[] localAll = Process.GetProcesses();
            XmlWriter xmlWriter = XmlWriter.Create("..//..//..//allprocessdata.xml");
            xmlWriter.WriteStartDocument();

            xmlWriter.WriteStartElement("processes");

            foreach (Process item in localAll)
            {
                if(item.Id != 0)
                {
                    xmlWriter.WriteStartElement(item.ProcessName.Replace(" ", ""));
                    xmlWriter.WriteAttributeString("ID", Convert.ToString(item.Id));
                    xmlWriter.WriteAttributeString("MemoryUsage", Convert.ToString(item.WorkingSet64 / 1024));
                    xmlWriter.WriteAttributeString("StartTime", Convert.ToString(item.StartTime));
                    xmlWriter.WriteAttributeString("ThreadCount", Convert.ToString(item.Threads.Count));
                    xmlWriter.WriteAttributeString("Comment", "");
                    xmlWriter.WriteEndElement();
                }



            }
            xmlWriter.WriteEndDocument();

            xmlWriter.Close();

        }
    }
}
