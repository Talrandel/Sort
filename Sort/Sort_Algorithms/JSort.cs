namespace Sort.Sort_Algorithms
{
    class JSort : ISort
    {
        private int[] array;
        private int len;
        public void Sort(int[] array)
        {
            this.array = array;
            len = this.array.Length;
            //Строим неубывающую кучу
            //Большие элементы из начала массива
            //закидываем поближе к концу
            for (int i = len - 1; i >= 0; i--)
                ReHeap(i);

            //Строим невозрастающую кучу
            //Меньшие элементы из конца массива
            //закидываем поближе к началу
            for (int i = len - 1; i >= 0; i--)
                InvReHeap(i);

            for (int j = 1; j < len; j++)
            {
                int T = array[j];
                int i = j - 1;
                while (i >= 0 && array[i] > T)
                {
                    array[i + 1] = array[i];
                    i--;
                }
                array[i + 1] = T;
            }
        }
        private void ReHeap(int i)
        {
            //С этим родителем ещё не разобрались
            bool done = false;

            //Запоминаем отдельно родителя 
            //и смотрим на его потомка слева
            int T = array[i];
            int parent = i;
            int child = 2 * (i + 1) - 1;

            //Просматриваем потомков, а также потомков потомков
            //и сравниваем их с родителем (если что - передвигаем потомков влево)
            //Цикл продолжается пока не выпадем за пределы массива
            //или пока не обменяем какого-нибудь потомка на родителя.		
            while ((child < len) && (!done))
            {
                //Если правый потомок в пределах массива
                if (child < len - 1)
                {
                    //То из левого и правого потомка выбираем наименьшего
                    if (array[child] >= array[child + 1])
                    {
                        child++;
                    }
                }

                //Родитель меньше потомков?
                if (T < array[child])
                {
                    //Тогда с этим родителем и его потомками разобрались
                    done = true;
                    //Родитель НЕ меньше чем наименьший из его потомков.
                    //Перемещаем потомка на место родителя
                    //и с родителем в цикле сравниваем уже потомков этого потомка			
                }
                else
                {
                    array[parent] = array[child];
                    parent = child;
                    child = 2 * (parent + 1) - 1;
                }
            }

            //Родитель, с которого всё начиналось
            //передвигается ближе к концу массива
            //(или остаётся на месте если не повезло)
            array[parent] = T;

        }
        private void InvReHeap(int i)
        {
            bool done = false;

            //Запоминаем отдельно родителя 
            //и смотрим на его потомка слева
            int T = array[len - 1 - i];
            int parent = i;
            int child = 2 * (i + 1) - 1;

            while ((child < len) && (!done))
            {
                //Если левый потомок в пределах массива
                if (child < len - 1)
                {
                    //То из левого и правого потомка выбираем наибольшего
                    if (array[len - 1 - child] <= array[len - 1 - (child + 1)])
                    {
                        child++;
                    }
                }
                //Родитель больше потомков?
                if (T > array[len - 1 - child])
                {
                    //Тогда с этим родителем и его потомками разобрались
                    done = true;
                }
                else
                {
                    array[len - 1 - parent] = array[len - 1 - child];
                    parent = child;
                    child = 2 * (parent + 1) - 1;
                }
            }
            //Родитель, с которого всё начиналось
            //передвигается ближе к началу массива
            //(или остаётся на месте если не повезло)
            array[len - 1 - parent] = T;
        }
    }
}