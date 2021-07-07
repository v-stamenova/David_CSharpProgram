using System;
using System.Threading;

namespace Snow
{
	class Program
	{
		static char[,] grid;
		static void Main(string[] args)
		{
			Console.CursorVisible = false;
			grid = new char[Console.WindowHeight, Console.WindowWidth / 2];
			int snowflakesCount = 0;

			while (!Console.KeyAvailable && snowflakesCount != grid.Length)
			{
				MoveAllSnowflakesDown();

				NewLineOfSnowflakes();

				snowflakesCount = OutputAndSnowflakesCount();

				Thread.Sleep(1000);
			}
		}

		static void MoveAllSnowflakesDown()
		{
			for (int i = Console.WindowHeight - 2; i >= 0; i--)
			{
				for (int j = 0; j < Console.WindowWidth / 2; j++)
				{
					if (grid[i, j] == '*' && grid[i + 1, j] != '*')
					{
						grid[i, j] = ' ';
						grid[i + 1, j] = '*';
					}
				}
			}
		}

		static void NewLineOfSnowflakes()
		{
			Random r = new Random();

			for (int i = 0; i < Console.WindowWidth / 2; i++)
			{
				int isSnowflake = r.Next(0, 3);
				if (isSnowflake == 1)
				{
					grid[0, i] = '*';
				}
			}
		}

		static int OutputAndSnowflakesCount()
		{
			string output = "";
			int snowflakesCount = 0;
			for (int i = 0; i < Console.WindowHeight; i++)
			{
				for (int j = 0; j < Console.WindowWidth / 2; j++)
				{
					output += grid[i, j].ToString() + " ";
					if (grid[i, j] == '*')
						snowflakesCount++;
				}
				output += Environment.NewLine;
			}

			Console.WriteLine(output);
			Console.SetCursorPosition(0, 0);
			return snowflakesCount;
		}
	}
}
