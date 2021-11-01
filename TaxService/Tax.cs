using System;
using System.Threading.Tasks;
using Domain;

namespace Service
{

    public class Tax
    {
        private readonly ITaxCalculator _calculator;

        public Tax(ITaxCalculator calculator)
        {
            _calculator = calculator;
        }

        public async Task<decimal> Amount(string zip, decimal orderSubTotal)
        {
            
            return await _calculator.CalculateTax(zip, orderSubTotal);
        }


    }
}
