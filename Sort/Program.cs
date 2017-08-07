using System;
using Sort.Sort_Algorithms;
using System.Diagnostics;

namespace Sort
{
    class Program
    {
        // TODO: запуск с параметрами - без интерфейса, с параметрами - ручной режим.
        // TODO: читать данные на старте из файла? Конфиг ли?
        static void Main(string[] args)
        {
            int i;
            do
            {
                Console.WriteLine("Введи размер массива > 0: ");
                
            } while (!Int32.TryParse(Console.ReadLine(), out i));

            FilePrinter fPrinter = new FilePrinter();
            MyArray arr = new MyArray(i, fPrinter);
            SortTypes[] sortTypes = { SortTypes.BinaryTree, SortTypes.Bubble, SortTypes.Insertion, SortTypes.J, SortTypes.Merge, SortTypes.Pyramid, SortTypes.Quick, SortTypes.Selection, SortTypes.Shell };
            arr.Sort(sortTypes);
            Console.WriteLine("sorted");
            Process.Start("notepad++", "Sort.txt");
        }
    }
}