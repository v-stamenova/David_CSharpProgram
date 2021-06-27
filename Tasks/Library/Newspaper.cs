using System;

namespace Library
{
	class Newspaper : PeriodicPrintedWork
	{
		private PublishingPeriod period;
		private string chiefEditor;
		private string breakingNews;

		public PublishingPeriod Period { get => this.period; set => this.period = value; }

		public string ChiefEditor
		{
			get
			{
				return this.chiefEditor;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new Exception("The name of the chief editor cannot be empty");
				}
				else
				{
					this.chiefEditor = value;
				}
			}
		}

		public string BreakingNews { get => this.breakingNews; set => this.breakingNews = value; }

		public Newspaper(PublishingPeriod period, string chiefEditor, string breakingNews, string title, string language, string publishing, int year, int number) 
			: base(title, language, publishing, year, number)
		{
			this.period = period;
			this.ChiefEditor = chiefEditor;
			this.breakingNews = breakingNews;
		}
	}
}
