namespace Domain.Calculators
{
    public interface IDefaultTaxCalculator
    {
        decimal CalculateTax(decimal rate, decimal orderSubTotal);
    }
}