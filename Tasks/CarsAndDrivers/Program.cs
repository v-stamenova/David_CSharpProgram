using System;
using System.Collections.Generic;

namespace CarsAndDrivers
{
	class Program
	{
		static List<DriversLicense> driversLicenses = new List<DriversLicense>();
		static List<Car> cars = new List<Car>();
		static List<Driver> drivers = new List<Driver>();
		static void Main(string[] args)
		{
			Console.Write("Do you wish to register drivers licence, driver, car or check them? DL/D/C/CDL/CD/CC: ");
			string result = Console.ReadLine();
			while (!string.IsNullOrWhiteSpace(result))
			{
				switch (result)
				{
					case "DL":
						driversLicenses.Add(RegisterDriversLicense());
						break;
					case "C":
						cars.Add(RegisterCar());
						break;
					case "D":
						drivers.Add(RegisterDriver());
						break;
					case "CDL":
						foreach(DriversLicense d in driversLicenses)
						{
							Console.WriteLine($"{d.Number}, {d.Authority}, {d.DateOfIssue} - {d.DateOfExpiry}");
						}
						break;
					case "CD":
						foreach(Driver d in drivers)
						{
							Console.WriteLine($"{d.FullName} - {d.License.Number}: {string.Join(", ", d.Cars)}");
						}
						break;
					case "CC":
						foreach(Car c in cars)
						{
							Console.WriteLine($"{c.Model} - {c.RegistrationNumber}, {c.RegistrationDate}");
						}
						break;
				}
			}
		}

		private static DriversLicense RegisterDriversLicense()
		{
			Console.Write("Insert the number of the license: ");
			string number = Console.ReadLine();
			Console.Write("Insert the authority: ");
			string authority = Console.ReadLine();
			Console.Write("Insert the date of issue (example - 12.2.2005): ");
			string issueDate = Console.ReadLine();
			Console.WriteLine("Insert the date of expiry: ");
			string expiryDate = Console.ReadLine();

			return new DriversLicense(number, authority, issueDate, expiryDate);
		}

		private static Car RegisterCar()
		{
			Console.Write("Insert the registration number of the car: ");
			string number = Console.ReadLine();
			Console.Write("Insert the model of the car: ");
			string model = Console.ReadLine();
			Console.Write("Insert the registration date of the car: ");
			string date = Console.ReadLine();

			return new Car(number, model, date);
		}

		private static Driver RegisterDriver()
		{
			Console.Write("Insert the driver's name: ");
			string name = Console.ReadLine();

			Driver driver = new Driver(name);

			Console.Write("Does that driver has an already registered license? Y/N: ");
			string answer = Console.ReadLine();
			DriversLicense license;
			if(answer == "Y")
			{
				Console.WriteLine("Please insert the drivers license number: ");
				string number = Console.ReadLine();
				license = driversLicenses.Find(x => x.Number == number);
			}
			else
			{
				license = RegisterDriversLicense();
				driversLicenses.Add(license);
			}
			driver.License = license;

			Console.WriteLine("How many cars does the driver has? ");
			int countOfCars = int.Parse(Console.ReadLine());
			int count = 0;
			while(count < countOfCars)
			{
				Console.Write($"Is car #{count + 1} already regitered? Y/N");
				answer = Console.ReadLine();
				Car car;
				if(answer == "Y")
				{
					Console.WriteLine("Please insert the car regiter number: ");
					string number = Console.ReadLine();
					car = cars.Find(x => x.RegistrationNumber == number);
				}
				else
				{
					car = RegisterCar();
					cars.Add(car);
				}
				driver.Cars.Add(car);
				count++;
			}
			return driver;
		}
	}
}
