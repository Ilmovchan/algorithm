using System;
using System.Diagnostics;

namespace AlgorithmTest
{
	public static class ArraySearch
	{

        //Метод для виводу рез-тату
        public static void Demo(int[] simpleArr, int needle)
        {
            int[] sortedArr = simpleArr.ToArray();
            Array.Sort(sortedArr);

            Console.WriteLine($"You are searching number {needle}\n");

            //Вивід заданого масиву
            Console.WriteLine("Given array:\n");
            foreach (int element in simpleArr) Console.WriteLine(element);
            Console.WriteLine('\n');


            //Вивід результату лінійного пошуку у 2 типах масивів
            Console.WriteLine("Linear search");
            Console.WriteLine("Simple array:" + LinearSearch(simpleArr, needle));
            Console.WriteLine("Time: " + MeasureSearchExecutionTime(LinearSearch, simpleArr, needle));

            Console.WriteLine("Sorted array:" + LinearSearch(sortedArr, needle));
            Console.WriteLine("Time: " + MeasureSearchExecutionTime(LinearSearch, sortedArr, needle));
            Console.WriteLine('\n');

            //Вивід результату бінарного пошуку у 2 типах масивів
            Console.WriteLine("BINARY SEARCH");
            Console.WriteLine("Simple array:" + BinarySearch(simpleArr, needle));
            Console.WriteLine("Time: " + MeasureSearchExecutionTime(BinarySearch, simpleArr, needle));

            Console.WriteLine("Sorted array:" + BinarySearch(sortedArr, needle));
            Console.WriteLine("Time: " + MeasureSearchExecutionTime(BinarySearch, sortedArr, needle));
        }

        //Лінійний пошук
        public static bool LinearSearch(int[] stack, int needle, int start = 0, int end = -1)
        {
            if (end == -1) end = stack.Length - 1;

            for (int i = start; i <= end; i++)
            {
                if (stack[i] == needle) return true;
            }
            return false;
        }

        //Бінарний пошук
        public static bool BinarySearch(int[] stack, int needle, int start = 0, int end = -1)
        {
            if (end == -1) end = stack.Length - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (stack[mid] == needle) return true;
                else if (stack[mid] < needle) start = mid + 1;
                else if (stack[mid] > needle) end = mid - 1;
            }

            return false;
        }

        // Метод для заміру часу виконання методу
        public static long MeasureSearchExecutionTime(MethodToMeasure method, int[] stack, int needle, int start = 0, int end = -1)
        {
            var watch = Stopwatch.StartNew();

            method(stack, needle, start, end);

            watch.Stop();

            return watch.ElapsedTicks;
        }

        public delegate bool MethodToMeasure(int[] stack, int needle, int start, int end);
    }
}

