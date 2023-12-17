using System;
using System.Collections.Generic;

namespace ReverseNotator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReverseNotator result = new ReverseNotator();
            string str = "abs ( sqrt ( 2 ) - 10 ) + 11 % 2";
            result.Demo(str);
        }
    }
}