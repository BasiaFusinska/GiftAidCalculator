using Moq;
using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    [TestFixture]
    public class DonationEngineTests
    {
        [Test]
        public void calculating_donation_info_should_use_proper_providers()
        {
            var storageMock = new Mock<ITaxRateStorage>();
            storageMock.Setup(x => x.RetrieveTaxRate());

            var calculatorMock = new Mock<IGiftAidCalculator>();
            calculatorMock.Setup(x => x.CalculateGiftAidAmount(It.IsAny<decimal>(), It.IsAny<decimal>()));

            var configurationMock = new Mock<ISupplementCalculator>();
            configurationMock.Setup(x => x.CalculateSupplementedAmount(It.IsAny<decimal>(), It.IsAny<EventType>()));

            var donationEngine = new DonationEngine(storageMock.Object, calculatorMock.Object, configurationMock.Object);
            donationEngine.Donate(1000m, EventType.Other);

            storageMock.Verify(x => x.RetrieveTaxRate());
            calculatorMock.Verify(x => x.CalculateGiftAidAmount(It.IsAny<decimal>(), It.IsAny<decimal>()));
            configurationMock.Verify(x => x.CalculateSupplementedAmount(It.IsAny<decimal>(), It.IsAny<EventType>()));
        }

        [Test]
        public void calculating_donation_info_should_return_proper_values()
        {
            const decimal donationAmount = 2500m;
            const decimal supplementedAmount = 2789m;
            const decimal taxRate = 25m;
            const decimal giftAid = 345.678m;

            var storageMock = new Mock<ITaxRateStorage>();
            storageMock
                .Setup(x => x.RetrieveTaxRate())
                .Returns(taxRate);

            var calculatorMock = new Mock<IGiftAidCalculator>();
            calculatorMock
                .Setup(x => x.CalculateGiftAidAmount(It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns(giftAid);

            var configurationMock = new Mock<ISupplementCalculator>();
            configurationMock
                .Setup(x => x.CalculateSupplementedAmount(It.IsAny<decimal>(), It.IsAny<EventType>()))
                .Returns(supplementedAmount);

            var donationEngine = new DonationEngine(storageMock.Object, calculatorMock.Object, configurationMock.Object);
            var donationInfo = donationEngine.Donate(donationAmount, EventType.Other);

            Assert.AreEqual(donationAmount, donationInfo.OriginalDonation);
            Assert.AreEqual(supplementedAmount, donationInfo.SupplementedDonation);
            Assert.AreEqual(giftAid, donationInfo.GiftAid);
            Assert.AreEqual(345.68m, donationInfo.GiftAidRounded);
        }
    }
}
