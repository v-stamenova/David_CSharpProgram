using System;
using System.Collections.Generic;

namespace SoftwareAcademy
{
	class Academy
	{
		private string name;
		private List<Student> students;
		private List<Course> courses;

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
					throw new Exception("The name of the course cannot be empty");
				}
				else
				{
					this.name = value;
				}
			}
		}

		public List<Student> Students { get => this.students; set => this.students = value; }

		public List<Course> Courses { get => this.courses; set => this.courses = value; }

		public Academy(string name)
		{
			this.Name = name;
			this.students = new List<Student>();
			this.courses = new List<Course>();
		}

		public void AddCourse(Course course)
		{
			this.courses.Add(course);
		}

		public void AddStudent(Student student)
		{
			this.students.Add(student);
		}

		public void AddStudentInCourse(int studentId, string courseName)
		{
			Student student = this.students.Find(x => x.Id == studentId);
			Course course = this.courses.Find(x => x.Name == courseName);
			student.AddCourse(course);
			course.AddStudent(student);
		}
	}
}
