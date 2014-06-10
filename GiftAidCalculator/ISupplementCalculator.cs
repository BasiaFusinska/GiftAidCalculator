using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftAidCalculator
{
    public interface ISupplementCalculator
    {
        decimal CalculateSupplementedAmount(decimal donationAmount, EventType eventType);
    }
}
