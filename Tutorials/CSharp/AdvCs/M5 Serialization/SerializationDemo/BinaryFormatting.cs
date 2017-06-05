using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace SerializationDemo
{
    internal static class BinaryFormatting
    {
        public static byte[] Serialize<T>(T obj)
        {
            try
            {
                var serializer = new BinaryFormatter();
                using (var ms = new MemoryStream())
                {
                    serializer.Serialize(ms, obj);
                    ms.Position = 0;
                    return ms.GetBuffer();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return new byte[0];
        }

        public static T Deserialize<T>(byte[] bytes)
        {
            try
            {
                var serializer = new BinaryFormatter();
                using (var ms = new MemoryStream(bytes))
                {
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