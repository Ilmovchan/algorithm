using Numbers;

namespace ArraySort;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = Generate.Array<int>(5);

        ArrSort.PrintInfo(arr);
    }
}

