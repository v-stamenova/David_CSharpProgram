using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageGradeOfClass
{
    class Program
    {
        static void Main(string[] args)
        {
            int grade = 1;
            int sumOfGrades = 0;
            int countOfGrades = 0;

            Console.WriteLine("Please insert a grade between 2 and 6, if you wish to terminate insert 0");
            while(grade != 0)
            {
                grade = int.Parse(Console.ReadLine());
                
                if((grade < 2 && grade != 0) || grade > 6)
                {
                    Console.WriteLine("Invalid grade: Please insert value between 2 and 6");
                }
                else if(grade != 0)
                {
                    sumOfGrades += grade;
                    countOfGrades++;
                }
            }

            Console.WriteLine($"Average grade: {(double)sumOfGrades / countOfGrades}");
        }
    }
}
