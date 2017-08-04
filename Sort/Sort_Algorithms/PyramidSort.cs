namespace Sort.Sort_Algorithms
{
    class PyramidSort : ISort
    {
        private int[] array;
        public void Sort(int[] array)
        {
            this.array = array;
            int n = this.array.Length;
            for (int i = n / 2; i > 0; i--)
                DownHeap(i, n);

            do
            {
                array.Swap(0, n - 1);
                n--;
                DownHeap(1, n);
            } while (n > 1);
        }
        private void DownHeap(int i, int n)
        {
            int t = array[i - 1];
            while (i <= n / 2)
            {
                int j = i + i;
                if ((j < n)
                    && (array[j - 1] < array[j]))
                    j++;
                if (t >= array[j - 1])
                    break;
                else
                {
                    array[i - 1] = array[j - 1];
                    i = j;
                }
            }
            array[i - 1] = t;
        }
    }
}