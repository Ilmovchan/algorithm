using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Numbers;

namespace ArraySort
{
	public static class ArrSort
	{
        public static void PrintSortedArrs(int[] arr)
        {
            int[] bubbleSort = ArrSort.BubbleSort(arr);
            int[] selectionSort = ArrSort.SelectionSort(arr);
            int[] linqSort = ArrSort.LinqSort(arr);
            int[] defaultSort = ArrSort.DefaultSort(arr);

            Console.WriteLine("BUBBLE SORT:\n");
            foreach (int elem in bubbleSort) Console.WriteLine(elem);
            Console.WriteLine("\n");

            Console.WriteLine("SELECTION SORT:\n");
            foreach (int elem in selectionSort) Console.WriteLine(elem);
            Console.WriteLine("\n");

            Console.WriteLine("LINQ SORT:\n");
            foreach (int elem in linqSort) Console.WriteLine(elem);
            Console.WriteLine("\n");

            Console.WriteLine("DEFAULT SORT:\n");
            foreach (int elem in defaultSort) Console.WriteLine(elem);
            Console.WriteLine("\n");
        }

        //Метод написання повної інформації у консоль
        public static void PrintInfo(int[] arr)
        {

            if (CompareInfo(arr))
            {
                Console.WriteLine("All sorting methods work well\n");

                Console.WriteLine(TimeInfo(arr));

                Console.WriteLine("Generated array:\n");

                //foreach (int element in arr) Console.WriteLine(element);

                //Console.WriteLine("\n");

                //Console.WriteLine("Sorted array:\n");

                //foreach (int element in BubbleSort(arr)) Console.WriteLine(element);
            }

            else
            {
                Console.WriteLine("Error in sorting methods");
            }
        }

        //Метод для виводу результату підрахунку часу виконання різних типів сортувань
        public static string TimeInfo(int[] arr)
        {
            string timeInfo = "";

            timeInfo += "Bubble sort time: " + MeasureExecutionTime(BubbleSort, arr) + "\n";
            timeInfo += "Default sort time: " + MeasureExecutionTime(DefaultSort, arr) + "\n";
            timeInfo += "Linq sort time: " + MeasureExecutionTime(LinqSort, arr) + "\n";
            timeInfo += "Selection sort time: " + MeasureExecutionTime(SelectionSort, arr) + "\n";

            return timeInfo;
        }

        //Метод для порівняння результату різних типів сортувань
        public static bool CompareInfo(int[] arr)
        {
            int[][] arrComp = { DefaultSort(arr), LinqSort(arr), BubbleSort(arr), SelectionSort(arr) };

            for (int i = 0; i < arrComp.Length; i++)
            {
                for (int j = i + 1; j < arrComp.Length; j++)
                {
                    if (!arrComp[i].SequenceEqual(arrComp[j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        //"Бульбашкове" сортування
        public static int[] BubbleSort(int[] originalArr)
        {
            int[] arr = originalArr.ToArray();

            for (int j = 0; j < arr.Length - 1; j++)
            {
                bool swapped = false;
                for (int i = 0; i < arr.Length - j - 1; i++)
                {
                    if (arr[i] < arr[i + 1])
                    {
                        int tmp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = tmp;
                        swapped = true;
                    }
                }
                if (!swapped) return arr;
            }

            return arr;
        }

        //Сортування з вибором
        public static int[] SelectionSort(int[] originalArr)
        {
            int[] arr = originalArr.ToArray();

            for (int j = 0; j < arr.Length; j++)
            {
                int minIndex = j;

                for (int i = j; i < arr.Length; i++)
                {
                    if (arr[minIndex] < arr[i])
                    {
                        minIndex = i;
                    }
                }

                int tmp = arr[j];
                arr[j] = arr[minIndex];
                arr[minIndex] = tmp;
            }

            return arr;
        }

        //Сортування із використанням linq
        public static int[] LinqSort(int[] originalArr)
        {
            int[] linqSortArr = new int[originalArr.Length];

            Array.Copy(originalArr, linqSortArr, originalArr.Length);

            IEnumerable<int> sortedNumbersDescending = linqSortArr.OrderByDescending(number => number);

            return sortedNumbersDescending.ToArray();
        }

        //Стандартне сортування
        public static int[] DefaultSort(int[] originalArr)
        {
            int[] defaultSortArr = new int[originalArr.Length];

            Array.Copy(originalArr, defaultSortArr, originalArr.Length);

            Array.Sort(defaultSortArr, (a, b) => b.CompareTo(a));

            return defaultSortArr;
        }

        public static long MeasureExecutionTime(SortingMethod method, int[] arr)
        {
            var watch = Stopwatch.StartNew();

            method(arr);

            watch.Stop();
            return watch.ElapsedTicks;
        }

        public delegate int[] SortingMethod(int[] arr);
    }
}
        