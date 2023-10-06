using Numbers;

namespace ArraySort;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = Generate.Array<int>(10000);

        ArrSort.PrintInfo(arr);
    }
}

