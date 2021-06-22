using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoldDiggers
{
	class Program
	{
		static Field[,] fields;
		static int m, n;
		static int ourGuyI, ourGuyJ;
		static ConsoleKeyInfo ourGuyDirection;
		static int diamonds;
		static int remainingDiamonds;

		static void Main(string[] args)
		{
			GetFieldBounds(100, 100);
			CreateField();
			remainingDiamonds = diamonds;
			while ((ourGuyDirection.Key != ConsoleKey.Escape) && remainingDiamonds != 0)
			{
				Console.Clear();
				DrawField();
				MoveSomeGuys();
				ProccesOuput(ref ourGuyDirection);
				Thread.Sleep(100);
			}
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine($"Found diamonds: {(((double)(diamonds - remainingDiamonds) / diamonds) * 100)}%");
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
			ourGuyI = random.Next(m);
			ourGuyJ = random.Next(n);
			fields[ourGuyI, ourGuyJ] = Field.OurGuy;
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
			diamonds = SetField(10, Field.Diamond);
			used += diamonds;
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

		static string MoveGuy(int i, int j, Direction dir)
		{
			int newI = i;
			int newJ = j;
			switch (dir)
			{
				case Direction.Up:
					newI--;
					break;
				case Direction.Down:
					newI++;
					break;
				case Direction.Left:
					newJ--;
					break;
				case Direction.Right:
					newJ++;
					break;
			}

			if(newI < m && newI >= 0 && newJ < n && newJ >= 0)
			{
				Field checkField = fields[newI, newJ];
				if(checkField == Field.Ground || checkField == Field.Grass || checkField == Field.Diamond)
				{
					if (checkField == Field.Diamond)
					{
						remainingDiamonds--;
					}
					Field moveFields = fields[i, j];
					fields[newI, newJ] = moveFields;
					fields[i, j] = Field.Ground;
					return $"{newI} {newJ}";
				}
			}
			return "No success";
		}

		static void MoveSomeGuys()
		{
			List<string> locations = new List<string>();
			for(int i = 0; i < m; i++)
			{
				for(int j = 0; j < n; j++)
				{
					if (fields[i, j] == Field.SomeGuy)
					{
						if(!locations.Any(x => x.Split(' ').ToList()[0] == i.ToString() && x.Split(' ').ToList()[1] == j.ToString()))
						{
							Random random = new Random();
							Direction randomDirection = (Direction)random.Next(0, 5);
							string output = MoveGuy(i, j, randomDirection);
							while (output == "No success")
							{
								randomDirection = (Direction)random.Next(0, 5);
								output = MoveGuy(i, j, randomDirection);
							}
							locations.Add(output);
						}
					}
				}
			}
		}

		static string MoveOurGuy(Direction direction)
		{
			return MoveGuy(ourGuyI, ourGuyJ, direction);
		}

		static void ProccesOuput(ref ConsoleKeyInfo consoleKey)
		{
			consoleKey = Console.ReadKey();
			if(consoleKey.Key != ConsoleKey.Escape)
			{
				string newCords = "";
				while(fields[ourGuyI, ourGuyJ] == Field.OurGuy)
				{
					Direction dir = Direction.Down;
					switch (consoleKey.Key)
					{
						case ConsoleKey.DownArrow:
							dir = Direction.Down;
							break;
						case ConsoleKey.UpArrow:
							dir = Direction.Up;
							break;
						case ConsoleKey.LeftArrow:
							dir = Direction.Left;
							break;
						case ConsoleKey.RightArrow:
							dir = Direction.Right;
							break;
						default:
							Console.WriteLine("Please use the arrows to choose the direction of the guy");
							break;
					}
					newCords = MoveOurGuy(dir);
					if(newCords == "No success")
					{
						Console.WriteLine("Oh no, your guy bumped into something. Choose another direction");
						consoleKey = Console.ReadKey();
					}
				}
				ourGuyDirection = consoleKey;
				ourGuyI = newCords.Split(' ').Select(int.Parse).ToList()[0];
				ourGuyJ = newCords.Split(' ').Select(int.Parse).ToList()[1];
			}
		}
	}
}
