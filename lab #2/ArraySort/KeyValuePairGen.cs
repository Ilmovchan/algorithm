using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace ArraySort
{
	public class KeyValuePairGen
	{
		public KeyValuePairGen(int length, int min, int max)
		{
            random = new Random();

            baseKeyValuePair = Generate(length, min, max);
        }

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

        //private KeyValuePair<int, int>[] StableSort(KeyValuePair<int, int>[] originalKVP)
        //{
        //    KeyValuePair<int, int>[] stableSortKVP = new KeyValuePair<int, int>[originalKVP.Length];



        //    return;
        //}

        public void PrintKeyValuePair(KeyValuePair<int, int>[] keyValuePair)
        {
            foreach (var element in keyValuePair) Console.WriteLine(element);

            Console.WriteLine('\n');
        }

        private Random random;
        private KeyValuePair<int, int>[] baseKeyValuePair;

        public KeyValuePair<int, int>[] BaseKeyValuePair
        {
            get { return baseKeyValuePair; }
            private set { baseKeyValuePair = value; }
        }
    }
}

