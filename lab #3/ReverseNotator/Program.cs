using System.Linq.Expressions;

namespace ReverseNotator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string exp = "2 + 2 - 3 * (15 + 2)";
            var mc = ReverseNotator.Convert(exp);
            string result = "";
            foreach (var m in mc) { result += m + " "; }
            Console.WriteLine(result);
        }
    }
}