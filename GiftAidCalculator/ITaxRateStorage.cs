using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftAidCalculator
{
    public interface ITaxRateStorage
    {
        decimal RetrieveTaxRate();
        void StoreTaxRate(decimal taxRate);
    }
}
