namespace Sort.Sort_Algorithms
{
    class ShellSort : ISort
    {
        public void Sort(int[] array)
        {
            int step = array.Length / 2;
            while (step > 0)
            {
                for (int i = 0; i < (array.Length - step); i++)
                {
                    int j = i;
                    while (j >= 0 && array[j] > array[j + step])
                    {
                        array.Swap(j, j + step);
                        j--;
                    }
                }
                step = step / 2;
            }
        }
    }
}