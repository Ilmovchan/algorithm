using Numbers;
using System;
using System.Diagnostics;

namespace ArraySort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Generate.Array<int>(100, 0 , 1000); // Увеличьте размер массива

            var watch = Stopwatch.StartNew();
            ArrSort.CountingSort(arr);
            watch.Stop();

            Console.WriteLine(watch.ElapsedTicks);
        }
    }
}
