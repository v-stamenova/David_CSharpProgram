using System;
using System.Collections.Generic;

namespace GenericSortingAlgorithms
{
	static class Algorithms<T> where T : IComparable<T>
	{
		public static void BubbleSort(IList<T> list)
		{
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if(list[j].CompareTo(list[j + 1]) > 0)
                    {
						T temp = list[j];
						list[j] = list[j + 1];
						list[j + 1] = temp;
					}
                }
            }
        }

		public static void SelectionSort(IList<T> list)
		{
            for (int i = 0; i < list.Count - 1; i++)
            {
                int indexMin = i;
                for (int j = i + 1; j < list.Count; j++)
				{
                    if (list[indexMin].CompareTo(list[j]) > 0)
					{
                        indexMin = j;
                    }
                }

                T temp = list[indexMin];
                list[indexMin] = list[i];
                list[i] = temp;
            }
        }

        public static void InsertionSort(IList<T> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                T key = list[i];
                int j = i - 1;

                while (j >= 0 && list[j].CompareTo(key) > 0)
                {
                    list[j + 1] = list[j];
                    j = j - 1;
                }
                list[j + 1] = key;
            }
        }

        public static void QuickSort(IList<T> list, int left, int right)
        {
            if (left < right)
            {
                int partitionIndex = Partition(list, left, right);

                QuickSort(list, left, partitionIndex - 1);
                QuickSort(list, partitionIndex + 1, right);
            }
        }

        private static int Partition(IList<T> list, int left, int right)
        {
            T pivot = list[right];

            int leftIndex = left - 1;

            T temp = default;
            for (int i = left; i < right; i++)
            {
                if(list[i].CompareTo(pivot) <= 0)
                {
                    leftIndex++;

                    temp = list[leftIndex];
                    list[leftIndex] = list[i];
                    list[i] = temp;
                }
            }

            temp = list[leftIndex + 1];
            list[leftIndex + 1] = list[right];
            list[right] = temp;

            return leftIndex + 1;
        }

    }
}
