using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Allocation.GenericSolution
{
    public class FriendsEnemiesBits
    {
        public static void Execute()
        {
            var A8 = new BitArray(64);
            A8.Set(0, true);
            A8.Set(2, true);
            A8.Set(3, true);
            A8.Set(4, true);
            A8.Set(5, true);
            A8.Set(33, true);
            A8.Set(60, true);
            A8.Set(63, true);

            var ones = A8.OnesIndices();
            foreach (var index in ones)
            {
                System.Console.WriteLine(index);
            }

        }
    }

}
