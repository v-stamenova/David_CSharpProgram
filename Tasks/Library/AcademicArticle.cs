using System;

namespace Library
{
	class AcademicArticle : IndependantPrintedWork
	{
		private string scientificField;
		private string suggestedLiterature;

		public string ScientificField { get => this.scientificField; set => this.scientificField = value; }

		public string SuggestedLiterature { get => this.suggestedLiterature; set => this.suggestedLiterature = value; }

		public AcademicArticle(string scientificField, string suggestedLiterature, DateTime publishingDate, string author, int pages, string title, string language, string publishing)
			: base(publishingDate, author, pages, title, language, publishing)
		{
			this.scientificField = scientificField;
			this.suggestedLiterature = suggestedLiterature;
		}
	}
}
