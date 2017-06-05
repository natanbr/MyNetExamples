using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CSharp.Algos.Tests
{
    [TestClass()]
    public class BoxMullerTests
    {
        BoxMuller _boxMuller = new BoxMuller();

        /// <summary>
        /// For testing http://onlinestatbook.com/2/calculators/normal_dist.html
        /// </summary>
        [TestMethod()]
        public void TestExecuteBoxMullerDisAndLimits()
        {
            var restults = new byte[10];

            for (int i = 0; i < 50; i++)
            {
                var r = (int)_boxMuller.GetNormalWithLimits(5, 2, 0, 10);
                Assert.IsTrue(r >= 0 && r <= 10);
                restults[r]++;
            }
        }

        [TestMethod()]
        public void ExecuteBoxMullerGenerateMinAndStnDist()
        {
            var mean = new int[50];
            var stnDis = new double[50];

            for (var i = 0; i < 50; i++)
            {
                var r = (int)_boxMuller.GetNormalWithLimits(6, 3, 0, 10);
                mean[i] = r;
            }

            for (var i = 0; i < 50; i++)
            {
                var r = _boxMuller.GetNormalWithLimits(2, 2, 0.1, 10);
                stnDis[i] = Math.Round(r, 1);
            }

            var meanStr = string.Join(",", mean);
            var stnStr = string.Join(",", stnDis);

        }

        const int users = 50; // number of users
        const int iterations = 20; // number of jobs
        const int paramsGen = 6; // number of params
        private const int cellsBefore = 2;
        Int32[] mean = new[]
            {
                3,6,6,0,6,8,5,3,3,3,3,8,8,9,1,7,9,5,5,7,9,6,3,7,8,3,8,8,2,4,6,6,9,7,5,8,6,5,6,8,5,2,8,2,2,2,2,7,8,7
            };
        double[] stnDev = 
            {
                1,4.6,2.1,1.7,1.9,2.1,3,2.2,2.1,1.8,2.5,2.3,3.6,1.7,0.1,1,2.1,3,1,1.6,2.2,3,2.2,2.6,6.2,1.9,5.2,4.5,2.7,3.4,3.9,4.9,0.8,0.1,1.5,2.5,2.1,2.9,3.7,2.2,1.4,2.6,4.4,4.6,2.1,0.3,4,0.2,3.7,2.8
            };

        [TestMethod()]  
        public void ExecuteBoxMullerToCsvFile()
        {
            var results = new double[users, iterations + cellsBefore, paramsGen];

            // Go over all the users
            for (var i = 0; i < users; i++)
            {
                _boxMuller = new BoxMuller(i);

                // for each param
                for (var j = 0; j < paramsGen; j++)
                {
                    results[i, 0, j] = mean[i];
                    results[i, 1, j] = stnDev[i];

                    // Iterations
                    for (var k = cellsBefore; k < iterations + cellsBefore; k++)
                    {
                        var r = (int)_boxMuller.GetNormalWithLimits(mean[i], stnDev[i], 1, 10);
                        results[i, k, j] = r;
                    }
                }
            }

            WriteToCSV(results);
        }

        /// <summary>
        /// This will increase or decrease the mean each step with the proviues Probability
        /// M_i+1 = r_i > M_i +- L ? M_i +- 1 : M_i
        /// SD_i+1 = SD_i
        /// r_i = N(M_i,SD_i)
        /// </summary>
        private int Limit = 1;
        private int Value = 1;
        [TestMethod()]
        public void ExecuteBoxMullerToCsvFile2()
        {
            var results = new double[users, iterations + cellsBefore, paramsGen];

            for (var i = 0; i < users; i++)
            {
                _boxMuller = new BoxMuller(i);

                for (var j = 0; j < paramsGen; j++)
                {
                    results[i, 0, j] = mean[i];
                    results[i, 1, j] = stnDev[i];

                    for (var k = cellsBefore; k < iterations + cellsBefore; k++)
                    {
                        // r_i = N(M_i,SD_i)
                        var r = (int)_boxMuller.GetNormalWithLimits(mean[i], stnDev[i], 1, 10);
                        results[i, k, j] = r;

                        // Don't continue on last iteration
                        if (k == iterations + cellsBefore - 1) break;
                        
                        // M_i+1 = N(M_i,SD_i) > M_i ? M_i + 0.5 : M_i
                        mean[i] = (r > mean[i] + Limit) ? mean[i] + Value : mean[i];
                        mean[i] = (r < mean[i] - Limit) ? mean[i] - Value : mean[i];
                    }
                }
            }

            WriteToCSV(results);
        }
        /// <summary>
        /// This test will generate random fraction between 0 and 1
        /// Mean = 20
        /// SD = 7
        /// http://onlinestatbook.com/2/calculators/normal_dist.html
        /// </summary>
        [TestMethod()]
        public void RandFraction()
        {
            const int numbers = 50;
            var restultsU = new byte[numbers];
            var restultsD = new byte[numbers];

            for (int i = 0; i < 50; i++)
            {
                var ru = (byte)_boxMuller.GetNormalWithLimits(20, 7, 0, 50);
                var rd = (byte)_boxMuller.GetNormalWithLimits(20, 7, ru, 50);
                restultsU[i] = ru;
                restultsD[i] = rd;
            }

            var meanStr = string.Join(",", restultsU);
            var stnStr = string.Join(",", restultsD);
        }

        public void WriteToCSV(double[, ,] results)
        {
            var sb = new StringBuilder();

            for (var j = 0; j < paramsGen; j++)
            {
                sb.AppendLine("mean, stnd dev, Param " + j);

                for (var i = 0; i < users; i++)
                {
                    for (var k = 0; k < iterations + cellsBefore; k++)
                    {
                        sb.AppendFormat("{0},", results[i, k, j]);
                    }
                    sb.AppendLine();
                }
            }

            File.WriteAllText("AutoGenGrades.csv", sb.ToString());
        }
    }
}
