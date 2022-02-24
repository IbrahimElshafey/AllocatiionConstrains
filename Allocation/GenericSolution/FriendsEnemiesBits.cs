using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Allocation.GenericSolution
{
    public class FriendsEnemiesBits
    {
        public static void Execute()
        {
            var A8 = new BitArray(36);
            var T1 = new BitArray(36);
            A8.Set(0, true);
            A8.Set(2, true);
            A8.Set(3, true);
            A8.Set(4, true);
            A8.Set(5, true);
            A8.Set(33, true);

            T1.Set(3, true);
            T1.Set(5, true);
            T1.Set(33, true);

            var x = T1.IsResultAfterAndWith(A8);
            T1.Set(7, true);
            x = T1.IsResultAfterAndWith(A8);
        }
    }

    public static class BitArrayExtended
    {
        static Func<BitArray, int[]> getIntArray = GetFieldAccessor<BitArray, int[]>("m_array");
        public static int[] GetIntArray(this BitArray bitArray) => getIntArray(bitArray);

        public static bool IsResultAfterAndWith(this BitArray current, BitArray input)
        {
            var currentArray = getIntArray(current);
            var inputArray = getIntArray(input);

            var diffrenceExist = currentArray.Zip(inputArray).Any(x => (x.First & x.Second) != x.First);
            return !diffrenceExist;
        }

        public static bool IsZeros(this BitArray bitArray)
        {
            var array = bitArray.GetIntArray();
            var notZeros = array.Any(x => x != 0);
            return !notZeros;
        }

        public static bool IsOnes(this BitArray bitArray)
        {
            var array = bitArray.GetIntArray();
            var notZeros = array.Any(x => x != -1);
            return !notZeros;
        }

        public static Func<T, R> GetFieldAccessor<T, R>(string fieldName)
        {
            ParameterExpression param =
            Expression.Parameter(typeof(T), "arg");

            MemberExpression member =
            Expression.Field(param, fieldName);

            LambdaExpression lambda =
            Expression.Lambda(typeof(Func<T, R>), member, param);

            Func<T, R> compiled = (Func<T, R>)lambda.Compile();
            return compiled;
        }
        //static int[] _bitcounts; // Lookup table

        //static void InitializeBitcounts()
        //{
        //    _bitcounts = new int[65536];
        //    int position1 = -1;
        //    int position2 = -1;
        //    //
        //    // Loop through all the elements and assign them.
        //    //
        //    for (int i = 1; i < 65536; i++, position1++)
        //    {
        //        //
        //        // Adjust the positions we read from.
        //        //
        //        if (position1 == position2)
        //        {
        //            position1 = 0;
        //            position2 = i;
        //        }
        //        _bitcounts[i] = _bitcounts[position1] + 1;
        //    }
        //}

        //static int PrecomputedBitcount(int value)
        //{
        //    //
        //    // Count bits in each half of the 32-bit input number.
        //    //
        //    return _bitcounts[value & 65535] + _bitcounts[(value >> 16) & 65535];
        //}
    }

}
