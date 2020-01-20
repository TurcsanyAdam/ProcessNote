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
            XmlWriter xmlWriter = XmlWriter.Create("..//..//..//test.xml");
            xmlWriter.WriteStartDocument();

            xmlWriter.WriteStartElement("processes");

            foreach (Process item in localAll)
            {
                xmlWriter.WriteStartElement("process");
                xmlWriter.WriteAttributeString("ID", Convert.ToString(item.Id));
                xmlWriter.WriteEndElement();


            }
            xmlWriter.WriteEndDocument();

            xmlWriter.Close();

        }
    }
}
