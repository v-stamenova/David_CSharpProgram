using System;
using System.Collections.Generic;

namespace SoftwareAcademy
{
	class Course
	{
		private string name;
		private string email;
		private List<Student> students;

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

		public string Email
		{
			get
			{
				return this.email;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new Exception("The email cannot be empty");
				}
				else
				{
					this.email = value;
				}
			}
		}

		public List<Student> Students { get => this.students; set => this.students = value; }


		public Course(string name, string email)
		{
			this.Name = name;
			this.Email = email;
			this.students = new List<Student>();
		}

		public void AddStudent(Student student)
		{
			this.students.Add(student);
		}
	}
}
