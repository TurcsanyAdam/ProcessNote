using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ProcessNote
{
    class Serializer
    {
        public static void SaveData(ProcessHandler processhandler)
        {
            SerializeProcess(processhandler.allMyProcess);
        }

        public static void DeserializerProcess(ProcessHandler processhandler)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<MyProcess>));
            if (File.Exists("..//..//..//allprocessdata.xml"))
            {
                using (FileStream fs = File.OpenRead("..//..//..//allprocessdata.xml"))
                {
                    processhandler.allMyProcess = (List<MyProcess>)serializer.Deserialize(fs);
                }
            }
            else
            {
                throw new FileNotFoundException("This file does not exist");
            }
        }

        public static void SerializeProcess(List<MyProcess> processList)
        {
            if (File.Exists("..//..//..//allprocessdata.xml"))
            {
                using (Stream fs = new FileStream("..//..//..//allprocessdata.xml", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<MyProcess>));
                    serializer.Serialize(fs, processList);
                }
            }
            else
            {
                throw new FileNotFoundException("This file does not exist");
            }
        }
    }
}
