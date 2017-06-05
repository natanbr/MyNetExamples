namespace Strategy.After
{
    internal class BeforeCutsStrategy : ISalaryStrategy
    {
        public decimal GetBaseSalary()
        {
            return 10000;
        }

        public decimal GetAcademicDegreeBonus(Employee e)
        {
            return e.HasAcademicDegree ? 1.1m : 1;
        }

        public decimal GetSocialBenefits(Employee e)
        {
            return 1.3m + 0.01m*e.Seniority;
        }
    }
}