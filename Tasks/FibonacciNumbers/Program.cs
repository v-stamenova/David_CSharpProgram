using System;

namespace FibonacciNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert a number to find the Fibonacci number on that position:");
            int number;
            bool isItValid = int.TryParse(Console.ReadLine(), out number);
            if (isItValid && number > 0)
            {
                Console.WriteLine($"Fibonacci number #{number}: {Fibonacci(number)}");
            }
            else
            {
                Console.WriteLine($"The number is not valid");  
            }
        }

        static int Fibonacci(int number)
        {
            if (number <= 1)
            {
                return number;
            }
            else
            {
                return Fibonacci(number - 1) + Fibonacci(number - 2);
            }
        }
    }
}
