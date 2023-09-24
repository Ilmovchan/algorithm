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
            ArrGen generatorArr = new ArrGen(5, -300, 300); //Розмір масиву, мін та макс значення при генерації

            generatorArr.PrintInfo();
        }
    }
}