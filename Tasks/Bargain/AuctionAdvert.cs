using System;

namespace Bargain
{
	class AuctionAdvert : Advert
	{
		private decimal startingPrice;
		private DateTime auctionTime;

		public decimal StartingPrice
		{
			get
			{
				return this.startingPrice;
			}
			set
			{
				if(value < 0)
				{
					throw new ArgumentException("The price cannot be less than zero");
				}
				else
				{
					this.startingPrice = value;
				}
			}
		}

		public DateTime AuctionTime
		{
			get
			{
				return this.auctionTime;
			}
			set
			{
				if(DateTime.Compare(value, this.RegistrationDate) < 0)
				{
					throw new ArgumentException("The starting time of the auction cannot be earlier than the registration time");
				}
				else
				{
					this.auctionTime = value;
				}
			}
		}

		public AuctionAdvert(string itemDescription, User registeredBy, decimal startingPrice, DateTime auctionTime) : base(itemDescription, registeredBy)
		{
			this.StartingPrice = startingPrice;
			this.AuctionTime = auctionTime;
		}
	}
}
