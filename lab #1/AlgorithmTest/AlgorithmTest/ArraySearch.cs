using System;
namespace AlgorithmTest
{
	public class ArraySearch
	{
		public ArraySearch()
		{
            random = new Random();
		}

        public int[] RandomGenerate()
        {
            int[] generatedArr = new int[random.Next(50)];

            for (int i = 0; i < generatedArr.Length; i++)
            {
                generatedArr[i] = random.Next(-200, 200);
            }

            return generatedArr;
        }

        public int[] SimpleGenerate(int min, int max)
        {
            int[] generatedArr = new int[max - min + 1];

            for (int i = min; i <= max; i++)
            {
                generatedArr[i - min] = i;
            }

            return generatedArr;
        }

        public bool SimpleSearch(int[] stack, int needle, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if (stack[i] == needle) return true;
            }
            return false;
        }

        public bool BinarySearch(int[] stack, int needle, int start, int end)
        {
            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (stack[mid] == needle) return true;
                else if (stack[mid] < needle) start = mid + 1;
                else if (stack[mid] > needle) end = mid - 1;
            }

            return false;
        }

        Random random;
    }
}

