using System;
using System.Collections.Generic;
using System.Linq;

namespace CarsAndDrivers
{
	class Car
	{
		private string registrationNumber;
		private string model;
		private DateTime registrationDate;

		public string RegistrationNumber
		{
			get
			{
				return this.registrationNumber;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new Exception("The registration number cannot be empty");
				}
				else
				{
					this.registrationNumber = value;
				}
			}
		}

		public string Model
		{
			get
			{
				return this.model;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new Exception("The name of the model cannot be empty");
				}
				else
				{
					this.model = value;
				}
			}
		}

		public DateTime RegistrationDate
		{
			get; set;
		}

		public Car(string registrationNumber, string model, string registrationDate)
		{
			this.RegistrationNumber = registrationNumber;
			this.Model = model;
			List<int> date = registrationDate.Split('.').Select(int.Parse).ToList();
			this.RegistrationDate = new DateTime(date[2], date[1], date[0]);
		}
	}
}
