using System;

namespace Library
{
	class Fiction : Book
	{
		private string genre;
		private string targetAudience;

		public string Genre { get => this.genre; set => this.genre = value; }

		public string TargetAudience { get => this.targetAudience; set => this.targetAudience = value; }

		public Fiction(string genre, string targetAudience, int edition, bool hardCover, bool illustrations, DateTime publishingDate, string author, int pages, string title, string language, string publishing)
			: base(edition, hardCover, illustrations, publishingDate, author, pages, title, language, publishing)
		{
			this.genre = genre;
			this.targetAudience = targetAudience;
		}
	}
}
