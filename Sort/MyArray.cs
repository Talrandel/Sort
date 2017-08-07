using Sort.Sort_Algorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sort
{
    /// <summary>
    /// Класс массива с возможностью его сортировки.
    /// </summary>
    class MyArray
    {
        #region Поля, свойства, константы

        /// <summary>
        /// Нижняя граница для генерации элементов массива.
        /// </summary>
        private readonly int _lowerBound;
        /// <summary>
        /// Верхняя граница для генерации элементов массива.
        /// </summary>
        private readonly int _upperBound;
        /// <summary>
        /// Константа границ по умолчанию для генерации элемента массива.
        /// </summary>
        private const int _constBounds = 10000;
        /// <summary>
        /// Исходный массив для сортировки.
        /// </summary>
        private int[] _array;
        /// <summary>
        /// Копия исходного массива.
        /// </summary>
        private int[] _arrayCopy;
        /// <summary>
        /// Генератор ПСЧ.
        /// </summary>
        private Random _rand;
        /// <summary>
        /// Исходное значение для генератора ПСЧ по умолчанию.
        /// </summary>
        private const int _constSeed = 0;
        /// <summary>
        /// Объект для печати массива, результатов сортировок и прочего.
        /// </summary>
        private IPrinter _printer;
        /// <summary>
        /// Словарь пар "тип сортировки - реализация".
        /// </summary>
        private Dictionary<SortTypes, ISort> _sortMethods;
        /// <summary>
        /// Словарь пар "тип сортировки - ее имя".
        /// </summary>
        private Dictionary<SortTypes, string> _sortNames;

        #endregion

        #region Конструкторы
        /// <summary>
        /// Самый полный конструктор класса.
        /// </summary>
        /// <param name="arrayLength">Размер массива для сортировки.</param>
        /// <param name="seed">Начальное значение для генератора ПСЧ.</param>
        /// <param name="bounds">Границы генерации элементов массива.</param>
        /// <param name="printer">Реализация интерфейса <see cref="IPrinter"/>.</param>
        public MyArray(int arrayLength, int seed, int bounds, IPrinter printer)
        {
            _array = new int[arrayLength];
            _arrayCopy = new int[arrayLength];
            _rand = new Random(seed);
            _lowerBound = (-1) * Math.Abs(bounds);
            _upperBound = Math.Abs(bounds);
            _printer = printer;
            FillArrayWithRandomValues();
            CopyArray(_array, _arrayCopy);
            InitializeSortAlgorithms();
        }

        /// <summary>
        /// Простой конструктор по умолчанию, принимающий размер массива. По умолчанию ведет печать в консоли.
        /// </summary>
        /// <param name="arrayLength">Размер массива для сортировки.</param>
        public MyArray(int arrayLength) : this(arrayLength, _constSeed, _constBounds, new ConsolePrinter())
        { }

        /// <summary>
        /// Конструктор, принимающий размер массива и объект типа <see cref="IPrinter"/> для печати логов работы приложения.
        /// </summary>
        /// <param name="arrayLength">Размер массива для сортировки.</param>
        /// <param name="printer">Реализация интерфейса <see cref="IPrinter"/>.</param>
        public MyArray(int arrayLength, IPrinter printer) : this(arrayLength, _constSeed, _constBounds, printer)
        { }

        #endregion

        #region Методы

        /// <summary>
        /// Индексатор массива.
        /// </summary>
        /// <param name="i">Индекс запрашиваемого элемента.</param>
        /// <returns>Запрашиваемый элемент массива.</returns>
        public int this[int i]
        {
            get
            {
                // TODO: Возможно, тут следует выбрасывать исключение, а не корректировать значение индекса.
                if (i < 0)
                    i = 0;
                else if (i >= _array.Length)
                    i = _array.Length - 1;
                return _array[i];
            }
            set
            {
                if (i < 0)
                    i = 0;
                else if (i >= _array.Length)
                    i = _array.Length - 1;
                _array[i] = value;
            }
        }

        /// <summary>
        /// Установить новое начальное значение значение для <see cref="_rand"/>.
        /// </summary>
        /// <param name="value">Новое начальное значение <see cref="_rand"/>.</param>
        public void SetSeed(int value)
        {
            _rand = new Random(value);
        }

        /// <summary>
        /// Сортировка текущего массива с применением заданных сортировок.
        /// </summary>
        /// <param name="sortTypes">Массив (любого размера) с типами сортировок, которыми следует его сортировать.</param>
        public void Sort(params SortTypes[] sortTypes)
        {
            Stopwatch sw = new Stopwatch();
            long elapsedMS = 0;
            for (int i = 0; i < sortTypes.Length; i++)
            {
                if (_sortMethods.ContainsKey(sortTypes[i]))
                {
                    sw.Reset();
                    sw.Start();
                    _sortMethods[sortTypes[i]].Sort(_array);
                    sw.Stop();
                    elapsedMS = sw.ElapsedMilliseconds;// / 1000;
                    _printer.PrintMessage(string.Format("Массив на {0} элементов был отсортирован алгоритмом/методом {1} за {2} милисекунд.", _array.Length, Enum.GetName(typeof(SortTypes), sortTypes[i]), elapsedMS));
                    CopyArray(_arrayCopy, _array);
                }
            }
            _printer.Flush();
        }

        /// <summary>
        /// Печать массива, используя реализацию выбранного объекта IPrinter.
        /// </summary>
        public void PrintArray()
        {
            _printer.PrintArray(_array);
        }

        /// <summary>
        /// Копировать все элементы исходного массива в конечный.
        /// </summary>
        /// <param name="from">Исходный массив.</param>
        /// <param name="to">Конечный массив.</param>
        private void CopyArray(int[] from, int[] to)
        {
            for (int i = 0; i < _array.Length; i++)
                to[i] = from[i];
        }

        /// <summary>
        /// Заполнение исходного массива случайными значениями.
        /// </summary>
        private void FillArrayWithRandomValues()
        {
            for (int i = 0; i < _array.Length; i++)
                _array[i] = _rand.Next(_lowerBound, _upperBound);
        }

        /// <summary>
        /// Заполнение исходного массива значениями из внешнего текстового файла.
        /// </summary>
        /// <param name="fileName">Имя файла с содержимым одномерного массива.</param>
        private void FillArrayFromFile(string fileName)
        {
            _array = new int[1].LoadFromFile(fileName);
        }

        /// <summary>
        /// Инициализация словаря с реализациями сортировок.
        /// </summary>
        private void InitializeSortAlgorithms()
        {
            // TODO: Заполнять из внешнего xml-файла?
            _sortMethods = new Dictionary<SortTypes, ISort>();
            _sortMethods.Add(SortTypes.Bubble, new BubbleSort());
            _sortMethods.Add(SortTypes.Insertion, new InsertionSort());
            _sortMethods.Add(SortTypes.Merge, new MergeSort());
            _sortMethods.Add(SortTypes.Quick, new QuickSort());
            _sortMethods.Add(SortTypes.Shell, new ShellSort());
            _sortMethods.Add(SortTypes.BinaryTree, new TreeSort());
            _sortMethods.Add(SortTypes.Selection, new SelectionSort());
            _sortMethods.Add(SortTypes.J, new JSort());
            _sortMethods.Add(SortTypes.Pyramid, new PyramidSort());
            // TODO: Заполнять _sortNames?
        }

        #endregion
    }
}