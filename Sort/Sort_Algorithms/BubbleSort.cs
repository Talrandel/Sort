namespace Sort.Sort_Algorithms
{
    class BubbleSort : ISort
    {
        public void Sort(int[] array)
        {
            bool swapped = false;
            for (int i = 0; i < array.Length; i++)
            {
                swapped = false;
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        array.Swap(j, j + 1);
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
            }
        }
    }
}