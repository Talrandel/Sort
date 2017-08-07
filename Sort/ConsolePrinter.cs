using System;
using System.Text;

namespace Sort
{
    // TODO: Комментарии к ConsolePrinter
    class ConsolePrinter : IPrinter
    {
        public StringBuilder Builder { get; }

        public ConsolePrinter()
        {
            // TODO: Возможен вариант с инициализацией емкостью сразу на N символов.
            Builder = new StringBuilder();
        }

        public void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Builder.Append(array[i] + " ");
            Builder.AppendLine();
        }

        public void PrintMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
                return;
            Builder.AppendLine(message);
        }

        public void PrintMessage(string message, object parameter)
        {
            if (string.IsNullOrEmpty(message))
                return;
            if (parameter == null)
            {
                PrintMessage(message);
                return;
            }
            Builder.AppendLine(string.Format(message, parameter));
        }

        public void Flush()
        {
            Console.WriteLine(Builder.ToString());
            Builder.Clear();
        }
    }
}