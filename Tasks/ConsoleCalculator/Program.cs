using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert the operands and the operation (for example: 5 + 3)");
            List<string> readLine = Console.ReadLine().Split(' ').ToList();

            while(readLine[0] != "End")
            {
                switch (readLine[1])
                {
                    case "+":
                        Console.WriteLine($"{readLine[0]} + {readLine[2]} = {double.Parse(readLine[0]) + double.Parse(readLine[2])}");
                        break;
                    case "-":
                        Console.WriteLine($"{readLine[0]} - {readLine[2]} = {double.Parse(readLine[0]) - double.Parse(readLine[2])}");
                        break;
                    case "*":
                        Console.WriteLine($"{readLine[0]} * {readLine[2]} = {double.Parse(readLine[0]) * double.Parse(readLine[2])}");
                        break;
                    case "/":
                        if(readLine[2] == "0")
                        {
                            Console.WriteLine("Cannot divide by zero");
                        }
                        else
                        {
                            Console.WriteLine($"{readLine[0]} / {readLine[2]} = {double.Parse(readLine[0]) / double.Parse(readLine[2])}");
                        }
                        break;
                }
                readLine = Console.ReadLine().Split(' ').ToList();
            }

        }
    }
}
