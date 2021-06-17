using System;

namespace InversionsInArray
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
            while (count < length)
            {
                array[count] = int.Parse(Console.ReadLine());
                count++;
            }

            Console.WriteLine($"{Environment.NewLine}Count of inversions: {InversionsCount(array)}");
        }

        private static int InversionsCount(int[] array)
        {
            int count = 0;
            for(int i = 0; i < array.Length; i++)
            {
                for(int j = i + 1; j < array.Length; j++)
                {
                    if(array[i] > array[j])
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
