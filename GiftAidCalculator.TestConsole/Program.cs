using System;

namespace GiftAidCalculator.TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Please Enter donation amount:");
			Console.WriteLine(GiftAidAmount(decimal.Parse(Console.ReadLine())));
			Console.WriteLine("Press any key to exit.");
			Console.ReadLine();
		}

		static decimal GiftAidAmount(decimal donationAmount)
		{
		    var storage = new TaxRateStorageImpl();
            storage.StoreTaxRate(25m);

		    var donationEngine = new DonationEngine(
                storage, 
                new GiftAidCalculator(),
		        new SupplementCalculator());

		    var info = donationEngine.Donate(donationAmount, EventType.Other);

		    return info.GiftAidRounded;
		}
	}
}
