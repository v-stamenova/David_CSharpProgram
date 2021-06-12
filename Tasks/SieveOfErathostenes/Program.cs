using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieveOfErathostenes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert a number, to see all prime numbers up to it:");
            int number = int.Parse(Console.ReadLine());

            List<int> primeNumbers = AlgorithmOfErathostens(number);
            Console.WriteLine(string.Join(" ", primeNumbers));
        }

        static List<int> AlgorithmOfErathostens(int number)
        {
            List<int> primeNumbers = new List<int>();
            for (int i = 1; i <= number; i++)
                primeNumbers.Add(i);

            for (int i = 2; i <= number; i++)
            {
                for (int j = 2 * i; j <= number; j += i)
                {
                    primeNumbers.Remove(j);
                }
            }

            return primeNumbers;
        }
    }
}
