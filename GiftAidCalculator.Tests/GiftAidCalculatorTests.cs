using System;
using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    [TestFixture]
    public class GiftAidCalculatorTests
    {
        [Test]
        public void proper_tax_value_should_return_proper_aid_amount()
        {
            const decimal donationAmount = 1000m;
            const decimal taxRate = 20m;

            var aidCalculator = new GiftAidCalculator();
            var aidAmount = aidCalculator.CalculateGiftAidAmount(donationAmount, taxRate);

            Assert.AreEqual(250m, aidAmount);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void less_than_zero_donation_amount_should_throw_exception()
        {
            const decimal donationAmount = -1000m;
            const decimal taxRate = 20m;

            var aidCalculator = new GiftAidCalculator();
            aidCalculator.CalculateGiftAidAmount(donationAmount, taxRate);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void less_than_zero_tax_rate_should_throw_exception()
        {
            const decimal donationAmount = 1000m;
            const decimal taxRate = -20m;

            var aidCalculator = new GiftAidCalculator();
            aidCalculator.CalculateGiftAidAmount(donationAmount, taxRate);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void more_than_hundred_tax_rate_should_throw_exception()
        {
            const decimal donationAmount = 1000m;
            const decimal taxRate = 120m;

            var aidCalculator = new GiftAidCalculator();
            aidCalculator.CalculateGiftAidAmount(donationAmount, taxRate);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void hundret_tax_rate_should_throw_exception()
        {
            const decimal donationAmount = 1000m;
            const decimal taxRate = 100m;

            var aidCalculator = new GiftAidCalculator();
            aidCalculator.CalculateGiftAidAmount(donationAmount, taxRate);
        }

    }
}
