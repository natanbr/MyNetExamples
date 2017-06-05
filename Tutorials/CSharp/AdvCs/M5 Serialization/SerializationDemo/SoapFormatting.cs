using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace SerializationDemo
{
    internal static class SoapFormatting
    {
        public static string Serialize<T>(T obj)
        {
            try
            {
                var serializer = new SoapFormatter();
                using (var ms = new MemoryStream())
                {
                    serializer.Serialize(ms, obj);
                    ms.Position = 0;
                    StreamReader reader = new StreamReader(ms);
                    return reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return string.Empty;
        }

        public static T Deserialize<T>(string str)
        {
            try
            {
                var serializer = new SoapFormatter();
                using (var ms = new MemoryStream())
                {
                    StreamWriter writer = new StreamWriter(ms);
                    writer.Write(str);
                    writer.Flush();
                    ms.Position = 0;
                    return (T) serializer.Deserialize(ms);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return default(T);
        }
    }
}