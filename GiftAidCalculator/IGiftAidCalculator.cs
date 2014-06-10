namespace GiftAidCalculator
{
    public interface IGiftAidCalculator
    {
        decimal CalculateGiftAidAmount(decimal donationAmount, decimal taxRate);
    }
}
