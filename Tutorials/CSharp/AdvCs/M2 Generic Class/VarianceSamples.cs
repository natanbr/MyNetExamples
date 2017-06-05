using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.AdvCs
{
    public class VarianceSamples
    {
        class B
        {

        }

        class D : B
        {

        }

        static B Display1(D d)
        {
            return new B();
        }

        static D Display2(D d)
        {
            return new D();
        }

        static D Display3(B b)
        {
            return new D();
        }

        static void Do(B b)
        {

        }

        public static void VarianceSamplesMain()
        {
            Action<D> action = Do;
            action(new D());

            Func<D, B> func1 = Display1;
            Func<D, B> func2 = Display2;
            Func<D, B> func3 = Display3;

            IEnumerable<B> list1 = new List<D>();
            //IList<B> list2 = new List<D>();

        }
    }
}
