using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricalFigures
{
	class Vector2D : Point2D
	{
		public Vector2D(double firstCoord, double secondCoord) : base(firstCoord, secondCoord)
		{
		
		}

		public Vector2D(double firstCoord, double secondCoord, CoordinateSystem system) : base(firstCoord, secondCoord, system)
		{

		}

		public string AddVector(Vector2D vector)
		{
			return $"( {vector.FirstCoord + this.FirstCoord} , {vector.SecondCoord + this.SecondCoord} ";
		}

		public string SubtractVector(Vector2D vector)
		{
			return $"( {vector.FirstCoord - this.FirstCoord} , {vector.SecondCoord - this.SecondCoord} ";
		}
	}
}
