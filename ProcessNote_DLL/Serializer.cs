using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ProcessNote_DLL
{
    public class Serializer
    {
        public static string filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "allprocessdata.xml")
;

        public static void SaveData(ProcessHandler processhandler)
        {
            SerializeProcess(processhandler.allMyProcess);
        }

        public static void DeserializerProcess(ProcessHandler processhandler)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<MyProcess>));
            if (File.Exists(filepath))
            {
                using (FileStream fs = File.OpenRead(filepath))
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

            using (Stream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<MyProcess>));
                serializer.Serialize(fs, processList);
            }
        }
    }
}
