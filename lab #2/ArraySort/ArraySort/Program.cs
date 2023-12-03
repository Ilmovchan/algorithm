using Numbers;
using System;
using System.Diagnostics;

namespace ArraySort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Generate.Array<int>(1000, 0 , 500); // Увеличьте размер массива

            var watch = Stopwatch.StartNew();
            ArrSort.SelectionSort(arr);
            watch.Stop();

            Console.WriteLine(watch.ElapsedTicks);
        }
    }
}
