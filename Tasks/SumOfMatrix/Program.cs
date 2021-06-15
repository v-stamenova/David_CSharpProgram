using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Insert the length of the matrix: ");
            int length = int.Parse(Console.ReadLine());
            double[,] matrix = new double[length, length];
            string output = "";

            Console.WriteLine($"Insert {length * length} elements, one per line:");
            for(int i = 0; i < length; i++)
            {
                for(int j = 0; j < length; j++)
                {
                    matrix[i, j] = double.Parse(Console.ReadLine());
                    output += matrix[i, j].ToString() + " ";
                }
                output += Environment.NewLine;
            }

            Console.WriteLine("The matrix: ");
            Console.WriteLine(output);
            Console.WriteLine("The sum of elements below the diagonal: " + SumBelowDiagonal(matrix));
            Console.WriteLine("The sum of elements above the diagonal: " + SumAboveDiagonal(matrix));
            Console.WriteLine("The sum of elements in the diagonal: " + SumOfTheDiagonal(matrix));
        }

        private static double SumOfTheDiagonal(double[,] matrix)
        {
            double sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }
            return sum;
        }

        private static double SumBelowDiagonal(double[,] matrix)
        {
            double sum = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < i; j++)
                {
                    sum += matrix[i, j];
                }
            }
            return sum;
        }

        private static double SumAboveDiagonal(double[,] matrix)
        {
            double sum = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = i + 1; j < matrix.GetLength(0); j++)
                {
                    sum += matrix[i, j];
                }
            }
            return sum;
        }
    }
}
