using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrGen generator = new ArrGen(10, -300, 300);

            int[] baseArr = generator.BaseArr;

            foreach (int element in baseArr)
            {
                Console.WriteLine(element + " ");
            }

            Console.WriteLine("\n");

            Console.WriteLine(Convert.ToString(generator.DefaultSortTime()));
        }
    }
}
