using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Xml_Json_Binary
{
    class JsonLoader
    {
        public static void WriteToJsonFile<T>(string path, T objectToWrite,bool append=false) where T : new()
        {
            try
            {
                // JsonSerializer serializer = new JsonSerializer(typeof(T));
                var data = JsonSerializer.Serialize<T>(objectToWrite);
                File.WriteAllText(path,data);
            }
            catch(Exception ex)  
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Schreiben beendet!");
            }
          
        }
        public static T ReadFromJsonFile<T>(string path) where T : new()
        {
             
            try
            {
              return JsonSerializer.Deserialize<T>(File.ReadAllText(path));

            }
            finally
            {
                MessageBox.Show("fehler");
            }
            
        }
    }
}
