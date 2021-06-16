using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            Console.WriteLine("Insert students and their grades for example -> Michael: 5 6 3,5");
            Console.WriteLine("If you want to stop inserting students insert END");

            List<string> readLine = Console.ReadLine().Split(' ').ToList();
            while(readLine[0] != "END")
            {
                Student student = new Student(readLine[0]);
                readLine.RemoveAt(0);
                AddGrades(student, readLine.Select(double.Parse).ToList());
                students.Add(student);
                readLine = Console.ReadLine().Split(' ').ToList();
            }

            Console.WriteLine(Environment.NewLine + "-----------" + Environment.NewLine);

            double sumOfAverageGrades = 0;
            foreach(Student student in students)
            {
                Console.WriteLine($"{student.Name} - {Math.Round(student.AverageGrade(), 2)}");
                sumOfAverageGrades += student.AverageGrade();
            }

            Console.WriteLine($"Average class grade: {Math.Round((sumOfAverageGrades / students.Count), 2)}");
        }

        static void AddGrades(Student student, List<double> grades)
        {
            grades.RemoveAll(x => x < 2 || x > 6);
            student.Grades = grades;
        }
    }
}
