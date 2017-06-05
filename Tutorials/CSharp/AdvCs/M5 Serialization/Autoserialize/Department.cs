using System;

namespace AutoSerialize
{
    [Serializable]
    public class Department
    {
        private Employee _manager;

        public Department(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public Employee Manager
        {
            get { return _manager; }
            set { _manager = value; }
        }
    }
}