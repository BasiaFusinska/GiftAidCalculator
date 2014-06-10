using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    [TestFixture]
    public class TaxRateStorageTests
    {
        [Test]
        public void stored_value_should_be_retrievable()
        {
            const decimal taxRate = 25m;

            var storage = new TaxRateStorageImpl();
            storage.StoreTaxRate(taxRate);

            var taxRateValue = storage.RetrieveTaxRate();

            Assert.AreEqual(taxRate, taxRateValue);
        }
    }
}
