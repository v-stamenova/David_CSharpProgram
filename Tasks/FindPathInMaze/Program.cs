using System;
using System.Collections.Generic;
using System.Linq;

namespace FindPathInMaze
{
	class Program
	{
		static char[,] maze;
		static int m, n;
		static int startX = 0, startY = 0, finishX = 2, finishY = 2;
		static List<char> path = new List<char>();

		static void Main(string[] args)
		{
			Console.Write("Please insert the length of the rows in the maze: ");
			m = int.Parse(Console.ReadLine());
			Console.Write("Please insert the length of the column in the maze: ");
			n = int.Parse(Console.ReadLine());
			maze = new char[m, n];
			Console.WriteLine($"Please insert {n} elements ('-' for empty, '*' for wall) per line, seperated with spaces");
			int count = 0;
			while(count < m)
			{
				List<char> chars = Console.ReadLine().Split(' ').Select(char.Parse).ToList();
				for(int i = 0; i < n; i++)
				{
					if (chars[i] == '-')
					{
						maze[count, i] = ' ';
					}
					else
					{
						maze[count, i] = chars[i];
					}
				}
				count++;
			}
			Console.Write("Please insert the starting coordinates with space between: ");
			List<int> coords = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
			startX = coords[1];
			startY = coords[0];
			Console.Write("Please insert the ending coordinates with space between: ");
			coords = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
			finishX = coords[1];
			finishY = coords[0];
			FindMazePath(startX, startY, 'S');
		}

		private static void ShowMaze()
		{
			string output = "";
			for (int i = 0; i < m; i++)
			{
				for (int j = 0; j < n; j++)
				{
					output += maze[i, j].ToString() + " ";
				}
				output += Environment.NewLine;
			}
			Console.WriteLine(output);
		}

		private static void FindMazePath(int row, int col, char direction)
		{
			if (!IsInBounds(row, col))
			{
				return;
			}

			path.Add(direction);

			if(IsExit(row, col))
			{
				PrintPath();
			}
			else if(IsFree(row, col) && !IsVisited(row, col))
			{
				Mark(row, col);
				FindMazePath(row, col + 1, 'R');
				FindMazePath(row, col - 1, 'L');
				FindMazePath(row - 1, col, 'U');
				FindMazePath(row + 1, col, 'D');
			}
			path.RemoveAt(path.Count - 1);
		}

		private static void Mark(int row, int col)
		{
			maze[row, col] = '#';
		}

		private static bool IsExit(int row, int col)
		{
			if(row == finishY && col == finishX)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private static bool IsVisited(int row, int col)
		{
			if(maze[row, col] == '#')
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private static bool IsFree(int row, int col)
		{
			if(maze[row, col] == ' ')
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private static bool IsInBounds(int row, int col)
		{
			if((row < m && row >= 0) && (col < n && col >= 0))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private static void PrintPath()
		{
			Console.WriteLine(string.Join(' ', path));
		}
	}
}
