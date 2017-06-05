using System;
using System.Reflection;

namespace CSharp
{
    public class DynInvoke
    {
        public static void DynInvokeMain()
        {
            InvokeHello(new A(),"abc");
            Invoke(new B(),"abc");
        }

        /// <summary>
        /// My solution
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="str"></param>
        public static void InvokeHello(object obj, string str)
        {
            var type = obj.GetType();
            var helloMethod = type.GetMethod("Hello");
            var @out = "---";

            if (helloMethod != null)
                @out = (string)helloMethod.Invoke(obj, new object[] { str });

            Console.WriteLine(@out);
        }

        /// <summary>
        /// Instractor solution
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        static MethodInfo GetMethod(object obj)
        {
            var type = obj.GetType();
            foreach (var method in type.GetMethods())
            {
                if (method.Name == "Hello")
                {
                    return method;
                }
            }
            return null;
        }

        /// <summary>
        /// Instractor solution
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="text"></param>
        private static void Invoke(object obj, string text)
        {
            var method = GetMethod(obj);
            if (method != null)
            {
                var result = method.Invoke(obj, new object[] { text });
                Console.WriteLine(result);
            }
        }
    }

    public class A
    {
        public string Hello(string hello)
        {
            return "A " + hello;
        }
    }

    public class B
    {
        public string Hello(string hello)
        {
            return "B " + hello;
        }
    }

    public class C
    {
        public string Hello(string hello)
        {
            return "C " + hello;
        }   
    }


    // pure virtual in C++
    abstract class D
    {
        
    }
}
