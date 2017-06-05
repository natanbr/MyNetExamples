using System.Collections.Generic;

namespace Strategy.Before
{
    internal class SalaryCalculator
    {
        private readonly List<Employee> _employees;
        private readonly SalaryStrategy _strategy;

        public SalaryCalculator(List<Employee> employees, SalaryStrategy strategy)
        {
            _employees = employees;
            _strategy = strategy;
        }

        public decimal CalculateTotalSalary()
        {
            decimal totalSalary = 0m;

            foreach (Employee employee in _employees)
            {
                totalSalary += CalculateSalary(employee);
            }

            return totalSalary;
        }

        private decimal CalculateSalary(Employee e)
        {
            decimal salary = GetBaseSalary() + 500*e.Seniority;
            if (_strategy == SalaryStrategy.BeforeCuts && e.HasAcademicDegree)
                salary *= 1.1m;

            return salary*GetSocialBenefits(e);
        }

        private decimal GetSocialBenefits(Employee e)
        {
            if (_strategy == SalaryStrategy.BeforeCuts)
                return 1.3m + 0.01m*e.Seniority;
            return 1.25m;
        }

        private int GetBaseSalary()
        {
            return _strategy == SalaryStrategy.BeforeCuts ? 10000 : 8000;
        }
    }
}