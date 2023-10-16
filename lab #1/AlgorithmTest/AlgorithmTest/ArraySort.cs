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
            int[] insertionSortArr = InsertionSort(arr);

            if (Compare(bubbleSortArr, selectionSortArr, insertionSortArr))
            {
                Console.WriteLine("Sorting methods work correctly\n");
                Console.WriteLine("Bubble sort time: " + MeasureExecutionTime(BubbleSort, arr));
                Console.WriteLine("Selection sort time: " + MeasureExecutionTime(SelectionSort, arr));
                Console.WriteLine("Insertion sort time: " + MeasureExecutionTime(InsertionSort, arr));
                Console.WriteLine('\n');

                Console.WriteLine("Sorted array:\n");
                foreach (int element in bubbleSortArr) Console.WriteLine(element);
                Console.WriteLine('\n');
            }
            else
            {
                Console.WriteLine("Sorting methods work incorrectly");

                
                foreach (int element in insertionSortArr) Console.WriteLine(element);
                Console.WriteLine('\n');

                foreach (int element in bubbleSortArr) Console.WriteLine(element);
                Console.WriteLine('\n');

                foreach (int element in selectionSortArr) Console.WriteLine(element);
                Console.WriteLine('\n');
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

        public static int[] InsertionSort(int[] originalArr)
        {
            int[] arr = originalArr.ToArray();

            int index;
            int currentNumber;

            for (int i = 0; i < arr.Length; i++)
            {
                index = i;
                currentNumber = arr[i];

                while(index > 0 && currentNumber < arr[index - 1])
                {
                    arr[index] = arr[index - 1];
                    index--;
                }

                arr[index] = currentNumber;
            }

            return arr;
        }

        public static bool Compare(int[] arr1, int[] arr2, int[] arr3)
        {
            int[][] arrComp = {arr1, arr2, arr3};

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


        //Swap
        private static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }


        public static TimeSpan MeasureExecutionTime(SortingMethod method, int[] arr)
        {
            var watch = Stopwatch.StartNew();

            method(arr);

            watch.Stop();
            return watch.Elapsed;
        }

        public delegate int[] SortingMethod(int[] arr);
    }
}

