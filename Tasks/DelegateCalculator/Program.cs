using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegateCalculator
{
	class Program
	{
		static void Main(string[] args)
		{
            Func<double, double, double> add = (x, y) => x + y;
            Func<double, double, double> subtract = (x, y) => x - y;
            Func<double, double, double> multiply = (x, y) => x * y;
            Func<double, double, double> divide = (x, y) => x / y;

            Dictionary<string, Func<double, double, double>> mathMap = new Dictionary<string, Func<double, double, double>>()
            {
                { "+", add },
                { "-", subtract },
                { "*", multiply },
                { "/", divide }
            };

            Console.WriteLine("Please insert the operands and the operation (for example: 5 + 3)");
            string readLine = Console.ReadLine();

            while (readLine != "End")
            {
				if (string.IsNullOrWhiteSpace(readLine))
				{
                    Console.WriteLine("Please insert valid info");
				}
                else if(readLine.Split(' ').ToList().Count != 3)
				{
                    Console.WriteLine("Please insert two values sepereted with spaces and operator");
				}
				else
				{
                    List<string> data = readLine.Split(' ').ToList();
					if (mathMap.ContainsKey(data[1]))
					{
                        Console.WriteLine($"{string.Join(" ", data)} = {mathMap[data[1]](double.Parse(data[0]), double.Parse(data[2]))}");
                    }
					else
					{
                        Console.WriteLine("The operator is invalid");
					}
                }

                readLine = Console.ReadLine();
            }            
        }
	}
}
