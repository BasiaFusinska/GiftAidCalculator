using Moq;
using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    [TestFixture]
    public class DonationEngineTests
    {
        const decimal DonationAmount = 2500m;
        const decimal SupplementedAmount = 2789m;
        const decimal TaxRate = 25m;
        const decimal GiftAid = 345.678m;

        private readonly Mock<ITaxRateStorage> _storageMock = new Mock<ITaxRateStorage>();
        private readonly Mock<IGiftAidCalculator> _calculatorMock = new Mock<IGiftAidCalculator>();
        private readonly Mock<ISupplementCalculator> _configurationMock = new Mock<ISupplementCalculator>();

        [SetUp]
        public void SetUp()
        {

            _storageMock
                .Setup(x => x.RetrieveTaxRate())
                .Returns(TaxRate);

            _calculatorMock
                .Setup(x => x.CalculateGiftAidAmount(It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns(GiftAid);

            _configurationMock
                .Setup(x => x.CalculateSupplementedAmount(It.IsAny<decimal>(), It.IsAny<EventType>()))
                .Returns(SupplementedAmount);
            
        }

        [Test]
        public void calculating_donation_info_should_use_proper_providers()
        {
            var donationEngine = new DonationEngine(_storageMock.Object, _calculatorMock.Object, _configurationMock.Object);
            donationEngine.Donate(DonationAmount, new EventActivity { EventType = EventType.Other });

            _storageMock.Verify(x => x.RetrieveTaxRate());
            _calculatorMock.Verify(x => x.CalculateGiftAidAmount(It.IsAny<decimal>(), It.IsAny<decimal>()));
            _configurationMock.Verify(x => x.CalculateSupplementedAmount(It.IsAny<decimal>(), It.IsAny<EventType>()));
        }

        [Test]
        public void calculating_donation_info_should_return_proper_values()
        {
            var donationEngine = new DonationEngine(_storageMock.Object, _calculatorMock.Object, _configurationMock.Object);
            var donationInfo = donationEngine.Donate(DonationAmount, new EventActivity { EventType = EventType.Other});

            Assert.AreEqual(DonationAmount, donationInfo.OriginalDonation);
            Assert.AreEqual(SupplementedAmount, donationInfo.SupplementedDonation);
            Assert.AreEqual(GiftAid, donationInfo.GiftAid);
            Assert.AreEqual(345.68m, donationInfo.GiftAidRounded);
        }
    }
}
