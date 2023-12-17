using System.Diagnostics;

namespace ArraySort
{
	public static class ArrSort
	{
        //Пошук мінімального та максимального значення у масиві
        private static int[] FindMinMax(int[] arr)
        {
            int[] result = new int[2];

            int min = arr[0];
            int max = arr[0];

            foreach (int element in arr)
            {
                if (element > max)
                {
                    max = element;
                }
                else if (element < min)
                {
                    min = element;
                }
            }

            result[0] = min;
            result[1] = max;

            return result;
        }

        public static int[] CountingSort(int[] arr)
        {
            int min = FindMinMax(arr)[0];
            int max = FindMinMax(arr)[1];

            //поправка
            int correctionFactor = min != 0 ? -min : 0;
            max += correctionFactor;

            int[] count = new int[max + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                count[arr[i] + correctionFactor]++;
            }

            int index = 0;
            for (int i = 0; i < count.Length; i++)
            {
                for (int j = 0; j < count[i]; j++)
                {
                    arr[index] = i - correctionFactor;
                    index++;
                }
            }

            return arr;
        }


        //Знаходження точки опори
        private static int FindPivot(int[] arr, int minIndex, int maxIndex)
        {   
            int pivot = minIndex -1;

            for (int i = minIndex; i < maxIndex; i++)
            {
                if (arr[i] < arr[maxIndex])
                {
                    pivot++;
                    Swap(ref arr[pivot], ref arr[i]);
                }
            }
            pivot++;
            Swap(ref arr[pivot], ref arr[maxIndex]);
            return pivot;
        }


        //Швидке сортування
        public static int[] QuickSort(int[] arr, int minIndex = 0, int maxIndex = -1)
        {
            if (maxIndex == -1) maxIndex = arr.Length - 1;

            if (minIndex >= maxIndex)
            {
                return arr;
            }

            int pivotIndex = FindPivot(arr, minIndex, maxIndex);
            QuickSort(arr, minIndex, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, maxIndex);

            return arr;
        }

        //Сортування з вибором
        public static int[] SelectionSort(int[] arr, int minIndex = 0, int maxIndex = -1)
        {
            if (maxIndex == -1) maxIndex = arr.Length;

            for (int j = minIndex; j < maxIndex; j++)
            {
                int minValue = j;

                for (int i = j; i < maxIndex; i++)
                {
                    if (arr[minValue] < arr[i])
                    {
                        minValue = i;
                    }
                }

                Swap(ref arr[j], ref arr[minValue]);
            }

            return arr;
        }

        //Своп
        private static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
    }
}
        