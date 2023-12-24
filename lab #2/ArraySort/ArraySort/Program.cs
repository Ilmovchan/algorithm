using Numbers;
using System;
using System.Diagnostics;

namespace ArraySort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Generate.Array<int>(30000, 0, 100000);

            var watch = Stopwatch.StartNew();
            ArrSort.QuickSort(arr);
            watch.Stop();

            Console.WriteLine(watch.ElapsedTicks);
        }
    }
}
