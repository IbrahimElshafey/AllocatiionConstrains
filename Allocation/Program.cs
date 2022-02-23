using System;
using static System.Console;
namespace AllocationConstraints
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintTime(JobShop.JobShop.Execute);
            PrintTime(Allocation.GenericSolution.FriendsEnemiesSolution.Execute);
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
