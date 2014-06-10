namespace GiftAidCalculator
{
    public class TaxRateStorageImpl : ITaxRateStorage
    {
        private decimal _taxRate;
        public decimal RetrieveTaxRate()
        {
            return _taxRate;
        }

        public void StoreTaxRate(decimal taxRate)
        {
            _taxRate = taxRate;
        }
    }
}
