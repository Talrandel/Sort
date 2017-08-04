namespace Sort.Sort_Algorithms
{
    class MergeSort : ISort
    {
        private int[] array;
        public void Sort(int[] array)
        {
            this.array = array;
            TempMergeSort(0, this.array.Length - 1);
        }

        private void TempMergeSort(int left, int right)
        {
            int split;
            if (left < right)
            {
                split = (left + right) / 2;
                TempMergeSort(left, split);
                TempMergeSort(split + 1, right);
                Merge(left, split, right);
            }
        }

        private void Merge(int left, int middle, int right)
        {
            int pos1 = left;
            int pos2 = middle + 1;
            int pos3 = 0;
            int[] temp = new int[right - left + 1];

            while (pos1 <= middle && pos2 <= right)
            {
                if (array[pos1] < array[pos2])
                    temp[pos3++] = array[pos1++];
                else
                    temp[pos3++] = array[pos2++];
            }

            while (pos2 <= right)
                temp[pos3++] = array[pos2++];
            while (pos1 <= middle)
                temp[pos3++] = array[pos1++];

            for (pos3 = 0; pos3 < temp.Length; pos3++)
                array[left + pos3] = temp[pos3];
        }
    }
}