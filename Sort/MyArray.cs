using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sort
{
    /*
     * Пузырьком - 2, Перемешиванием, Гномья, Быстрая - 5, Расческой, Чёт-нечет
     * Выбором - 4, Пирамидальная - 6, Плавная
     * Вставками - 3, Шелла - 7, Деревом - 8
     * Слиянием - 9
     * Подсчётом, Поразрядная, Блочная
     * Introsort, Timsort
     * Топологическая, Сети, Битонная
     * Bogosort, Stooge Sort, Глупая - 1, Блинная
     * */
    enum SortType                                             
    {
        Stupid = 1,         // +
        Bubble = 2,         // +
        Insertion = 3,      // +
        Selection = 4,      // +

        Quick = 5,          // +
        Pyramid = 6,        // +
        Shell = 7,          // +
        BinaryTree = 8,     // +
        Merge = 9,          // +
        J = 10,             // +
        Smooth = 11,        // -
    }

    class TreeNode
    {
        public int value;
        public TreeNode left;
        public TreeNode right;
    }

    class MyArray
    {
        private int[] array;

        private int[] arrayCopy;

        private Random rand;

        public void SetSeed(int value)
        {
            rand = new Random(value);
        }

        public int this[int i]
        {
            get
            {
                return this.array[i];
            }
            set
            {
                this.array[i] = value;
            }
        }
        public void Sort(SortType sortType)
        {
            //Console.WriteLine("Массив до сортировки:");
            //this.Print();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            switch (sortType)
            {
                case SortType.Stupid:
                    StupidSort();
                    break;
                case SortType.Bubble:
                    BubbleSort();
                    break;
                case SortType.Insertion:
                    InsertionSort();
                    break;
                case SortType.Selection:
                    SelectionSort();
                    break;
                case SortType.Quick:
                    QuickSort();
                    break;
                case SortType.Shell:
                    ShellSort();
                    break;
                case SortType.Pyramid:
                    PyramidSort();
                    break;
                case SortType.BinaryTree:
                    TreeSort();
                    break;
                case SortType.Merge:
                    MergeSort();
                    break;
                case SortType.J:
                    JSort();
                    break;
                default:
                    Console.WriteLine("Не знаю такую сортировку.");
                    return;
            }
            sw.Stop();
            //Console.WriteLine("Отсортированный массив:");
            //this.Print();
            Console.WriteLine("Время сортировки: " + (sw.ElapsedMilliseconds / 1000.0).ToString() + " секунд.\n");
            CopyArray(arrayCopy, array);
        }



        private void Print()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        private void CopyArray(int[] from, int[] to)
        {
            for (int i = 0; i < array.Length; i++)
            {
                to[i] = from[i];
            }
        }

        private void StupidSort()
        {
            int i = 0;
            while (i < array.Length - 1)
            {
                if (array[i + 1] < array[i])
                {
                    Swap(i, i + 1);
                    i = 0;
                }
                else
                    i++;
            }
        }

        private void BubbleSort()
        {
            bool swapped = false;
            for (int i = 0; i < array.Length; i++) 
            {
                swapped = false;
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(j, j + 1);                        
                        swapped = true;
                    }                
                }         
            if(!swapped)
                break;
            }
        }

        private void InsertionSort()
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

        private void SelectionSort()
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
                Swap(i, minValueIndex);
            }
        }

        // NEW
        private void QuickSort()
        {
            tempQuickSort(0, array.Length - 1);
        }
        private void tempQuickSort(int left, int right)
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
                    Swap(i, j);
                    i++;
                    j--;
                }
            }
            if (i < right)
                tempQuickSort(i, right);
            if (left < j)
                tempQuickSort(left, j);
        }

        
        // NEW
        private void PyramidSort()
        {
            int n = array.Length;
            for (int i = n / 2; i > 0; i--)
                DownHeap(i, n);

            do
            {
                Swap(0, n - 1);
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

        
        // NEW
        private void JSort()
        {
            //Строим неубывающую кучу
            //Большие элементы из начала массива
            //закидываем поближе к концу
            for (int i = array.Length - 1; i >= 0; i--)
                reheap(i);

            //Строим невозрастающую кучу
            //Меньшие элементы из конца массива
            //закидываем поближе к началу
            for (int i = array.Length - 1; i >= 0; i--)
                invreheap(i);

            for (int j = 1; j < array.Length; j++)
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
        private void reheap(int i)
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
            while ((child < array.Length) && (!done))
            {
                //Если правый потомок в пределах массива
                if (child < array.Length - 1)
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
        private void invreheap (int i)
        {
		    bool done = false;

		    //Запоминаем отдельно родителя 
		    //и смотрим на его потомка слева
            int T = array[array .Length - 1 - i];
		    int parent = i;
		    int child = 2 * (i + 1) - 1;

		    while ((child < array.Length) && (!done)) 
            {			
			    //Если левый потомок в пределах массива
                if (child < array.Length - 1)
                {				
				    //То из левого и правого потомка выбираем наибольшего
                    if (array[array.Length - 1 - child] <= array[array.Length - 1 - (child + 1)]) 
                    {
					    child++;
				    }
			    }			
			    //Родитель больше потомков?
			    if (T > array[array.Length - 1 - child]) 
                {			
				    //Тогда с этим родителем и его потомками разобрались
				    done = true;				
			    } 
                else 
                {
				    array[array.Length - 1 - parent] = array[array.Length - 1 - child];
				    parent = child;
				    child = 2 * (parent + 1) - 1;				
			    }
		    }		
		    //Родитель, с которого всё начиналось
		    //передвигается ближе к началу массива
		    //(или остаётся на месте если не повезло)
		    array[array.Length - 1 - parent] = T;
		
    }


        // NEW
        private void ShellSort()
        {
            // wiki
            //int temp;
            //for (int i = array.Length/2; i > 0; i /= 2)
            //{
            //    for (int j = i; j < array.Length; j++)
            //    {
            //        temp = array[j];
            //        int k;
            //        for (k = j; k >= i; k -= i)
            //        {
            //            if (temp < array[k - i])
            //                array[k] = array[k - j];
            //            else
            //                break;
            //        }
            //        array[k] = temp;
            //    }
            //}

            // cybern.ru
            int step = array.Length / 2;//инициализируем шаг.
            while (step > 0)//пока шаг не 0
            {
                for (int i = 0; i < (array.Length - step); i++)
                {
                    int j = i;
                    //будем идти начиная с i-го элемента
                    while (j >= 0 && array[j] > array[j + step])
                    //пока не пришли к началу массива
                    //и пока рассматриваемый элемент больше
                    //чем элемент находящийся на расстоянии шага
                    {
                        //меняем их местами
                        Swap(j, j + step);
                        j--;
                    }
                }
                step = step / 2;//уменьшаем шаг
            }
        }


        // NEW
        private void MergeSort()
        {
            tempMergeSort(0, array.Length - 1);
        }
        private void tempMergeSort(int left, int right)
        {
            int split;
            if (left < right)
            {
                split = (left + right) / 2;
                tempMergeSort(left, split);
                tempMergeSort(split + 1, right);
                merge(left, split, right);
            }
        }
        private void merge(int left, int middle, int right)
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


        // NEW
        private void TreeSort()
        {
            TreeNode root = null;
            for (int i = 0; i < array.Length; i++)
            {
                root = AddToTree(root, array[i]);
            }
            TreeToArray(root);
        }
        private TreeNode AddToTree(TreeNode root, int newValue)
        {
            if (root == null)
            {
                root = new TreeNode();
                root.value = newValue;
                root.left = root.right = null;
                return root;
            }
            if (root.value < newValue)
            {
                root.right = AddToTree(root.right, newValue);
            }
            else
            {
                root.left = AddToTree(root.left, newValue);
            }
            return root;
        }
        private void TreeToArray(TreeNode root)
        {
            if (root == null)
                return;

            var stack = new Stack<TreeNode>();
            var node = root;
            var index = 0;
            while (stack.Count > 0 || node != null)
            {
                if (node == null)
                {
                    node = stack.Pop();
                    array[index++] = node.value;
                    node = node.right;
                }
                else
                {
                    stack.Push(node);
                    node = node.left;
                }
            }
        }


        private void Swap(int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private void FillArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(-100, 101);
            }
        }

        public MyArray(int n)
        {
            this.array = new int[n];
            this.arrayCopy = new int[n];
            this.rand = new Random();
            FillArray();
            CopyArray(array, arrayCopy);
        }
    }
}
