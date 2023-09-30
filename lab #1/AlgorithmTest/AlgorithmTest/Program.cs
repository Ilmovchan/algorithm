using System;
using System.Diagnostics;

namespace AlgorithmTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //CaesarCipher caesarCipher = new CaesarCipher();

            //string message = "hello";
            //int shift = 5;

            //caesarCipher.ToString(message, shift);



            ArraySearch search = new ArraySearch();

            int[] arr = search.SimpleGenerate(-30, 30);

            Console.WriteLine(search.SimpleSearch(arr, 6, 2, 5));

            Console.WriteLine(search.BinarySearch(arr, -13, 0, 20));
        }

    }
}
