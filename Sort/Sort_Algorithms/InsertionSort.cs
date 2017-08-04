namespace Sort.Sort_Algorithms
{
    class InsertionSort : ISort
    {
        public void Sort(int[] array)
        {
            int temp = 0;
            int i, j;

            for (i = 0; i < array.Length; i++)
            {
                temp = array[i];
                for (j = i - 1; j >= 0 && array[j] > temp; j--)
                {
                    array[j + 1] = array[j];
                }
                array[j + 1] = temp;
            }
        }
    }
}