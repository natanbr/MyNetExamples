using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SerializationDemo
{
    [Serializable]
    [XmlRoot("IntelCustomer")]
    [DataContract]
    internal class Customer : IDeserializationCallback//, IXmlSerializable
    {
        [XmlAttribute]
        [DataMember]
        public string Name { get; set; }
        public decimal Credit { get; set; }
        private decimal Size { get; set; }

        public void OnDeserialization(object sender)
        {
            Console.WriteLine("OnDeserialization callback");
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            Name = reader.ReadString();
            reader.ReadEndElement();
            reader.ReadStartElement();
            Credit = decimal.Parse(reader.ReadString());
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("Name", Name);
            writer.WriteElementString("Credit", Credit.ToString());
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0)*397) ^ Credit.GetHashCode();
            }
        }

        [OnDeserializing]
        public void OnDeserializing(StreamingContext context)
        {
            Console.WriteLine("OnDeserializing decorated method");
        }

        [OnDeserialized]
        public void OnDeserialized(StreamingContext context)
        {
            Console.WriteLine("OnDeserialized decorated method");
        }

        [OnSerializing]
        public void OnSerializing(StreamingContext context)
        {
            Console.WriteLine("OnSerializing decorated method");
        }

        [OnSerialized]
        public void OnSerialized(StreamingContext context)
        {
            Console.WriteLine("OnSerialized decorated method");
        }

        private bool Equals(Customer other)
        {
            return string.Equals(Name, other.Name) && Credit == other.Credit;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Customer) obj);
        }
    }
}