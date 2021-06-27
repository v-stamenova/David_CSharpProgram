using System;

namespace Library
{
	abstract class PrintedWork
	{
		private string title;
		private string language;
		private string publishing;

		public string Title
		{
			get
			{
				return this.title;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new Exception("The title cannot be empty");
				}
				else
				{
					this.title = value;
				}
			}
		}

		public string Language
		{
			get
			{
				return this.language;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new Exception("The language cannot be empty");
				}
				else
				{
					this.language = value;
				}
			}
		}

		public string Publishing
		{
			get
			{
				return this.publishing;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new Exception("The publishing house's name cannot be empty");
				}
				else
				{
					this.publishing = value;
				}
			}
		}

		public PrintedWork(string title, string language, string publishing)
		{
			this.Title = title;
			this.Language = language;
			this.Publishing = publishing;
		}
	}
}
