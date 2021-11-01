using System;
using Domain;
using Domain.Calculators;
using NUnit.Framework;

namespace DomainTests
{
    public class TaxServiceTests
    {
        private TaxService _taxService;

        [SetUp]
        public void Setup()
        {

            var calculator = new DefaultTaxCalculator();
             
            _taxService = new TaxService(calculator);

        }

        [Test]
        public void IsNonZero()
        {
            var zipcode = "48084";
            var mockAmount = 499m;

            var taxAmount = _taxService.Amount(zipcode, mockAmount);

            Assert.Greater(mockAmount,0);
        }

        [Test]
        public void MissingZip()
        {
            var zipcode = "";
            var mockAmount = 499m;

            var taxAmount = _taxService.Amount(zipcode, mockAmount);

            Assert.Throws<Exception>(delegate { _taxService.Amount(zipcode, mockAmount); });
        }
    }
}