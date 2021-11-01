using System;

namespace Domain.Calculators
{
    public class DefaultTaxCalculator : IDefaultTaxCalculator
    {

        public decimal CalculateTax(decimal rate, decimal orderSubTotal)
        {
            //take the rate and calculate the order
            return Math.Round(orderSubTotal * rate);
        }
    }
}
