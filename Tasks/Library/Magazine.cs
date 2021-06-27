namespace Library
{
	class Magazine : PeriodicPrintedWork
	{
		private string theme;
		private string authorTeam;
		private string coverDescription;

		public string Theme { get => this.theme; set => this.theme = value; }

		public string AuthorTeam { get => this.authorTeam; set => this.authorTeam = value; }

		public string CoverDescription { get => this.coverDescription; set => this.coverDescription = value; }


		public Magazine(string theme, string authorTeam, string coverDescription, string title, string language, string publishing, int year, int number)
			: base(title, language, publishing, year, number)
		{
			this.theme = theme;
			this.authorTeam = authorTeam;
			this.coverDescription = coverDescription;
		}
	}
}
