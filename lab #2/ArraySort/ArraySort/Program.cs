using Numbers;

namespace ArraySort;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = Generate.Array<int>(100);

        int[] arr2 = {3,6,7,1,8,2,1,5, 25,5,15,3,7,98};

        //ArrSort.PrintInfo(arr);

        //Console.WriteLine(ArrSort.CompareInfo(arr));

        foreach (int elem in ArrSort.QuickSort(arr2)) Console.WriteLine(arr2);

        //Console.WriteLine(ArrSort.MeasureExecutionTime(ArrSort.QuickSort, arr)); 
    }
}

