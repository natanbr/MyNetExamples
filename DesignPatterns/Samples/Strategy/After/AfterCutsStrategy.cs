namespace Strategy.After
{
    internal class AfterCutsStrategy : ISalaryStrategy
    {
        public decimal GetBaseSalary()
        {
            return 8000;
        }

        public decimal GetAcademicDegreeBonus(Employee e)
        {
            return 1;
        }

        public decimal GetSocialBenefits(Employee e)
        {
            return 1.25m;
        }
    }
}