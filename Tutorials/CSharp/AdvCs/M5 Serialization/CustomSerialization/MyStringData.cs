using System;
using System.Runtime.Serialization;

namespace CustomSerialization
{
    [Serializable]
    internal class MyStringData : ISerializable
    {
        public string ItemOne { get; set; }
        public string ItemTwo { get; set; }

        public MyStringData()
        {
        }

        private MyStringData(SerializationInfo si, StreamingContext ctx)
        {
            ItemOne = si.GetString("ItemOne");
            ItemTwo = si.GetString("ItemTwo");
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext ctx)
        {
            info.AddValue("ItemOne", ItemOne);
            info.AddValue("ItemTwo", ItemTwo);
            info.AddValue("time", DateTime.Now);
        }
    }
}