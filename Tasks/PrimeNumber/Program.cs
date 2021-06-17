using System;

namespace PrimeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert a number: ");
            int number = int.Parse(Console.ReadLine());

            if (IsItPrime(number))
            {
                Console.WriteLine($"The number {number} is prime");
            }
            else
            {
                Console.WriteLine($"The number {number} is NOT prime");
            }
        }

        static bool IsItPrime(int number)
        {
            if(number < 0)
            {
                return false;
            }

            for(int i = 2; i <= Math.Sqrt(number); i++)
            {
                if(number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
