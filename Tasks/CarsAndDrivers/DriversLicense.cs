using System;
using System.Collections.Generic;
using System.Linq;

namespace CarsAndDrivers
{
	class DriversLicense
	{
		private string number;
		private DateTime dateOfIssue;
		private string authority;
		private DateTime dateOfExpiry;

		public string Number
		{
			get
			{
				return this.number;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new Exception("The number of the document cannot be empty");
				}
				else
				{
					this.number = value;
				}
			}
		}

		public DateTime DateOfIssue { get => this.dateOfIssue; set => this.dateOfIssue = value; }

		public string Authority
		{
			get
			{
				return this.authority;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new Exception("The authority cannot be empty");
				}
				else
				{
					this.authority = value;
				}
			}
		}

		public DateTime DateOfExpiry
		{
			get
			{
				return this.dateOfExpiry;
			}
			set
			{
				if (DateTime.Compare(this.dateOfIssue, value) > 0)
				{
					throw new Exception("The date of expiry cannot be earlier than the date of issue");
				}
				else
				{
					this.dateOfIssue = value;
				}
			}	
		}

		public DriversLicense(string number, string authority, string dateOfIssue, string dateOfExpiry)
		{
			this.Number = number;
			this.Authority = authority;
			List<int> date = dateOfIssue.Split('.').Select(int.Parse).ToList();
			this.DateOfIssue = new DateTime(date[2], date[1], date[0]);
			date = dateOfExpiry.Split('.').Select(int.Parse).ToList();
			this.dateOfExpiry = new DateTime(date[2], date[1], date[0]);
		}
	}
}
