using System;

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

            string greeting = $"Hello {studentName}, and welcome to {courseName}!";
            Console.WriteLine(Environment.NewLine + greeting);
        }
    }
}
