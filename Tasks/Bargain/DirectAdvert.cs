using System;

namespace Bargain
{
	class DirectAdvert : Advert
	{
		private decimal fixedPrice;

		public decimal FixedPrice
		{
			get
			{
				return this.fixedPrice;
			}
			set
			{
				if(value < 0)
				{
					throw new ArgumentException("The price cannot be less than zero");
				}
				else
				{
					this.fixedPrice = value;
				}
			}
		}

		public DirectAdvert(string itemDescription, User registeredBy, decimal fixedPrice) : base(itemDescription, registeredBy)
		{
			this.FixedPrice = fixedPrice;
		}


	}
}
