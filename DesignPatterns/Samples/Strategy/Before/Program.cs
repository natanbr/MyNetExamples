using System;
using System.Collections.Generic;

namespace Strategy.Before
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var employees = new List<Employee>
            {
                new Employee {Seniority = 2, HasAcademicDegree = false},
                new Employee {Seniority = 2, HasAcademicDegree = true},
                new Employee {Seniority = 5, HasAcademicDegree = true},
            };

            var calculator1 = new SalaryCalculator(employees, SalaryStrategy.AfterCuts);
            decimal afterCuts = calculator1.CalculateTotalSalary();

            var calculator2 = new SalaryCalculator(employees, SalaryStrategy.BeforeCuts);
            decimal beforeCuts = calculator2.CalculateTotalSalary();

            if (afterCuts == 35625 && beforeCuts == 49054.5m)
                Console.WriteLine("Passed");
            else
                Console.WriteLine("Failed");
        }
    }
}