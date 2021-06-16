using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekTemperatures
{
    class Program
    {
        static double[,] forecast = new double[7, 6];

        static void Main(string[] args)
        {
            Console.WriteLine("Please write for everyday the temperatures for the six periods as it follows -> Monday: 12 14.5 16 20 24 20");
            foreach(DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                TemperatureForDay(day);
            }
            Console.WriteLine(Environment.NewLine + "-----------------------" + Environment.NewLine);
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                Console.WriteLine($"{day.ToString()}: {Math.Round(AverageTemperatureForTheDay(day), 2)}");
            }
            for(int i = 0; i < 6; i++)
            {
                Console.WriteLine($"{i * 4}:00 - {Math.Round(AverageTemperatureForTheTimePeriod(i), 2)}");
            }
        }

        static void TemperatureForDay(DayOfWeek day)
        {
            Console.Write($"{day.ToString()}: ");
            List<double> temperatures = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            int row = GetRowFromDay(day);
            for(int i = 0; i < 6; i++)
            {
                forecast[row, i] = temperatures[i];
            }
        }

        static int GetRowFromDay(DayOfWeek day)
        {
            int row = 0;
            if(day == DayOfWeek.Sunday)
            {
                row = 6;
            }
            else
            {
                row = (int)day - 1;
            }
            return row;
        }

        static double AverageTemperatureForTheDay(DayOfWeek day)
        {
            int row = GetRowFromDay(day);
            double sum = 0;
            for(int i = 0; i < 6; i++)
            {
                sum += forecast[row, i];
            }
            return sum / 6;
        }

        static double AverageTemperatureForTheTimePeriod(int period)
        {
            int column = period;
            double sum = 0;
            for(int i = 0; i < 7; i++)
            {
                sum += forecast[i, column]; 
            }
            return sum / 7;
        }
    }
}
