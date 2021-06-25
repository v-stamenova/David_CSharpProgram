using System;
using System.Collections.Generic;
using System.Linq;

namespace MeteorologicalInformation
{
	class Program
	{
		static void Main(string[] args)
		{
			List<HourlyData> allData = new List<HourlyData>();
			int hourCount = 0;

			while(hourCount < 24)
			{
				HourlyData data = new HourlyData();

				Console.WriteLine($"{hourCount}:00");

				Console.Write("Real temperature: ");
				data.RealTemp = double.Parse(Console.ReadLine());

				Console.Write("Temperature feels like: ");
				data.FeltTemp = double.Parse(Console.ReadLine());

				Console.Write("Atmospheric pressure: ");
				data.AtmPressure = double.Parse(Console.ReadLine());

				Console.Write("Is there a wind? Y/N: ");
				if(Console.ReadLine() == "Y")
				{
					data.IsWindy = true;
					Console.Write("Wind speed: ");
					data.WindSpeed = double.Parse(Console.ReadLine());
				}
				else
				{
					data.IsWindy = false;
					data.WindSpeed = 0;
				}

				Console.Write("Is it raining? Y/N: ");
				if (Console.ReadLine() == "Y")
				{
					data.IsRaining = true;
				}
				else
				{
					data.IsRaining = false;
				}

				Console.Write("Is it fogy? Y/N: ");
				if (Console.ReadLine() == "Y")
				{
					data.IsFoggy = true;
				}
				else
				{
					data.IsFoggy = false;
				}

				allData.Add(data);
				hourCount++;
				Console.Clear();
			}

			Console.WriteLine($"Max real temperature: {allData.Max(x => x.RealTemp)}");
			Console.WriteLine($"Min real temperature: {allData.Min(x => x.RealTemp)}");
			Console.WriteLine($"Max felt temperature: {allData.Max(x => x.FeltTemp)}");
			Console.WriteLine($"Min felt temperature: {allData.Min(x => x.FeltTemp)}");
			Console.WriteLine($"Max atmospheric pressure: {allData.Max(x => x.AtmPressure)}");
			Console.WriteLine($"Min atmospheric pressure: {allData.Min(x => x.AtmPressure)}");
			Console.WriteLine($"Max wind speed: {allData.Max(x => x.WindSpeed)}");
			Console.WriteLine($"Min wind speed: {allData.Min(x => x.WindSpeed)}");
		}
	}
}
