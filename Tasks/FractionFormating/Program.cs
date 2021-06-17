using System;

namespace FractionFormating
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Please insert a fraction: ");
			double fraction = double.Parse(Console.ReadLine());
			Console.Write("Please insert the number of decimal places you want: ");
			int places = int.Parse(Console.ReadLine());
			Console.WriteLine(Math.Round(fraction, places));
		}
	}
}
