using System.Collections.Generic;

namespace Strategy.After
{
    internal class SalaryCalculator
    {
        private readonly List<Employee> _employees;
        private readonly ISalaryStrategy _strategy;

        public SalaryCalculator(List<Employee> employees, ISalaryStrategy strategy)
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
            decimal salary = _strategy.GetBaseSalary() + 500*e.Seniority;
            salary *= _strategy.GetAcademicDegreeBonus(e);
            return salary*_strategy.GetSocialBenefits(e);
        }
    }
}