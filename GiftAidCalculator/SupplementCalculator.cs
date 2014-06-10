using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftAidCalculator
{
    public class SupplementCalculator : ISupplementCalculator
    {
        private readonly IDictionary<EventType, decimal> _eventType2SupplementRate =
            new Dictionary<EventType, decimal>
            {
                {EventType.Running, 5m},
                {EventType.Swimming, 3m},
                {EventType.Other, 0m}
            };

        public decimal CalculateSupplementedAmount(decimal donationAmount, EventType eventType)
        {
            return donationAmount * _eventType2SupplementRate[eventType] / 100;
        }
    }
}
