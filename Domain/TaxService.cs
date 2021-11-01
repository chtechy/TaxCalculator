using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Domain.Calculators;
using Newtonsoft.Json;

namespace Domain
{
    public class TaxService
    {
        private readonly IDefaultTaxCalculator _calculator;

        public TaxService(IDefaultTaxCalculator calculator)
        {
            _calculator = calculator;
        }


        public async Task<decimal> Amount(string zip, decimal orderSubTotal)
        {
            if (string.IsNullOrEmpty(zip))
                throw new Exception("Need a zip code to calculate tax");

            var rate = await TaxRate(zip);

            return _calculator.CalculateTax(rate, orderSubTotal);
        }

        private async Task<decimal> TaxRate(string zipCode)
        {
            var client = new HttpClient();

            var path = $"api.taxjar.com/v2/rates{zipCode}";

            var response = await client.GetAsync(path);

            if (!response.IsSuccessStatusCode) throw new Exception("Could not load tax information");

            var taxResponse = await response.Content.ReadAsStringAsync();
            var taxData = JsonConvert.DeserializeObject<TaxRateDTO>(taxResponse);

            return taxData.state_rate;
        }
    }

}