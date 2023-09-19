using System;
using System.Diagnostics;

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

        private int[] Generate(int length, int min, int max)
        {
            int[] generatedArr = new int[length];

            for (int i = 0; i < generatedArr.Length; i++)
            {
                generatedArr[i] = random.Next(min, max + 1);
            }

            return generatedArr;
        }



        private int[] DefaultSort(int[] originalArr)
        {
            int[] defaultSortArr = new int[originalArr.Length];

            Array.Copy(originalArr, defaultSortArr, originalArr.Length);

            Array.Sort(defaultSortArr);

            return defaultSortArr;
        }

        public long DefaultSortTime()
        {
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

