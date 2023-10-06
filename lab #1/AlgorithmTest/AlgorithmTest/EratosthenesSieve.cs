using System;
using System.Diagnostics;

namespace AlgorithmTest
{
    public static class EratosthenesSieve
    {

        public static KeyValuePair<int, bool>[] FirstSieveMethod(KeyValuePair<int, bool>[] originalKvpArray)
        {
            KeyValuePair<int, bool>[] resultKvpArray = originalKvpArray.ToArray();

            for (int i = 0; i < resultKvpArray.Length; i++)
            {
                if (resultKvpArray[i].Key == 2 || resultKvpArray[i].Key == 3) resultKvpArray[i] = new KeyValuePair<int, bool>(originalKvpArray[i].Key, true);
                else if (resultKvpArray[i].Key < 2) resultKvpArray[i] = new KeyValuePair<int, bool>(originalKvpArray[i].Key, false);
                else if (resultKvpArray[i].Key % 2 == 0 || resultKvpArray[i].Key % 3 == 0 || resultKvpArray[i].Key % 5 == 0)
                {
                    resultKvpArray[i] = new KeyValuePair<int, bool>(originalKvpArray[i].Key, false);
                }
            }

            return resultKvpArray;
        }


        public static TimeSpan MeasureExecutionTime(MethodToMeasure method, KeyValuePair<int, bool>[] originalKvpArray)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            method(originalKvpArray);

            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        public delegate KeyValuePair<int, bool>[] MethodToMeasure(KeyValuePair<int, bool>[] originalKvpArray);

    }
}

