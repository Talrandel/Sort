using System.IO;
using System.Text;

namespace Sort
{
    // TODO: Комментарии к FilePrinter
    class FilePrinter : IPrinter
    {
        private const string FileNameBase = "Sort.txt";

        public StringBuilder Builder { get; }

        private string _fileName;

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
            using (StreamWriter sw = new StreamWriter(_fileName))
            {
                sw.Write(Builder.ToString());
            }
            Builder.Clear();
        }

        public FilePrinter(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                fileName = FileNameBase;
            _fileName = fileName;
            Builder = new StringBuilder();
        }

        public FilePrinter() : this(FileNameBase)
        {   }
    }
}