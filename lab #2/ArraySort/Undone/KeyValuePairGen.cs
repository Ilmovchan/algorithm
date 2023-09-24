using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Linq;

namespace ArraySort
{
    public class KeyValuePairGen
    {
        public KeyValuePairGen(int length, int min, int max)
        {
            random = new Random();

            BaseKeyValuePair = Generate(length, min, max);
        }

        //Метод для виводу масиву пар
        public void PrintKeyValuePair(KeyValuePair<int, int>[] keyValuePair)
        {
            foreach (var element in keyValuePair) Console.WriteLine(element);

            Console.WriteLine('\n');
        }

        //Метод генерації масиву пар (ключі - значення)
        private KeyValuePair<int, int>[] Generate(int length, int min, int max)
        {
            KeyValuePair<int, int>[] keyValuePairs = new KeyValuePair<int, int>[length];

            for (int i = 0; i < length; i++)
            {
                int key = i + 1;

                int value = random.Next(min, max + 1);

                keyValuePairs[i] = new KeyValuePair<int, int>(key, value);
            }

            return keyValuePairs;
        }

        ////Метод стійкого сортування
        //public KeyValuePair<int, int>[] StableSort(KeyValuePair<int, int>[] originalKeyValuePair)
        //{
        //    KeyValuePair<int, int>[] stableSortArr = originalKeyValuePair.ToArray();

        //    Array.Sort(stableSortArr, (x, y) => x.Value.CompareTo(y.Value));

        //    return stableSortArr;
        //}

        //private KeyValuePair<int, int>[] BubbleSort(KeyValuePair<int, int>[] originalKeyValuePair)
        //{
        //    KeyValuePair<int, int>[] stableSortArr = originalKeyValuePair.ToArray();

        //    for (int i = 0; i < stableSortArr.Length - 1; i++)
        //    {
        //        for (int j = 0; j < stableSortArr.Length - 1 - i; j++)
        //        {
        //            if (stableSortArr.Key < bubbleSortArr[j + 1])
        //            {
        //                int tmp = bubbleSortArr[j];
        //                bubbleSortArr[j] = bubbleSortArr[j + 1];
        //                bubbleSortArr[j + 1] = tmp;
        //            }
        //        }
        //    }

        //    return bubbleSortArr;
        //}

        private Random random;
        private KeyValuePair<int, int>[] baseKeyValuePair;

        public KeyValuePair<int, int>[] BaseKeyValuePair
        {
            get { return baseKeyValuePair; }
            private set { baseKeyValuePair = value; }
        }
    }
}

