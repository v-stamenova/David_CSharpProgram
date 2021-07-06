using System;
using System.Collections.Generic;

namespace RationalNumbers
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Please choose operation (+  -  *  /  rec): ");
			string line = Console.ReadLine();
			while (!string.IsNullOrWhiteSpace(line))
			{
				switch (line)
				{
					case "+":
						Console.WriteLine(Addition().ToString());
						break;
					case "-":
						Console.WriteLine(Subtraction().ToString());
						break;
					case "*":
						Console.WriteLine(Multiplication().ToString());
						break;
					case "/":
						Console.WriteLine(Division().ToString());
						break;
					case "rec":
						Rational a = new Rational(int.Parse(Console.ReadLine().Split('/')[0]), int.Parse(Console.ReadLine().Split('/')[1]));
						Console.WriteLine(a.Reciprocal().ToString());
						break;
					default:
						Console.WriteLine("Invalid operation");
						break;
				}
				Console.WriteLine("Please choose operation (+  -  *  /  rec): ");
				line = Console.ReadLine();
			}
		}

		static Rational Addition()
		{
			Console.WriteLine("Please insert two rational numbers: the numerator and denumerator separated by / and the to rationals separated by space");
			
			string[] numbers = Console.ReadLine().Split(new Char[] { ' ', '/' }, StringSplitOptions.RemoveEmptyEntries);
			Rational a = new Rational(int.Parse(numbers[0]), int.Parse(numbers[1]));
			Rational b = new Rational(int.Parse(numbers[2]), int.Parse(numbers[3]));

			return a + b;
		}

		static Rational Subtraction()
		{
			Console.WriteLine("Please insert two rational numbers: the numerator and denumerator separated by / and the to rationals separated by space");

			string[] numbers = Console.ReadLine().Split(new Char[] { ' ', '/' }, StringSplitOptions.RemoveEmptyEntries);
			Rational a = new Rational(int.Parse(numbers[0]), int.Parse(numbers[1]));
			Rational b = new Rational(int.Parse(numbers[2]), int.Parse(numbers[3]));

			return a - b;
		}

		static Rational Multiplication()
		{
			Console.WriteLine("Please insert two rational numbers: the numerator and denumerator separated by / and the to rationals separated by space");

			string[] numbers = Console.ReadLine().Split(new Char[] { ' ', '/' }, StringSplitOptions.RemoveEmptyEntries);
			Rational a = new Rational(int.Parse(numbers[0]), int.Parse(numbers[1]));
			Rational b = new Rational(int.Parse(numbers[2]), int.Parse(numbers[3]));

			return a * b;
		}

		static Rational Division()
		{
			Console.WriteLine("Please insert two rational numbers: the numerator and denumerator separated by / and the to rationals separated by space");

			string[] numbers = Console.ReadLine().Split(new Char[] { ' ', '/' }, StringSplitOptions.RemoveEmptyEntries);
			Rational a = new Rational(int.Parse(numbers[0]), int.Parse(numbers[1]));
			Rational b = new Rational(int.Parse(numbers[2]), int.Parse(numbers[3]));

			return a / b;
		}
	}
}
