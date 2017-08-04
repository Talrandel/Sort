using System;
using System.Collections.Generic;
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

        #region Вспомогательные методы

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

        #endregion

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