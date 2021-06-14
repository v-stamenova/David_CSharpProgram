using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiggestAndSmallestElementOfArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please insert the length of the array: ");
            int length = int.Parse(Console.ReadLine());
            Console.WriteLine("Please insert a value on each line");
            int[] array = new int[length];
            int count = 0;
            while(count < length)
            {
                array[count] = int.Parse(Console.ReadLine());
                count++;
            }
            Console.WriteLine($"Biggest element: {BiggestElement(array)}, Smallest element: {SmallestElement(array)}, Average: {Average(array)}");
        }

        private static int BiggestElement(int[] array)
        {
            int biggestElement = array[0];
            for(int i = 0; i < array.Length; i++)
            {
                if(biggestElement < array[i])
                {
                    biggestElement = array[i];
                }
            }
            return biggestElement;
        }

        private static int SmallestElement(int[] array)
        {
            int smallestElement = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (smallestElement > array[i])
                {
                    smallestElement = array[i];
                }
            }
            return smallestElement;
        }

        private static double Average(int[] array)
        {
            double sum = 0;
            for(int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum / array.Length;
        }
    }
}
