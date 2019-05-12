using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace OOP_UI
{
    public static class TextSerialization
    {

        private static int AmountOfTAB = 0;

        public static void StartWriting<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            List<object> Links = new List<object>();

            using (StreamWriter WriteStream = new StreamWriter(filePath, append))
            {
                WriteToTextFile(filePath, objectToWrite, WriteStream, ref Links);
            }
        }

        private static void WriteToTextFile(string filePath, object objectToWrite, StreamWriter pWriteStream, ref List<object> pLinks)
        {

            AmountOfTAB++;
            string TABstring = "";

            for (int i = 1; i <= AmountOfTAB; i++)
                TABstring += "\t";

            pWriteStream.WriteLine(TABstring.Substring(1) + "{");

            pWriteStream.WriteLine(TABstring + "\"$type\": " + objectToWrite.GetType().ToString());

            bool DoesObjectInList = false;
            int ObjectNumber = 0;

            for (int i = 0; i < pLinks.Count; i++)
            {
                if (objectToWrite == pLinks[i])
                {
                    DoesObjectInList = true;
                    ObjectNumber = i;
                    break;
                }
            }

            if (DoesObjectInList)
            {
                pWriteStream.WriteLine(TABstring + "\"$repeat\": " + ObjectNumber.ToString());
            }
            else
            {
                pLinks.Add(objectToWrite);
            }

                if (objectToWrite.GetType() == typeof(List<Enterprises>))
                {
                    pWriteStream.WriteLine(TABstring + "\"$values\": ");
                    pWriteStream.WriteLine(TABstring + "[");
                    AmountOfTAB++;

                    foreach (Enterprises item in (List<Enterprises>)objectToWrite)
                    {
                        WriteToTextFile(filePath, item, pWriteStream, ref pLinks);
                    }

                    AmountOfTAB--;
                    pWriteStream.WriteLine(TABstring + "]");
                }
                else
                {
                    FieldInfo[] fields = objectToWrite.GetType().GetFields();

                    for (int i = 0; i < fields.Length; i++)
                    {
                        if ((!fields[i].FieldType.IsPrimitive) && (!fields[i].FieldType.IsEnum) 
                            && (!(fields[i].FieldType == typeof(string))))
                        {
                            if (fields[i].GetValue(objectToWrite) != null)
                            {
                                pWriteStream.WriteLine(TABstring + "\"" + fields[i].Name.ToString() + "\": ");
                                WriteToTextFile(filePath, fields[i].GetValue(objectToWrite), pWriteStream, ref pLinks);
                            }
                            else
                                pWriteStream.WriteLine(TABstring + "\"" + fields[i].Name.ToString() + "\": " + "null");
                        }
                        else
                        {
                            string s = "";
                            if (fields[i].FieldType == typeof(string))
                                s = "\"";
                            pWriteStream.WriteLine(TABstring + "\"" + fields[i].Name.ToString() + "\": " + s + fields[i].GetValue(objectToWrite).ToString() + s);
                        }
                    }

                }
            

            pWriteStream.WriteLine(TABstring.Substring(1) + "}");

            AmountOfTAB--;
            
        }

        public static T StartGetting<T>(string filePath)
        {
            object newObject;
            List<object> Links = new List<object>();

            using (StreamReader ReadStream = new StreamReader(filePath))
            {
                newObject = GetFromTextFile(ReadStream, ref Links);
            }

            return (T)newObject;
        }

        public static object GetFromTextFile(StreamReader pReadStream, ref List<object> pLinks)
        {

            string line = "";

            line = pReadStream.ReadLine();

            if (line == null) return null;

            if (line[line.Length - 1] == ']') return null;

            object newObject = null;

            if (line[line.Length - 1] == '{')
            {

                string type = "";
                string value = "";
                
                while (((line = pReadStream.ReadLine()) != null) && (line[line.Length - 1] != '}'))
                {

                    type = GetTypeFromLine(line);

                    switch (type)
                    {
                        case "$type":

                            newObject = CreateClassInstance(GetValueFromLine(line));
                            pLinks.Add(newObject);

                            break;

                        case "$values":

                            var newList = (List<Enterprises>)newObject;
                            line = pReadStream.ReadLine();

                            while (true)
                            {
                                object objectToList = GetFromTextFile(pReadStream, ref pLinks);

                                if (objectToList == null)
                                    break;
                                else
                                {
                                    newList.Add((Enterprises)objectToList);
                                }
                            }

                            break;

                        case "$repeat":

                            pLinks.Remove(newObject);
                            newObject = pLinks[Convert.ToInt16(GetValueFromLine(line))];

                            while (line[line.Length - 1] != '}')
                                line = pReadStream.ReadLine();

                            return newObject;


                        default:

                            FieldInfo field = newObject.GetType().GetField(type);
                            value = GetValueFromLine(line);

                            if (field != null)
                            {
                                if (field.FieldType.IsPrimitive)
                                {
                                    field.SetValue(newObject, Convert.ChangeType(value, field.FieldType));
                                }
                                else if (field.FieldType == typeof(string))
                                {
                                    field.SetValue(newObject, Convert.ChangeType(value.Substring(1, value.Length - 2), field.FieldType));
                                }
                                else if (field.FieldType.IsEnum)
                                {
                                    field.SetValue(newObject, Enum.Parse(field.FieldType, value));
                                }
                                else
                                {
                                    field.SetValue(newObject, GetFromTextFile(pReadStream, ref pLinks));
                                }
                            }

                            break;
                    }
                }
            }

            return newObject;
        }

        private static string GetTypeFromLine(string line)
        {
            int beg = 0;
            int end = 0;

            beg = line.IndexOf('"');

            end = beg + 1;

            while (line[end] != '"')
                end++;

            return line.Substring(beg + 1, end - beg - 1);
        }

        private static string GetValueFromLine(string line)
        {
            int beg = 0;

            beg = line.IndexOf(':');
            beg += 2;

            return line.Substring(beg);
        }

        private static object CreateClassInstance(string className)
        {
            return Activator.CreateInstance(Type.GetType(className));
        }
    }
}
