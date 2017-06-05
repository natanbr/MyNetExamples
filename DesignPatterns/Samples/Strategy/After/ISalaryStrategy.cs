namespace Strategy.After
{
    public interface ISalaryStrategy
    {
        decimal GetBaseSalary();
        decimal GetAcademicDegreeBonus(Employee e);
        decimal GetSocialBenefits(Employee e);
    }
}