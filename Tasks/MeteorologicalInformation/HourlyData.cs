using System;
using System.Collections.Generic;
using System.Text;

namespace MeteorologicalInformation
{
	class HourlyData
	{
		public double RealTemp;
		public double FeltTemp;
		public bool IsWindy;
		public double WindSpeed;
		public bool IsFoggy;
		public bool IsRaining;
		public double AtmPressure;

		public HourlyData()
		{

		}

		public HourlyData(double realTemp, double feltTemp, bool isWindy, double windSpeed, bool isFoggy, bool isRaining, double atmPressure)
		{
			this.RealTemp = realTemp;
			this.FeltTemp = feltTemp;
			this.IsWindy = isWindy; 
			this.WindSpeed = windSpeed;
			this.IsFoggy = isFoggy;
			this.IsRaining = isRaining;
			this.AtmPressure = atmPressure;
		}
	}
}
