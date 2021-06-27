using System;

namespace Library
{
	class Book : IndependantPrintedWork
	{
		private int edition;
		private bool hardCover;
		private bool illustrations;

		public int Edition { get => this.edition; set => this.edition = value; }

		public bool HardCover { get => this.hardCover; set => this.hardCover = value; }

		public bool Illustrations { get => this.illustrations; set => this.illustrations = value; }

		public Book(int edition, bool hardCover, bool illustrations, DateTime publishingDate, string author, int pages, string title, string language, string publishing)
			: base(publishingDate, author, pages, title, language, publishing)
		{
			this.edition = edition;
			this.hardCover = hardCover;
			this.illustrations = illustrations;
		}
	}
}
