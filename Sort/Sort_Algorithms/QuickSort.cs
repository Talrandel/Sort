namespace Sort.Sort_Algorithms
{
    class QuickSort : ISort
    {
        private int[] array;

        public void Sort(int[] array)
        {
            this.array = array;
            TempQuickSort(0, array.Length - 1);
        }
        private void TempQuickSort(int left, int right)
        {
            int x = array[left + (right - left) / 2];
            //int x = array[(left + right) / 2];
            int i = left;
            int j = right;

            while (i <= j)
            {
                while (array[i] < x)
                    i++;
                while (array[j] > x)
                    j--;
                if (i <= j)
                {
                    array.Swap(i, j);
                    i++;
                    j--;
                }
            }
            if (i < right)
                TempQuickSort(i, right);
            if (left < j)
                TempQuickSort(left, j);
        }
    }
}