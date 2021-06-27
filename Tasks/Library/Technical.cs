using System;

namespace Library
{
	class Technical : Book
	{
		private string scientificField;
		private Level auditoryLevel;

		public string ScientificField { get => this.scientificField; set => this.scientificField = value; }

		public Level AuditoryLevel { get => this.auditoryLevel; set => this.auditoryLevel = value; }

		public Technical(string scientificField, Level auditoryLevel, int edition, bool hardCover, bool illustrations, DateTime publishingDate, string author, int pages, string title, string language, string publishing)
			: base(edition, hardCover, illustrations, publishingDate, author, pages, title, language, publishing)
		{
			this.scientificField = scientificField;
			this.auditoryLevel = auditoryLevel;
		}
	}
}
