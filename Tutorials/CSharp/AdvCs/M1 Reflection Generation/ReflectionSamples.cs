using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.AdvCs
{
    public class ReflectionSamples
    {
        public static void ReflectionSamplesMain()
        {
            CreateFromAssembly();

            FindAndCreate();

            ReadCustomAttribute();

            InvokeConstructor();

            InvokeMember();
        }

        private static void InvokeMember()
        {
            var s = new Student();
            var t = s.GetType();

            foreach (var member in t.GetMember("Print"))
            {
                Console.WriteLine(member.Name);
                t.InvokeMember(
                    member.Name,
                    BindingFlags.InvokeMethod,
                    null,
                    s,
                    new object[] { "Something" },
                    Thread.CurrentThread.CurrentCulture);
            }
        }

        private static void InvokeConstructor()
        {
            var t = typeof(Student);

            foreach (var ctor in t.GetConstructors())
            {
                Console.WriteLine(ctor.Name);
                if (ctor.GetParameters().Length == 1)
                {
                    var p = ctor.Invoke(new object[] { "Bill" }) as Student;
                    p.Print("any");
                    break;
                }
            }
        }

        private static void ReadCustomAttribute()
        {
            var t = typeof(Student);
            foreach (var atr in t.GetCustomAttributes())
            {
                var tested = (TestedAttribute)atr;
                Console.WriteLine(tested.Name);
            }
        }

        private static void FindAndCreate()
        {
            foreach (var type in Assembly.GetExecutingAssembly().ExportedTypes)
            {
                if (type.Name == "Student")
                {
                    var student =
                        Activator.CreateInstance(type, "Bill");

                    Console.WriteLine(type.Name);
                }
            }
        }

        private static void CreateFromAssembly()
        {
            var assembly = Assembly.GetExecutingAssembly().FullName;
            var handle = Activator.CreateInstance(assembly, "ReflectionSamples.Student");
            var student = (Student)handle.Unwrap();
            student.Name = "Bill";
            Console.WriteLine(student);
        }
    }

    [Tested("Bill Gates")]
    public class Student
    {
        private string _name;

        public Student()
        {
        }

        public Student(string name)
        {
            this._name = name;
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public override string ToString()
        {
            return this._name;
        }

        public void Print(string something)
        {
            Console.WriteLine(something);
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class TestedAttribute : Attribute
    {
        public string Name { get; private set; }

        public TestedAttribute(string name)
        {
            Name = name;
        }
    }
}
