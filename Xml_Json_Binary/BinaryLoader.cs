using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Xml_Json_Binary
{
    internal class BinaryLoader
    {
        public static void WriteToBinary<T>(string path, T objectToWrite, bool append = false) where T : new()
        {
            using (Stream stream =File.Open(path,append ? FileMode.Append : FileMode.OpenOrCreate))

            {
                BinaryWriter writer = new BinaryWriter(stream);
               writer.Write(JsonSerializer.Serialize<T>(objectToWrite));

            }
        }
        public static T ReadFromBinary<T>(string path) where T : new()
        {
            using (Stream stream = File.OpenRead(path))
            {
                BinaryReader reader = new BinaryReader(stream);
                return JsonSerializer.Deserialize<T>(reader.ReadString());
            }
        }
    }
}
