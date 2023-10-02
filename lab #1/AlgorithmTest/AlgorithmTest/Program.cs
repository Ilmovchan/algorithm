using System;
using System.Diagnostics;

namespace AlgorithmTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Caesar cipher test

            /*CaesarCipher caesarCipher = new CaesarCipher();

            string message = "hello";
            int shift = 5;

            caesarCipher.Info(message, shift);*/


            //Array search test

            /*ArraySearch search = new ArraySearch();

            int[] simpleArr = search.Generate(30000, -50, 50);
            int needle = 49;

            search.Info(simpleArr, needle);*/

            //EratosthenesSieve sieve = new EratosthenesSieve();

            //var sieveArr = Generate.KeyValuePair(-50, 30);

            //var finishedSieve = sieve.FirstSieveMethod(sieveArr);

            //Console.WriteLine(sieve.MeasureExecutionTime(sieve.FirstSieveMethod, sieveArr));

            //foreach (var element in finishedSieve) Console.WriteLine(element);

            foreach (var element in Generate.KeyValuePair(50, 100)) Console.WriteLine(element);

            foreach (var element in Generate.IntArray(10, 50, 100)) Console.WriteLine(element);

            foreach (var element in Generate.BoolArray(10)) Console.WriteLine(element);
        }
    }
}
