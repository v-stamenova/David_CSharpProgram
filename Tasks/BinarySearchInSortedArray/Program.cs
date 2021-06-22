using System;

namespace BinarySearchInSortedArray
{
	class Program
	{
		static int[] array;
		static void Main(string[] args)
		{
			Console.Write("Insert the length of the array: ");
			array = new int[int.Parse(Console.ReadLine())];
			int count = 0;
			while(count < array.Length)
			{
				array[count] = int.Parse(Console.ReadLine());
				count++;
			}
			if (CheckIfSorted())
			{
				Console.Write("Insert the element you want to find: ");
				int element = int.Parse(Console.ReadLine());
				Console.WriteLine("How do you want to find it, iteratively or recursively? I/R");
				int result = 0;
				if(Console.ReadLine() == "I")
				{
					result = BinSearchArrayIteratively(element);
				}
				else
				{
					result = BinSearchArrayRecursively(0, array.Length, element);
				}

				if(result == -1)
				{
					Console.WriteLine("The element is not present");
				}
				else
				{
					Console.WriteLine($"The element {element} is on position {result}");
				}
			}
			else
			{
				Console.WriteLine("The array was not sorted");
			}
		}

		static int BinSearchArrayRecursively(int left, int right, int searchedEl)
		{
			if(left < right)
			{
				int middle = (left + right) / 2;

				if(array[middle] == searchedEl)
				{
					return middle;
				}

				if(array[middle] > searchedEl)
				{
					BinSearchArrayRecursively(left, middle--, searchedEl);
				}
				else
				{
					BinSearchArrayRecursively(middle++, right, searchedEl);
				}
			}
			return -1;
		}

		static bool CheckIfSorted()
		{
			for(int i = 0; i < array.Length - 1; i++)
			{
				if(array[i] > array[i + 1])
				{
					return false;
				}
			}
			return true;
		}

		static int BinSearchArrayIteratively(int searchedEl)
		{
			int left = 0;
			int right = array.Length;
			while (left < right)
			{
				int middle = (left + right) / 2;

				if (array[middle] == searchedEl)
				{
					return middle;
				}

				if (array[middle] > searchedEl)
				{
					right = middle--;
				}
				else
				{
					left = middle++;
				}
			}
			return -1;
		}
	}
}
