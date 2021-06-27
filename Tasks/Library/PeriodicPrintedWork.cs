namespace Library
{
	abstract class PeriodicPrintedWork : PrintedWork
	{
		private int year;
		private int number;

		public int Year { get => this.year; set => this.year = value; }

		public int Number { get => this.number; set => this.number = value; }

		public PeriodicPrintedWork(string title, string language, string publishing, int year, int number) : base(title, language, publishing) 
		{
			this.year = year;
			this.number = number;
		}
	}
}
