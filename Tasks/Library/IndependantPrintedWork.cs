using System;

namespace Library
{
	abstract class IndependantPrintedWork : PrintedWork
	{
		private DateTime publishingDate;
		private string author;
		private int pages;

		public DateTime PublishingDate { get => this.publishingDate; set => this.publishingDate = value; }

		public string Author { get => this.author; set => this.author = value; }

		public int Pages { get => this.pages; set => this.pages = value; }

		public IndependantPrintedWork(DateTime publishingDate, string author, int pages, string title, string language, string publishing) : base(title, language, publishing)
		{
			this.publishingDate = publishingDate;
			this.author = author;
			this.pages = pages;
		}
	}
}
