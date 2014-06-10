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
        [TestCase(EventType.Running)]
        [TestCase(EventType.Swimming)]
        [TestCase(EventType.Other)]
        public void calculating_supplemented_amount_should_return_proper_value(EventType eventType)
        {
            const decimal donationAmount = 1000m;

            var calculator = new SupplementCalculator();
            var supplementedAmount = calculator.CalculateSupplementedAmount(donationAmount, eventType);

            var supplementionRate = eventType == EventType.Running ? 5m : eventType == EventType.Swimming ? 3m : 0m;
            Assert.AreEqual(donationAmount * supplementionRate / 100, supplementedAmount);
        }
    }
}
