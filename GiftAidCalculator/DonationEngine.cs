namespace GiftAidCalculator
{
    public class DonationEngine
    {
        private readonly ITaxRateStorage _taxRateStore;
        private readonly IGiftAidCalculator _calculator;
        private readonly ISupplementCalculator _supplementConfiguration;

        public DonationEngine(ITaxRateStorage taxRateStore, 
                     IGiftAidCalculator calculator,
                     ISupplementCalculator supplementConfiguration)
        {
            _taxRateStore = taxRateStore;
            _calculator = calculator;
            _supplementConfiguration = supplementConfiguration;
        }

        public DonationInfo Donate(decimal donationAmount, EventType eventType)
        {
            var donation = _supplementConfiguration.CalculateSupplementedAmount(donationAmount, eventType);
            var giftAid = _calculator.CalculateGiftAidAmount(donation, _taxRateStore.RetrieveTaxRate());
            var giftAidRounded = decimal.Round(giftAid, 2);

            return new DonationInfo
            {
                OriginalDonation = donationAmount,
                SupplementedDonation = donation,
                GiftAid = giftAid,
                GiftAidRounded = giftAidRounded,
            };
        }
    }
}
