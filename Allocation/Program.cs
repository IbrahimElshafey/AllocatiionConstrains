using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
namespace AllocationConstraints
{
    class Program
    {
        static void Main(string[] args)
        {
            //var list1 = new List<int> { 1, 2, 3, 4, 8 };
            //var list2 = new List<int> { 5,6,7,8,4 };
            //var x = list1.Intersect(list2).Any();
            //PrintTime(JobShop.JobShop.Execute);
            //PrintTime(Allocation.GenericSolution.FriendsEnemiesSolution.Execute);
            //PrintTime(Allocation.GenericSolution.FriendsEnemiesBits.Execute);

            Console.Read();
        }

        public static void PrintTime(Action action)
        {
            Console.WriteLine(action.Method.Name);
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();

            action();

            watch.Stop();

            WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }
    }
}
