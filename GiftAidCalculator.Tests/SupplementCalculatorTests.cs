using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    [TestFixture]
    public class SupplementCalculatorTests
    {
        [TestCase(EventType.Running, 5)]
        [TestCase(EventType.Swimming, 3)]
        [TestCase(EventType.Other, 0)]
        public void calculating_supplemented_amount_should_return_proper_value(EventType eventType, decimal supplementionRate)
        {
            const decimal donationAmount = 1000m;

            var calculator = new SupplementCalculator();
            var supplementedAmount = calculator.CalculateSupplementedAmount(donationAmount, eventType);

            Assert.AreEqual(donationAmount + donationAmount * supplementionRate / 100, supplementedAmount);
        }
    }
}
