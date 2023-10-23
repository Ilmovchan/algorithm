using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTest
{
    public static class PrimeNumbers
    {
        public static void Demo(int start, int end)
        {
            if (Compare(FindPrimesUnoptimized(start, end), FindPrimesOptimized(start, end)))
            {
                List<int> primes = FindPrimesOptimized(start,end);

                Console.WriteLine($"Start: {start} \nEnd: {end} \n");
                Console.WriteLine("Prime numbers:");

                //foreach (var elem in primes) Console.WriteLine(elem);
                //Console.WriteLine('\n');

                Console.WriteLine("Unoptimised method time:" + MeasureExecutionTime(FindPrimesUnoptimized, start, end));
                Console.WriteLine("Optimised method time:" + MeasureExecutionTime(FindPrimesOptimized, start, end));
            }
            else
            {
                Console.WriteLine("Find primes methods work incorrectly");

                foreach (var elem in FindPrimesOptimized(start, end)) Console.WriteLine(elem);
                Console.WriteLine('\n');

                foreach (var elem in FindPrimesUnoptimized(start, end)) Console.WriteLine(elem);
            }
        }

        public static List<int> FindPrimesUnoptimized(int start, int end)
        {
            List<int> primes = new List<int>();
            for (int i = start; i <= end; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            return primes;
        }

        public static List<int> FindPrimesOptimized(int start, int end)
        {
            bool[] isPrime = new bool[end + 1];
            List<int> primes = new List<int>();

            for (int i = 2; i <= end; i++)
            {
                isPrime[i] = true;
            }

            for (int p = 2; p * p <= end; p++)
            {
                if (isPrime[p])
                {
                    for (int i = p * p; i <= end; i += p)
                    {
                        isPrime[i] = false;
                    }
                }
            }

            for (int i = Math.Max(2, start); i <= end; i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                }
            }

            return primes;
        }

        private static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
        public static bool Compare(List<int> list1, List<int> list2)
        {
            return list1.SequenceEqual(list2);
        }

        public static TimeSpan MeasureExecutionTime(SortingMethod method, int start, int end)
        {
            var watch = Stopwatch.StartNew();

            method(start, end);

            watch.Stop();
            return watch.Elapsed;
        }

        public delegate List<int> SortingMethod(int start, int end);
    }
}
