using System;
using System.Collections.Generic;
using System.Linq;

namespace TermGrades
{
    public class Student
    {
        private string name;
        private List<double> grades;
        
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }
                this.name = value;
            }
        }

        public List<double> Grades
        {
            get
            {
                return this.grades;
            }
            set
            {
                this.grades = value;
            }
        }

        public Student(string name)
        {
            this.Name = name;
            this.Grades = new List<double>();
        }

        public void AddGrade(double grade)
        {
            this.grades.Add(grade);
        }

        public double AverageGrade()
        {
            return this.grades.Average();
        }
    }
}
