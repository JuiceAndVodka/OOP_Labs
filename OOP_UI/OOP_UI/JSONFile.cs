using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace OOP_UI
{
    public static class JsonSerialization
    {
        public static void WriteToJsonFile(string filePath, object objectToWrite)
        {
            string jsonObject = JsonConvert.SerializeObject(objectToWrite, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            });

            using (StreamWriter WriteStream = new StreamWriter(filePath, false))
            {
                WriteStream.Write(jsonObject);
            }
        }

        public static T ReadFromJsonFile<T>(string filePath)
        {
            string jsonObject = "";

            using (StreamReader ReadStream = new StreamReader(filePath))
            {
                jsonObject = ReadStream.ReadToEnd();
            }

            object deserealizeObject = JsonConvert.DeserializeObject<Object>(jsonObject, new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                TypeNameHandling = TypeNameHandling.All
            });

            return (T)deserealizeObject;
        }
    }
}
