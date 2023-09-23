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

            KeyValuePairGen generatorKVP1 = new KeyValuePairGen(10, -200, 200);

            KeyValuePairGen generatorKVP2 = new KeyValuePairGen(10, -200, 200);

            KeyValuePairGen generatorKVP3 = new KeyValuePairGen(10, -200, 200);

            generatorArr.PrintInfo();

            //generatorKVP1.PrintKeyValuePair(generatorKVP1.BaseKeyValuePair);

            //generatorKVP2.PrintKeyValuePair(generatorKVP2.BaseKeyValuePair);

            //generatorKVP3.PrintKeyValuePair(generatorKVP3.BaseKeyValuePair);
        }
    }
}