using System;

namespace AutoSerialize
{
    [Serializable]
    public class Employee
    {
        public Employee(string name, Department dep)
        {
            Name = name;
            Department = dep;
        }

        public string Name { get; private set; }
        public int Age { get; set; }
        public Department Department { get; private set; }
    }
}