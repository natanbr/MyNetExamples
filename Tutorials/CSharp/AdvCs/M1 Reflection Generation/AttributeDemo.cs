using System;
using System.Linq;
using System.Reflection;

namespace CSharp
{
    public class AttributeDemo
    {
        public static void AnalayzeAssembly()
        {
            PrintClassInfo(typeof (A2));
            PrintClassInfo(typeof (B2));
            PrintClassInfo(typeof (C2));

            var assembly = Assembly.GetAssembly(typeof(string));
            bool isApproved = AnalayzeAssembly(assembly);
        }

        /// <summary>
        /// My solution
        /// </summary>
        /// <param name="t"></param>
        private static void PrintClassInfo(Type t)
        {
            Console.WriteLine("Information for {0}", t);

            // Using reflection.
            Attribute[] attrs = Attribute.GetCustomAttributes(t);

            // Print all the CodeReviewAttribute 
            foreach (var a in attrs.OfType<CodeReviewAttribute>())
            {
                Console.WriteLine("{0} {1} {2}", a.ReviewerName, a.ReviewDate, a.Approved);
            }
        }

        /// <summary>
        /// Instracture Solution
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        private static bool AnalayzeAssembly(Assembly assembly)
        {
            foreach (Type t in assembly.GetTypes())
            {
                var attributes = t.GetCustomAttributes<CodeReviewAttribute>().ToArray();

                if (attributes.Any())
                {
                    Console.WriteLine("Type : {0}", t.FullName);
                }

                foreach (var attr in attributes)
                {
                    Console.WriteLine("Reviewer {0} Date {1} Result {2}",
                        attr.ReviewerName, attr.ReviewDate, attr.Approved);

                    if (!attr.Approved)
                        return false;
                }
            }
            return true;
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    class CodeReviewAttribute : Attribute
    {
        private string _reviewerName;
        private string _reviewDate;
        private bool _approved;

        public CodeReviewAttribute(string reviewerName, string reviewDate, bool approved)
        {
            ReviewerName = reviewerName;
            ReviewDate = reviewDate;
            Approved = approved;
        }

        public string ReviewerName
        {
            get { return _reviewerName; }
            set { _reviewerName = value; }
        }

        public string ReviewDate
        {
            get { return _reviewDate; }
            set { _reviewDate = value; }
        }

        public bool Approved
        {
            get { return _approved; }
            set { _approved = value; }
        }
    }

    [CodeReview("A2", "01-01-2011", false)]
    public class A2
    {

    }

    [CodeReview("B2", "11-01-2011", false)]
    public class B2
    {

    }

    [CodeReview("C2", "21-01-2011", true)]
    public class C2
    {

    }
}
