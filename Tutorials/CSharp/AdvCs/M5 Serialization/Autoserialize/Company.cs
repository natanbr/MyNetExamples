using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AutoSerialize
{
    [Serializable]
    public class Company : ISerializable
    {
        private readonly Dictionary<string, Department> _departments = new Dictionary<string, Department>();
        private readonly Dictionary<string, Employee> _employees = new Dictionary<string, Employee>();

        public Company(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public IEnumerable<Employee> Employees
        {
            get { return _employees.Values; }
        }

        public IEnumerable<Department> Departments
        {
            get { return _departments.Values; }
        }

        ~Company()
        {
            Console.WriteLine("~Company");
        }

        public void Add(Employee emp)
        {
            _employees.Add(emp.Name, emp);
        }

        public void Add(Department dep)
        {
            _departments.Add(dep.Name, dep);
        }

        public void AddRange(IEnumerable<Employee> emps)
        {
            foreach (var e in emps)
                Add(e);
        }

        public void AddRange(IEnumerable<Department> deps)
        {
            foreach (var d in deps)
                Add(d);
        }

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("departments", _departments);
            info.AddValue("employees", _employees);
            var managers = 0;
            foreach (var d in Departments)
                if (d.Manager != null) managers++;

            info.AddValue("name", Name);
            info.AddValue("managers", managers);
            info.AddValue("savetime", DateTime.Now);
        }

        protected Company(SerializationInfo info, StreamingContext ctx)
        {
            _departments =
                (Dictionary<string, Department>) info.GetValue("departments", typeof (Dictionary<string, Department>));
            _employees =
                (Dictionary<string, Employee>) info.GetValue("employees", typeof (Dictionary<string, Employee>));
            var managers = info.GetInt32("managers");
            Console.WriteLine("Managers: {0}", managers);
            var save = info.GetDateTime("savetime");
            Console.WriteLine("Save time: {0}", save);
            Name = info.GetString("name");
        }

        #endregion
    }
}