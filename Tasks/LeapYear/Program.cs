using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapYear
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert a year");
            int year = int.Parse(Console.ReadLine());

            if (IsTheYearLeap(year))
            {
                Console.WriteLine("The year is leap");
            }
            else
            {
                Console.WriteLine("The year is NOT leap");
            }
        }

        static bool IsTheYearLeap(int year)
        {
            if (year % 4 == 0)
            {
                if(year % 100 == 0)
                {
                    if(year % 400 == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
