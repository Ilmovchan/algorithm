using System;
using System.Diagnostics;

namespace AlgorithmTest
{
	public static class ArraySort
	{

        public static void Demo(int[] arr)
        {
            //Вывод заданого массива
            Console.WriteLine("Original array:\n");
            foreach (int element in arr) Console.WriteLine(element);
            Console.WriteLine('\n');

            int[] bubbleSortArr = BubbleSort(arr);
            int[] selectionSortArr = SelectionSort(arr);

            if (Compare(bubbleSortArr, selectionSortArr))
            {
                Console.WriteLine("Sorting methods work correctly\n");
                Console.WriteLine("Bubble sort time: " + MeasureExecutionTime(BubbleSort, arr));
                Console.WriteLine("Selection sort time: " + MeasureExecutionTime(SelectionSort, arr));
                Console.WriteLine('\n');

                Console.WriteLine("Sorted array:\n");
                foreach (int element in bubbleSortArr) Console.WriteLine(element);
                Console.WriteLine('\n');
            }
            else
            {
                Console.WriteLine("Sorting methods work incorrectly");
            }
        }

		public static int[] BubbleSort(int[] originalArr)
		{
            int[] arr = originalArr.ToArray();

			for (int j = 0; j < arr.Length - 1; j++)
			{
				bool swapped = false;
				for (int i = 0; i < arr.Length - j - 1; i++)
				{
					if (arr[i] > arr[i + 1])
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

		public static int[] SelectionSort(int[] originalArr)
		{
            int[] arr = originalArr.ToArray();

			for (int j = 0; j < arr.Length; j++)
			{
                int minIndex = j;

                for (int i = j; i < arr.Length; i++)
                {
                    if (arr[minIndex] > arr[i])
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

        public static bool Compare(int[] arr1, int[] arr2)
        {
            int[][] arrComp = {arr1, arr2};

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

