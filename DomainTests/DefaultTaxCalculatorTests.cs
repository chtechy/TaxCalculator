using System;
using Domain;
using Domain.Calculators;
using NUnit.Framework;

namespace DomainTests
{
    public class DefaultTaxCalculatorTests
    {
        private DefaultTaxCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new DefaultTaxCalculator();
        }

        [Test]
        public void IsNonZero()
        {
            var rate = .06m;
            var mockAmount = 499m;

            var amount = _calculator.CalculateTax(rate, mockAmount);

            Assert.Greater(mockAmount,0);
        }
  

    }
}