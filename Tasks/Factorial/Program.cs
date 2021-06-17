using System;
using System.Windows.Forms;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, do you want to open form? Y/N");

            if(Console.ReadLine() == "Y")
            {
                Application.EnableVisualStyles();
                Application.Run(new FactorialForm());
            }
            else
            {
                string toContinue = "Y";
                while(toContinue == "Y")
                {
                    int number;
                    Console.WriteLine("Please insert the number of which you want the factorial: ");

                    bool isItValid = int.TryParse(Console.ReadLine(), out number);
                    if (isItValid && number > 0)
                    {
                        Console.WriteLine("Do you want it by iteration or recursion? I/R");
                        if(Console.ReadLine() == "I")
                        {
                            Console.WriteLine(GetFactorialIteratively(number));
                        }
                        else
                        {
                            Console.WriteLine(GetFactorialRecursively(number));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please insert valid number");
                    }

                    Console.WriteLine("Do you wish to continue? Y/N");
                    toContinue = Console.ReadLine();
                }
            }
        }

        static ulong GetFactorialIteratively(int number)
        {
            ulong factorial = 1;
            for(int i = 2; i <= number; i++)
            {
                factorial *= (ulong)i;
            }

            return factorial;
        }

        static ulong GetFactorialRecursively(int number)
        {
            if(number == 1)
            {
                return 1;
            }
            else
            {
                return (ulong)number * GetFactorialRecursively(number - 1);
            }
        }
    }
}
