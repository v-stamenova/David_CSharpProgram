using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please insert the length of the array: ");
            int length = int.Parse(Console.ReadLine());
            Console.WriteLine("Please insert a value on each line");
            double[] array = new double[length];
            int count = 0;
            while (count < length)
            {
                array[count] = double.Parse(Console.ReadLine());
                count++;
            }

            Console.WriteLine("In descending order or ascending? D/A");
            if(Console.ReadLine() == "D")
            {
                BubbleSortDesc(array);
            }
            else
            {
                BubbleSortAsc(array);
            }
            Console.WriteLine(string.Join(" ", array));
        }

        private static void BubbleSortAsc(double[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        double temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        private static void BubbleSortDesc(double[] array)
        {

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        double temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
}
