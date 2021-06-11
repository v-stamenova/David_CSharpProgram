using System;
using System.Text;
using System.Globalization;

namespace Greeting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Student's name: ");
            string studentName = Console.ReadLine();
            Console.Write("Course: ");
            string courseName = Console.ReadLine();

            string greeting = $"Здравейте {studentName}, и добре дошли в {courseName}!";
            Console.WriteLine(Environment.NewLine + greeting);
        }
    }
}
