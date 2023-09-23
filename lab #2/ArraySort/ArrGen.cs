using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace ArraySort
{
    public class ArrGen
    {

        public ArrGen(int length, int min, int max)
        {
            random = new Random();

            BaseArr = Generate(length, min, max);

        }

        //Метод написання повної інформації у консоль
        public void PrintInfo()
        {

            if (CompareInfo())
            {
                Console.WriteLine("All sorting methods work well\n");

                Console.WriteLine(TimeInfo());

                Console.WriteLine("Generated array:\n");

                foreach (int element in BaseArr) Console.WriteLine(element);

                Console.WriteLine("\n");

                Console.WriteLine("Sorted array:\n");

                foreach (int element in BubbleSort(BaseArr)) Console.WriteLine(element);
            }

            else
            {
                Console.WriteLine("Error in sorting methods");
            }
        }

        //Метод для виводу результату підрахунку часу виконання різних типів сортувань
        public string TimeInfo()
        {
            string timeInfo = "";

            timeInfo += "Bubble sort time: " + MeasureMethodExecutionTime(BubbleSort, BaseArr) + "\n";
            timeInfo += "Default sort time: " + MeasureMethodExecutionTime(DefaultSort, BaseArr) + "\n";
            timeInfo += "Linq sort time: " + MeasureMethodExecutionTime(LinqSort, BaseArr) + "\n";
            timeInfo += "Selection sort time: " + MeasureMethodExecutionTime(SelectionSort, BaseArr) + "\n";

            return timeInfo;
        }

        //Метод для порівняння результату різних типів сортувань
        public bool CompareInfo()
        {
            int[][] arrComp = { DefaultSort(BaseArr), LinqSort(BaseArr), BubbleSort(BaseArr), SelectionSort(BaseArr) };

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

        //Метод для генерування масиву з випадкових чисел у діапазоні min/max
        private int[] Generate(int length, int min, int max)
        {
            int[] generatedArr = new int[length];

            for (int i = 0; i < generatedArr.Length; i++)
            {
                generatedArr[i] = random.Next(min, max + 1);
            }

            return generatedArr;
        }

        // Метод для заміра часу виконання сортування
        private TimeSpan MeasureMethodExecutionTime(MethodToMeasure method, int[] arr)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();

            method(arr);

            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        //Сортування з вибором
        private int[] SelectionSort(int[] originalArr)
        {
            int[] selectionSortArr = new int[originalArr.Length];

            Array.Copy(originalArr, selectionSortArr, originalArr.Length);

            for (int i = 0; i < originalArr.Length - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < originalArr.Length; j++)
                {
                    if (selectionSortArr[j] > selectionSortArr[maxIndex])
                    {
                        maxIndex = j;
                    }
                }
                int temp = selectionSortArr[i];
                selectionSortArr[i] = selectionSortArr[maxIndex];
                selectionSortArr[maxIndex] = temp;
            }

            return selectionSortArr;
        }

        //"Бульбашкове" сортування
        private int[] BubbleSort(int[] originalArr)
        {
            int[] bubbleSortArr = new int[originalArr.Length];

            Array.Copy(originalArr, bubbleSortArr, originalArr.Length);

            for (int i = 0; i < bubbleSortArr.Length - 1; i++)
            {
                for (int j = 0; j < bubbleSortArr.Length - 1 - i; j++)
                {
                    if (bubbleSortArr[j] < bubbleSortArr[j + 1])
                    {
                        int tmp = bubbleSortArr[j];
                        bubbleSortArr[j] = bubbleSortArr[j + 1];
                        bubbleSortArr[j + 1] = tmp;
                    }
                }
            }

            return bubbleSortArr;
        }

        //Сортування із використанням linq
        private int[] LinqSort(int[] originalArr)
        {
            int[] linqSortArr = new int[originalArr.Length];

            Array.Copy(originalArr, linqSortArr, originalArr.Length);

            IEnumerable<int> sortedNumbersDescending = linqSortArr.OrderByDescending(number => number);

            return sortedNumbersDescending.ToArray();
        }

        //Стандартне сортування
        private int[] DefaultSort(int[] originalArr)
        {
            int[] defaultSortArr = new int[originalArr.Length];

            Array.Copy(originalArr, defaultSortArr, originalArr.Length);

            Array.Sort(defaultSortArr, (a, b) => b.CompareTo(a));

            return defaultSortArr;
        }


        private Random random;
        public delegate int[] MethodToMeasure(int[] arr);
        private int[] baseArr;

        public int[] BaseArr
        {
            get { return baseArr; }
            private set { baseArr = value; }
        }
    }
}