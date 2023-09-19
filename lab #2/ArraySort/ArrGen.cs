﻿using System;
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
            timeCounter = new Stopwatch();

            BaseArr = Generate(lenght, min, max);

        }

        public override string ToString()
        {
            string result = "";

            result += "Default sort time: " + DefaultSortTime() + "\n";
            result += "Linq sort time: " + LinqSortTime() + "\n";

            return result;
        }

        private int[] Generate(int length, int min, int max)
        {
            int[] generatedArr = new int[length];

            for (int i = 0; i < generatedArr.Length; i++)
            {
                generatedArr[i] = random.Next(min, max + 1);
            }

            return generatedArr;
        }

        public bool SortTest()
        {
            int[][] arrComp = {DefaultSort(BaseArr), LinqSort(BaseArr)};

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

        private int[] LinqSort(int[] originalArr)
        {
            int[] linqSortArr = new int[originalArr.Length];

            Array.Copy(originalArr, linqSortArr, originalArr.Length);

            IEnumerable<int> sortedNumbersDescending = linqSortArr.OrderByDescending(number => number);

            return sortedNumbersDescending.ToArray();
        }

        public long LinqSortTime()
        {
            timeCounter.Reset();

            timeCounter.Start();

            LinqSort(BaseArr);

            timeCounter.Stop();

            return timeCounter.ElapsedTicks;
        }

        private int[] DefaultSort(int[] originalArr)
        {
            int[] defaultSortArr = new int[originalArr.Length];

            Array.Copy(originalArr, defaultSortArr, originalArr.Length);

            Array.Sort(defaultSortArr, (a, b) => b.CompareTo(a));

            return defaultSortArr;
        }

        public long DefaultSortTime()
        {
            timeCounter.Reset();

            timeCounter.Start();

            DefaultSort(BaseArr);

            timeCounter.Stop();

            return timeCounter.ElapsedTicks;
        }


        private Random random;
        private Stopwatch timeCounter;
        private int[] baseArr;

        public int[] BaseArr
        {
            get { return baseArr; }
            private set { baseArr = value; }
        }
    }
}

