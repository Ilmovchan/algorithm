using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace ArraySort
{
    public class ArrGen
    {

        public ArrGen(int lenght, int min, int max)
        {
            random = new Random();

            BaseArr = Generate(lenght, min, max);

        }

        //Метод для виводу результату
        public override string ToString()
        {
            string result = "";

            result += "Bubble sort time: " + MeasureMethodExecutionTime(BubbleSort, BaseArr) + "\n";
            result += "Default sort time: " + MeasureMethodExecutionTime(DefaultSort, BaseArr) + "\n";
            result += "Linq sort time: " + MeasureMethodExecutionTime(LinqSort, BaseArr) + "\n";

            return result;
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

        //Метод для порівняння результату сортування
        public bool SortCompare()
        {
            int[][] arrComp = { DefaultSort(BaseArr), LinqSort(BaseArr) , BubbleSort(BaseArr)};

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

        // Метод для заміра часу виконання сортування
        public static TimeSpan MeasureMethodExecutionTime(MethodToMeasure method, int[] arr)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();

            method(arr);

            stopwatch.Stop();
            return stopwatch.Elapsed;
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

