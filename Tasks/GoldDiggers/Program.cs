using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldDiggers
{
	class Program
	{
		static Field[,] fields;

		static void Main(string[] args)
		{
			string output = GetFieldBounds(100, 100);
			List<int> values = output.Split(' ').Select(int.Parse).ToList();
			CreateField(values[0], values[1]);
			DrawField(values[0], values[1]);
			Console.ResetColor();
		}

		static string GetFieldBounds(int maxX, int maxY)
		{
			Console.Write($"Please insert a value for x in the interval [10, {maxX}]: ");
			string output = "";
			string inserted = Console.ReadLine();
			int num;

			if (string.IsNullOrWhiteSpace(inserted))
			{
				Environment.Exit(0);
			}
			else if(int.TryParse(inserted, out num) && (num > 9 && num < maxX))
			{
				output += inserted;
			}

			Console.Write($"Please insert a value for y in the interval [10, {maxY}]: ");
			inserted = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(inserted))
			{
				Environment.Exit(0);
			}
			else if (int.TryParse(inserted, out num) && (num > 9 && num < maxY))
			{
				output += " " + inserted;
			}

			return output;
		}

		static void CreateField(int m, int n)
		{
			fields = new Field[m, n];
			Random random = new Random();
			fields[random.Next(m), random.Next(n)] = Field.OurGuy;
			FillMostOfTheField(m, n);
			CheckForEmptySpaces(m, n);
		}

		static void DrawField(int m, int n)
		{
			for(int i = 0; i < m; i++)
			{
				for(int j = 0; j < n; j++)
				{
					Console.Write(FieldToString(fields[i, j]) + " ");
				}
				Console.WriteLine();
			}
		}

		static string FieldToString(Field field)
		{
			switch (field)
			{
				case Field.OurGuy:
					Console.ForegroundColor = ConsoleColor.Cyan;
					return "☺";
				case Field.SomeGuy:
					Console.ForegroundColor = ConsoleColor.DarkCyan;
					return "☻";
				case Field.Diamond:
					Console.ForegroundColor = ConsoleColor.Gray;
					return "♦";
				case Field.Stone:
					Console.ForegroundColor = ConsoleColor.DarkGray;
					return "o";
				case Field.Tree:
					Console.ForegroundColor = ConsoleColor.DarkGreen;
					return "♣";
				case Field.Grass:
					Console.ForegroundColor = ConsoleColor.Green;
					return "▓";
				case Field.Ground:
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					return "▒";
				default:
					return "dsada";
			}
		}

		static void CheckForEmptySpaces(int m, int n)
		{
			Random r = new Random();
			for(int i = 0; i < m; i++)
			{
				for(int j = 0; j < n; j++)
				{
					if(fields[i, j] == default(Field))
					{
						int index = r.Next(3, 8);
						fields[i, j] = (Field)index;
					}
				}
			}
		}

		static void FillMostOfTheField(int m, int n)
		{
			int used = 1;
			used += SetPartOfField(5, Field.SomeGuy, m, n);
			used += SetPartOfField(10, Field.Diamond, m, n);
			SetPartOfField(40, Field.Ground, m, n, fields.Length - used);
			SetPartOfField(30, Field.Grass, m, n, fields.Length - used);
			SetPartOfField(20, Field.Tree, m, n, fields.Length - used);
			SetPartOfField(10, Field.Stone, m, n, fields.Length - used);
		}

		static int SetPartOfField(int percentages, Field field, int m, int n)
		{
			Random random = new Random();
			int x = 0;
			int y = 0;

			int numberOfFields = (int)Math.Floor((percentages / 100.0) * fields.Length);
			int count = 0;

			while(count < numberOfFields)
			{
				x = random.Next(m);
				y = random.Next(n);
				while(fields[x, y] != default(Field))
				{
					x = random.Next(m);
					y = random.Next(n);
				}
				fields[x, y] = field;
				count++;
			}

			return count;
		}

		static void SetPartOfField(int percentages, Field field, int m, int n, int totalLeft)
		{
			Random random = new Random();
			int x = 0;
			int y = 0;

			int numberOfFields = (int)Math.Floor((percentages / 100.0) * totalLeft);
			int count = 0;

			while (count < numberOfFields)
			{
				x = random.Next(m);
				y = random.Next(n);
				while (fields[x, y] != default(Field))
				{
					x = random.Next(m);
					y = random.Next(n);
				}
				fields[x, y] = field;
				count++;
			}
		}
	}
}
