using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Xml_Json_Binary
{
   static class XmlLoader
    {
        public static void WriteToXmlFile<T>(string filePath, T objectToWrite, bool append=false) where T:new()
        {
            //bool if its true it doesnt overwrite just adds it in the file
            //if false it replaces the already given person with what we write

            TextWriter writer = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(filePath,append);
                //breaks it down to store it easier 
                serializer.Serialize(writer, objectToWrite);
            }
            finally
            {
                //macht das FIle immer zu
                if(writer != null)
                    writer.Close();
            }
        }
        public static T ReadFromXmlFile<T>(string filePath) where T : new() 
        {
            TextReader reader = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                reader = new StreamReader(filePath);
                return (T)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
