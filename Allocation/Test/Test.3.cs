using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllocationConstraints.Test
{
    public partial class Test1
    {
        public static void Execute()
        {
            /*
             *  * Four persons
             *  
             *  Activites per day array [1111,222,333333,444]
             *  Mandatory/Optional Array [MMMO,MMM,MMMMOO,MMO]
             *  Time Slots [8 hours every day,5 days per week]=40
             *  
             *  Max hours per day = 16 per week = 80
             *  Min hours per day = 12 per week = 60
             *  
             *  P1 cant work day1 and day2
             *      P1 Max/Min 4..3
             *      Max Total per week = 72
             *      Min Total per week = 52
             *  
             *  P3 cant work the day 4
             *      Max Total per week = 66
             *      Min Total per week = 46
             *      
             *  No one must work more than 10 hours
             *  
             *  22233344
             *  22233344
             *  11113333
             *  44422211
             *  11114442
             *  
             *  10,10,10,10
             *  
             *  P2 Can't work in day 2
             *      Max Total per week = 63
             *      Min Total per week = 43
             *      
             *  Translate constrains to fuctions that takes domain variables and return boolean
             */
        }

        static void Test2()
        {
            //define domain varibles
            //four persons
            var persons = new int[4];
            //person works 5 days and 8 hours per day
            var days = new int[5][];
            //define current variable
            int currentPerson = 0, currentDay = 0, currentHour = 0;


            //algorithm
            //for each day allocate hours with persons
            for (int i = 0; i < 5; i++)
            {
                AddTeachersToDay(i);
            }
            //constrains is two types
            //after allocation constrain
            //before allocation constrain
            //var constrains = new Constrains();
            //person one can works 3..4 hours in any day
            bool c1()
            {
                return days[currentDay][0..7].Count(x => x == persons[0]) == 3;
            }

            bool AddTeachersToDay(int i)
            {
                throw new NotImplementedException();
            }

        }
    }
}
