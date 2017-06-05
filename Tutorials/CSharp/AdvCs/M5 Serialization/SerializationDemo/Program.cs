using System;
using System.Xml;

namespace SerializationDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new Program().Run();
        }

        private void Run()
        {
            var customer = new Customer
            {
                Name = "IBM",
                Credit = 100
            };

            var str = DataContractSerialization.Serialize(customer);

            WriteXml(str);

            var deserialized = DataContractSerialization.Deserialize<Customer>(str);

            var isEqual = deserialized.Equals(customer);

            Console.WriteLine(isEqual ? "PASSED" : "FAILED");
        }

        private static void WriteXml(string str)
        {
            var settings = new XmlWriterSettings {Indent = true};
            using (var writer = XmlWriter.Create(Console.Out, settings))
            {
                var doc = new XmlDocument();
                doc.LoadXml(str);
                doc.WriteTo(writer);
            }
        }
    }
}