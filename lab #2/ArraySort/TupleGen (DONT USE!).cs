using System;
using System.Collections.Generic;

namespace ArraySort
{
	public class TupleGen
	{
		public TupleGen(int length, int min, int max)
		{
			random = new Random();

			pairList = Generate(length, min, max);
		}

		private List<Tuple<int, int>> Generate(int length, int min, int max)
		{
			List<Tuple<int, int>> generatedList = new List<Tuple<int, int>>();

			for (int i = 1; i <= length; i++)
			{
				generatedList.Add(Tuple.Create(i, random.Next(min, max + 1)));
			}

			return generatedList;
		}

		public List<Tuple<int, int>> PairList
		{
			get { return pairList; }
			private set { pairList = value; }
		}

		private List<Tuple<int, int>> pairList = new List<Tuple<int, int>>();
		private Random random;
    }
}

