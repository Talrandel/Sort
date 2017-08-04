namespace Sort.Sort_Algorithms
{
    class SelectionSort : ISort
    {
        public void Sort(int[] array)
        {
            int minValueIndex;
            for (int i = 0; i < array.Length - 2; i++)
            {
                minValueIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minValueIndex])
                    {
                        minValueIndex = j;
                    }
                }
                array.Swap(i, minValueIndex);
            }
        }
    }
}