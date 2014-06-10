using System;

namespace GiftAidCalculator
{
    public class GiftAidCalculator : IGiftAidCalculator
    {
        public decimal CalculateGiftAidAmount(decimal donationAmount, decimal taxRate)
        {
            if (donationAmount <= 0m) throw new ArgumentOutOfRangeException("donationAmount");
            if (taxRate <= 0m || taxRate >= 100m) throw new ArgumentOutOfRangeException("taxRate");

            return donationAmount * (taxRate / (100m - taxRate));
        }
    }
}
