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
		static int m, n;

		static void Main(string[] args)
		{
			GetFieldBounds(100, 100);
			CreateField();
			DrawField();
			MoveSomeGuys();
			DrawField();
			Console.ResetColor();
		}

		static void GetFieldBounds(int maxX, int maxY)
		{
			Console.Write($"Please insert a value for x in the interval [10, {maxX}]: ");
			string inserted = Console.ReadLine();
			int num;

			if (string.IsNullOrWhiteSpace(inserted))
			{
				Environment.Exit(0);
			}
			else if(int.TryParse(inserted, out num) && (num > 9 && num < maxX))
			{
				m = num;
			}

			Console.Write($"Please insert a value for y in the interval [10, {maxY}]: ");
			inserted = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(inserted))
			{
				Environment.Exit(0);
			}
			else if (int.TryParse(inserted, out num) && (num > 9 && num < maxY))
			{
				n = num;
			}
		}

		static void CreateField()
		{
			fields = new Field[m, n];
			Random random = new Random();
			fields[random.Next(m), random.Next(n)] = Field.OurGuy;
			FillTheField();
			CheckForEmptySpaces();
		}

		static void DrawField()
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

		static void CheckForEmptySpaces()
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

		static void FillTheField()
		{
			int used = 1;
			used += SetField(5, Field.SomeGuy);
			used += SetField(10, Field.Diamond);
			SetField(40, Field.Ground, fields.Length - used);
			SetField(30, Field.Grass, fields.Length - used);
			SetField(20, Field.Tree, fields.Length - used);
			SetField(10, Field.Stone, fields.Length - used);
		}

		static int SetField(int percentages, Field field)
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

		static void SetField(int percentages, Field field, int totalLeft)
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

		static void MoveGuy(int x, int y, Direction dir)
		{
			int newX = x;
			int newY = y;
			switch (dir)
			{
				case Direction.Up:
					newX--;
					break;
				case Direction.Down:
					newX++;
					break;
				case Direction.Left:
					newY--;
					break;
				case Direction.Right:
					newY++;
					break;
			}

			if(newX <= m && newY <= n)
			{
				Field checkField = fields[newX, newY];
				if(checkField == Field.Ground || checkField == Field.Grass || checkField == Field.Diamond)
				{
					Field moveFields = fields[x, y];
					fields[newX, newY] = moveFields;
					fields[x, y] = Field.Ground;
				}
			}
		}

		static void MoveSomeGuys()
		{
			for(int i = 0; i < m; i++)
			{
				for(int j = 0; j < n; j++)
				{
					while(fields[i, j] == Field.SomeGuy)
					{
						Random random = new Random();
						Direction randomDirection = (Direction)random.Next(0, 5);
						MoveGuy(i, j, randomDirection);
					}
				}
			}
		}
	}
}
