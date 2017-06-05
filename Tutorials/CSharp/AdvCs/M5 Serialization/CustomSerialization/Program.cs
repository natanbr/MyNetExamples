using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace CustomSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStringData original = new MyStringData
            {
                ItemOne = "Hello",
                ItemTwo = "World"
            };

            const string fileName = "serialized.bin";

            try
            {
                Serialize(fileName, original);

                var reconstructed = Deserialize(fileName);

                Console.WriteLine(IsEqual(original, reconstructed));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static bool IsEqual(MyStringData lhs, MyStringData rhs)
        {
            return
                lhs.ItemOne == rhs.ItemOne &&
                lhs.ItemTwo == rhs.ItemTwo;
        }

        private static void Serialize(string fileName, MyStringData data)
        {
            using (var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                IFormatter formatter = CreateFormatter();
                formatter.Serialize(stream, data);
            }
        }

        private static MyStringData Deserialize(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                IFormatter formatter = CreateFormatter();
                return formatter.Deserialize(stream) as MyStringData;
            }
        }

        private static IFormatter CreateFormatter()
        {
            var soapFormatter = new BinaryFormatter();
            soapFormatter.AssemblyFormat = FormatterAssemblyStyle.Full;
            return soapFormatter;
        }
    }
}