using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ProcessNote
{
    class Serializer
    {
        public static void SaveData(Initializer initializer)
        {
            SerializeUser(initializer.UserList);
        }

        public static void DeserializerUser(Initializer initializer)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<MyProcess>));

            using (FileStream fs = File.OpenRead("..//..//..//allprocessdata.xml"))
            {
                initializer.UserList = (List<MyProcess>)serializer.Deserialize(fs);
            }
        }

        static void SerializeUser(List<MyProcess> userList)
        {
            using (Stream fs = new FileStream(@"C:\Users\Turi\source\repos\Szaki_kereso\User_data.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<MyProcess>));
                serializer.Serialize(fs, userList);
            }
        }
    }
}
