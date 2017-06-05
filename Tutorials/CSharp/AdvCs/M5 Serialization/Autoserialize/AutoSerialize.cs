using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AutoSerialize
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var c = CreateCompany("Dummy");
            SaveToFile(@"c:\temp\cmp.dat", c);
            Display(c);

            c = null;
            CollectAndFinalize();

            Console.WriteLine();
            Console.WriteLine("After collection");
            c = LoadFromFile(@"c:\temp\cmp.dat");
            Display(c);

            // save to memory
            Console.WriteLine();
            var stm = SaveToMemory(c);
            
            c = null;
            CollectAndFinalize();

            Console.WriteLine("Loading from memory");
            stm.Position = 0;
            c = LoadCompany(stm);
            Display(c);
        }

        private static void CollectAndFinalize()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private static void Display(Company c)
        {
            Console.WriteLine("Company name: {0}", c.Name);
            foreach (var d in c.Departments)
                Console.WriteLine("Dep: {0} Manager: {1}", d.Name, d.Manager == null ? "none" : d.Manager.Name);

            foreach (var e in c.Employees)
                Console.WriteLine("Employee: {0}", e.Name);
        }

        private static Company CreateCompany(string name)
        {
            Department[] dep =
            {
                new Department("Computers"),
                new Department("Food"),
                new Department("Sports")
            };
            Employee[] e =
            {
                new Employee("Bart Simpson", dep[0]),
                new Employee("Clark Kent", dep[2]),
                new Employee("Peter Parker", dep[2]),
                new Employee("Homer Simpson", dep[1])
            };

            dep[1].Manager = e[3];

            var company = new Company(name);
            company.AddRange(dep);
            company.AddRange(e);

            return company;
        }

        private static void SaveToFile(string path, Company company)
        {
            using (var stm = new FileStream(path, FileMode.Create))
                SaveCompany(company, stm);
        }

        private static Company LoadFromFile(string path)
        {
            using (var stm = new FileStream(path, FileMode.Open))
                return LoadCompany(stm);
        }

        private static MemoryStream SaveToMemory(Company company)
        {
            var stm = new MemoryStream();
            SaveCompany(company, stm);
            return stm;
        }

        private static void SaveCompany(Company company, Stream stm)
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stm, company);
        }

        private static Company LoadCompany(Stream stm)
        {
            var formatter = new BinaryFormatter();
            return (Company) formatter.Deserialize(stm);
        }
    }
}