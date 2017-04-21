using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            do
            {
                Console.WriteLine("Введи размер массива > 0: ");
                
            } while (!Int32.TryParse(Console.ReadLine(), out i));

            MyArray arr = new MyArray(i);
            while (true)
            {
                i = -1;
                do
                {
                    Console.WriteLine("Сортировки: глупая - 1, пузырьком - 2, вставками - 3, выбором - 4, быстрая - 5, пирамидальная - 6, Шелла - 7, бинарным деревом - 8, слиянием - 9, jsort - 10 ");
                    Console.WriteLine(" < 0 для выхода.");
                    Console.WriteLine("Введи номер сортировки: ");

                } while (!Int32.TryParse(Console.ReadLine(), out i));

                if (i < 0)
                {
                    break;
                }

                arr.Sort((SortType)i);
            }
        }
    }
}