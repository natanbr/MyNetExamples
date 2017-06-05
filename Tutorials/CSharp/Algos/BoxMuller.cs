using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Algos
{
    /// <summary>
    /// From: http://stackoverflow.com/questions/218060/random-gaussian-variables
    /// http://mathworld.wolfram.com/Box-MullerTransformation.html
    /// </summary>
    public class BoxMuller
    {
        private Random r;

        public BoxMuller()
        {
            r = new Random();
        }

        public BoxMuller(int seed)
        {
            r = new Random(seed);   
        }

        public double GetNormal(double mean, double stdDev)
        {
            var u1 = r.NextDouble(); //these are uniform(0,1) random doubles
            var u2 = r.NextDouble();
            var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            var randNormal = mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)

            Console.WriteLine("u1 " + u1);
            Console.WriteLine("u2 " + u2);
            Console.WriteLine("randStdNormal" + randStdNormal);
            Console.WriteLine("randNormal" + randNormal);

            return randNormal;
        }

        /// <summary>
        /// Generate randNormal number within the [minVal, maxVal]
        /// </summary>
        /// <param name="mean"></param>
        /// <param name="stdDev"></param>
        /// <param name="minVal"></param>
        /// <param name="maxVal"></param>
        /// <returns></returns>
        public double GetNormalWithLimits(double mean, double stdDev, double minVal, double maxVal)
        {
            var counter = 0;
            const int limitLoops = 500;

            double randNormal;

            do
            {
                randNormal = GetNormal(mean, stdDev);
                counter++;

                if (counter>= limitLoops) throw new Exception("GetNormalWithLimits reached its number of iterations limit " + limitLoops);
            } while (randNormal < minVal || randNormal > maxVal);

            return randNormal;
        }
    }
}
