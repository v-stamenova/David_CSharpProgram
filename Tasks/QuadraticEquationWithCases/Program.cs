using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquationWithCases
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ax^2 + bx + c = 0");

            Console.Write("a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("c: ");
            int c = int.Parse(Console.ReadLine());

            double d = Math.Pow(b, 2) - (4 * a * c);

            if(d < 0)
            {
                Console.WriteLine("The equation has no real roots");
            }
            else if(d == 0)
            {
                Console.WriteLine($"x = {(double)(-b) / (2 * a)}");
            }
            else
            {
                double x1 = (-b + Math.Sqrt(d)) / (2 * a);
                double x2 = (-b - Math.Sqrt(d)) / (2 * a);
                Console.WriteLine($"x1 = {x1}, x2 = {x2}");
            }
        }
    }
}
