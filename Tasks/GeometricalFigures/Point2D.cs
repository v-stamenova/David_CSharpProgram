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
			if(system != CoordinateSystem.Cartesian)
			{
				double x = firstCoord * Math.Cos(this.secondCoord);
				double y = firstCoord * Math.Sin(this.secondCoord);
				this.firstCoord = x;
				this.secondCoord = y;
			}
			else
			{
				this.firstCoord = firstCoord;
				this.secondCoord = secondCoord;
			}
		}

		public string PolarCoordinates()
		{
			if(this.coordinateSystem == CoordinateSystem.Cartesian)
			{
				double r = Math.Sqrt(Math.Pow(this.firstCoord, 2) + Math.Pow(this.secondCoord, 2));
				double phi = Math.Pow((this.secondCoord / this.firstCoord), -1);
				return $"( {r} , {phi} )";
			}
			return $"( {this.firstCoord} , {this.secondCoord} )";
		}

		public string CartesianCoordinates()
		{
			if(this.coordinateSystem == CoordinateSystem.Polar)
			{
				double x = this.firstCoord * Math.Cos(this.secondCoord);
				double y = this.firstCoord * Math.Sin(this.secondCoord);
				return $"( {x} , {y} )";
			}
			return $"( {this.firstCoord} , {this.secondCoord} )";
		}

		public double DistanceToPoint(Point2D point)
		{
			double squaredDistance = Math.Pow((point.firstCoord - this.firstCoord), 2) + Math.Pow((point.secondCoord - this.secondCoord), 2);
			return Math.Sqrt(squaredDistance);
		}
	}
}
