using System;

namespace Bargain
{
	abstract class Advert
	{
		private string itemDescription;
		private User registeredBy;
		private DateTime registrationDate;
		private bool active;
		private User? wonBy;
		private DateTime? endDate;

		public string ItemDescription
		{
			get
			{
				return this.itemDescription;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException("The item description cannot be empty");
				}
				else
				{
					this.itemDescription = value;
				}
			}
		}

		public User RegisteredBy { get => this.registeredBy; }

		public DateTime RegistrationDate { get => this.registrationDate; }

		public bool Active { get => this.active; set => this.active = value; }

		public User? WonBy { get => this.wonBy; }

		public DateTime? EndDate
		{
			get
			{
				return this.endDate;
			}
			set
			{
				if(!(value is null))
				{
					if (DateTime.Compare((DateTime)value, this.registrationDate) < 0)
					{
						throw new ArgumentException("The end date cannot be earlier than the registration date");
					}
				}

				this.endDate = value;
			}
		} 

		public Advert(string itemDescription, User registeredBy)
		{
			this.ItemDescription = itemDescription;
			this.registeredBy = registeredBy;
			this.registrationDate = DateTime.Now;
			this.active = true;
			registeredBy.RegisteredAdverts.Add(this);
		}

		public void EndAdvert(User winner)
		{
			this.wonBy = winner;
			this.active = false;
			this.endDate = DateTime.Now;
			winner.WonAdverts.Add(this);
		}
	}
}
