using System;
using System.Collections.Generic;
using System.Linq;

namespace GeometricalFigures
{
	class Point2D
	{
		private double firstCoord;
		private double secondCoord;
		private CoordinateSystem coordinateSystem;

		public double FirstCoord
		{
			get
			{
				return this.firstCoord;
			}
			set
			{
				this.firstCoord = value;
			}
		}

		public double SecondCoord
		{
			get
			{
				return this.secondCoord;
			}
			set
			{
				this.secondCoord = value;
			}
		}

		public Point2D(double firstCoord, double secondCoord)
		{
			this.firstCoord = firstCoord;
			this.secondCoord = secondCoord;
			this.coordinateSystem = CoordinateSystem.Cartesian;
		}

		public Point2D(double firstCoord, double secondCoord, CoordinateSystem system)
		{
			this.firstCoord = firstCoord;
			this.secondCoord = secondCoord;
			this.coordinateSystem = system;
		}

		public string PolarCoordinates()
		{
			if(this.coordinateSystem == CoordinateSystem.Cartesian)
			{
				double r = Math.Sqrt(Math.Pow(this.firstCoord, 2) + Math.Pow(this.secondCoord, 2));
				double phi = Math.Pow((this.secondCoord / this.firstCoord), -1);
				return $"r: {r} θ: {phi}";
			}
			return $"r: {this.firstCoord} θ: {this.secondCoord}";
		}

		public string CartesianCoordinates()
		{
			if(this.coordinateSystem == CoordinateSystem.Polar)
			{
				double x = this.firstCoord * Math.Cos(this.secondCoord);
				double y = this.firstCoord * Math.Sin(this.secondCoord);
				return $"x: {x} y: {y}";
			}
			return $"x: {this.firstCoord} y: {this.secondCoord}";
		}

		public double DistanceToPoint(Point2D point)
		{
			List<string> thisData = CartesianCoordinates().Split(' ').ToList();
			List<string> pointData = point.CartesianCoordinates().Split(' ').ToList();
			double squaredDistance = Math.Pow(double.Parse(thisData[1]) - double.Parse(pointData[1]), 2) + Math.Pow(double.Parse(thisData[3]) - double.Parse(pointData[3]), 2);
			return Math.Sqrt(squaredDistance);
		}
	}
}
