using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareAcademy
{
	class Student
	{
		private static int numberOfStudents = 0;
		private int id;
		private string givenName;
		private string middleName;
		private string familyName;
		private List<Course> courses;

		public int Id { get => this.id; set => this.id = value; }

		public string GivenName
		{
			get
			{
				return this.givenName;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new Exception("The given name cannot be empty");
				}
				else
				{
					this.givenName = value;
				}
			}
		}

		public string MiddleName
		{
			get
			{
				return this.middleName;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new Exception("The middle name cannot be empty");
				}
				else
				{
					this.middleName = value;
				}
			}
		}

		public string FamilyName
		{
			get
			{
				return this.familyName;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new Exception("The family name cannot be empty");
				}
				else
				{
					this.familyName = value;
				}
			}
		}

		public List<Course> Courses { get => this.courses; set => this.courses = value; }

		public Student(string givenName, string middleName, string familyName)
		{
			this.id = numberOfStudents;
			numberOfStudents++;
			this.GivenName = givenName;
			this.MiddleName = middleName;
			this.FamilyName = familyName;
			this.courses = new List<Course>();
		}

		public void AddCourse(Course course)
		{
			this.courses.Add(course);
		}
	}
}
