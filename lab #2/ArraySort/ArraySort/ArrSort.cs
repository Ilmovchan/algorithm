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

        private static int FindPivot(int[] arr, int minIndex, int maxIndex)
        {   
            int pivot = minIndex -1;

            for (int i = minIndex; i < maxIndex; i++)
            {
                if (arr[i] < arr[maxIndex])
                {
                    pivot++;
                    Swap(ref arr[pivot], ref arr[i]);
                }
            }

            pivot++;
            Swap(ref arr[pivot], ref arr[maxIndex]);
            return pivot;
        }

        public static int[] QuickSort(int[] arr, int minIndex = 0, int maxIndex = -1)
        {
            if (maxIndex == -1) maxIndex = arr.Length - 1;

            if (minIndex >= maxIndex)
            {
                return arr;
            }

            var pivotIndex = FindPivot(arr, minIndex, maxIndex);
            QuickSort(arr, minIndex, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, maxIndex);

            return arr;
        }

        //Сортування з вибором
        public static int[] SelectionSort(int[] originalArr, int minIndex = 0, int maxIndex = -1)
        {
            int[] arr = originalArr.ToArray();
            if (maxIndex == -1) maxIndex = arr.Length;

            for (int j = minIndex; j < maxIndex; j++)
            {
                int minValue = j;

                for (int i = j; i < maxIndex; i++)
                {
                    if (arr[minValue] < arr[i])
                    {
                        minValue = i;
                    }
                }

                Swap(ref arr[j], ref arr[minValue]);
            }

            return arr;
        }

        //Swap
        private static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        //------------------------------------------------------------------------------------------------------

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

        ////Метод написання повної інформації у консоль
        //public static void PrintInfo(int[] arr)
        //{

        //    if (CompareInfo(arr))
        //    {
        //        Console.WriteLine("All sorting methods work well\n");

        //        Console.WriteLine(TimeInfo(arr));

        //        Console.WriteLine("Generated array:\n");

        //        //foreach (int element in arr) Console.WriteLine(element);

        //        //Console.WriteLine("\n");

        //        //Console.WriteLine("Sorted array:\n");

        //        //foreach (int element in BubbleSort(arr)) Console.WriteLine(element);
        //    }

        //    else
        //    {
        //        Console.WriteLine("Error in sorting methods");
        //    }
        //}

        ////Метод для виводу результату підрахунку часу виконання різних типів сортувань
        //public static string TimeInfo(int[] arr)
        //{
        //    string timeInfo = "";

        //    timeInfo += "Bubble sort time: " + MeasureExecutionTime(BubbleSort, arr) + "\n";
        //    timeInfo += "Default sort time: " + MeasureExecutionTime(DefaultSort, arr) + "\n";
        //    timeInfo += "Linq sort time: " + MeasureExecutionTime(LinqSort, arr) + "\n";
        //    //timeInfo += "Selection sort time: " + MeasureExecutionTime(SelectionSort, arr) + "\n";

        //    return timeInfo;
        //}

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

        public static TimeSpan MeasureExecutionTime(SortingMethod method, int[] arr)
        {
            var watch = Stopwatch.StartNew();

            method(arr);

            watch.Stop();

            return watch.Elapsed;
        }

        public delegate int[] SortingMethod(int[] arr, int minIndex = 0, int maxIndex = -2);
    }
}
        