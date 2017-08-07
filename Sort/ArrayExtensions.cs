namespace Sort
{
    using System;
    using System.IO;
    /// <summary>
    /// Методы расширения для работы с массивами.
    /// </summary>
    static class ArrayExtensions
    {
        /// <summary>
        /// Поменять местами два элемента массива с заданными индексами.
        /// </summary>
        /// <param name="array">Исходный массив, к элементам которого применяется метод.</param>
        /// <param name="i">Индекс первого элемента для перестановки.</param>
        /// <param name="j">Индекс второго элемента для перестановки.</param>
        public static void Swap(this int[] array, int i, int j)
        {
            // Спасибо stackoverflow - крайне полезная проверка.
            if (i == j)
                return;
            // 1 способ - классический.
            //var temp = array[i];
            //array[i] = array[j];
            //array[j] = temp;
            // 2 способ - должен же я знать XOR swap. 
            // PS. логично, что работать должно только для интов, сложно сказать то же про другие типы.
            array[i] = array[i] ^ array[j];
            array[j] = array[j] ^ array[i];
            array[i] = array[i] ^ array[j];
        }

        /// <summary>
        /// Загрузить массив из текстового файла.
        /// </summary>
        /// <param name="array">Исходный массив - класс Array?</param>
        /// <param name="fileName">Имя файла, из которого будет производиться загрузка массива.</param>
        /// <returns>Одномерный массив int[], считанный из файла с указанным именем.</returns>
        public static int[] LoadFromFile(this int[] array, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException(nameof(fileName));
            if (!File.Exists(fileName))
                throw new FileNotFoundException(nameof(fileName));
            int[] _arr;
            var lines = File.ReadAllLines(fileName);
            // TODO: Возможно, следует задавать элементу массива конкретное значение в случае неудачного преобразования строки к int? Сейчас будет 0, что может быть не всегда корректно. Например, можно задавать int.MinValue.
            if (lines.Length == 1)
            {
                var elems = lines[0].Split(new char[] { ',', ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);
                _arr = new int[elems.Length];
                for (int i = 0; i < elems.Length; i++)
                    int.TryParse(elems[i], out _arr[i]);
            }
            else
            {
                _arr = new int[lines.Length];
                for (int i = 0; i < _arr.Length; i++)
                    int.TryParse(lines[i], out _arr[i]);
            }
            return _arr;
        }
    }
}