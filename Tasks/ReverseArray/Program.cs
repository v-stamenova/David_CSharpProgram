using System;
using System.Collections.Generic;

namespace ReverseArray
{
	class Program
	{
		static int[] array;

		static void Main(string[] args)
		{
			Console.WriteLine("Do you want to specify the length of the array? Y/N");
			if(Console.ReadLine() == "Y")
			{
				SpecifyLengthOfTheArrayInput();
			}
			else
			{
				NotSpecifiedLengthOfTheArrayInput();
			}
			Console.WriteLine("Do you want to reverse the array iteratively or recursively? I/R");
			if (Console.ReadLine() == "I")
			{
				ReverseArrayIteratively();
			}
			else
			{
				ReverseArrayRecursively();
			}
			ShowArray();
		}

		static void SpecifyLengthOfTheArrayInput()
		{
			Console.Write("Please specify the length of the array: ");
			array = new int[int.Parse(Console.ReadLine())];

			Console.WriteLine("Please insert integers on seperate lines");
			int index = 0;
			while(index < array.Length)
			{
				int value;
				if(int.TryParse(Console.ReadLine(), out value))
				{
					array[index] = value;
					index++;
				}
				else
				{
					Console.WriteLine("Please insert a valid number");
				}
			}
		}

		static void NotSpecifiedLengthOfTheArrayInput()
		{
			List<int> insertedValues = new List<int>();
			string readLine = Console.ReadLine();

			while (!string.IsNullOrWhiteSpace(readLine))
			{
				int value;
				if (int.TryParse(readLine, out value))
				{
					insertedValues.Add(value);
				}

				readLine = Console.ReadLine();
			}

			array = insertedValues.ToArray();
		}

		static void ReverseArrayIteratively()
		{
			for(int i = 0; i < array.Length / 2; i++)
			{
				int temp = array[i];
				array[i] = array[array.Length - i - 1];
				array[array.Length - i - 1] = temp;
			}
		}

		static void ReverseArrayRecursively()
		{
			ReverseArrayRecursively(0, array.Length - 1);
		}

		private static void ReverseArrayRecursively(int start, int end)
		{
			if(start >= end)
			{
				return;
			}

			int temp = array[start];
			array[start] = array[end];
			array[end] = temp;

			ReverseArrayRecursively(start + 1, end - 1);
		}

		static void ShowArray()
		{
			Console.WriteLine(string.Join(" ", array));
		}
	}
}
