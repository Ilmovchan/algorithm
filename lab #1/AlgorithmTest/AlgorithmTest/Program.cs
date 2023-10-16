using System;
using System.Diagnostics;

namespace AlgorithmTest
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arr = Generate.IntArray(20, -100, 100);

            ArraySort.Demo(arr);

            //ArraySearch.Demo(arr, arr[15]);

        }
    }
}
