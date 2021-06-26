using System;
using System.Collections.Generic;

namespace CarsAndDrivers
{
	class Driver
	{
		private string fullName;
		private DriversLicense license;
		private List<Car> cars;

		public string FullName
		{
			get
			{
				return this.fullName;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(fullName))
				{
					throw new Exception("The driver's names cannot be empty");
				}
				else
				{
					this.fullName = value;
				}
			}
		}

		public DriversLicense License { get => this.license; set => this.license = value; }

		public List<Car> Cars { get => this.cars; set => this.cars = value; }

		public Driver(string fullName)
		{
			this.FullName = fullName;
			this.cars = new List<Car>();
		}
	}
}
