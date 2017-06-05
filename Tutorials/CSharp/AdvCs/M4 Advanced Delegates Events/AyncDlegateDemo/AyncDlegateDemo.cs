using System;

namespace AsyncDelegateDemo
{
    /// <summary>
    /// MathOp is delegate type!
    /// </summary>
    internal delegate bool MathOp(double a, double b, out double z, ref double c);

    internal class AyncDlegateDemo
    {
        private bool Add(double a, double b, out double z, ref double c)
        {
            z = a + b + c;
            c = 4.2;
            return false;
        }

        public static void Execute(string[] args)
        {
            new AyncDlegateDemo().CallIt();
        }

        private double _c = 5;

        private void CallIt()
        {
            MathOp op = Add;
            double z = 0;

            // issue the call and return
            var ar = op.BeginInvoke(
                3, 4, out z, ref _c,
                Completed, op);
        }

        // this method will be called at call completion
        // by a worker thread
        private void Completed(IAsyncResult call)
        {
            double result;
            double c = 6.7;
            var op = (MathOp) call.AsyncState;
            var overflow = op.EndInvoke(out result, ref c, call);
            Console.WriteLine("{0}, {1}, {2}", result, overflow, result);
        }

    }
}