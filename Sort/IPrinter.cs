using System.Text;

namespace Sort
{
    /// <summary>
    /// Интерфейс с логикой печати массива
    /// </summary>
    interface IPrinter
    {
        /// <summary>
        /// Внутреннее хранилище сообщений (буфер).
        /// </summary>
        StringBuilder Builder { get; }
        /// <summary>
        /// Печать массива.
        /// </summary>
        /// <param name="array">Массив для печати.</param>
        void PrintArray(int[] array);
        /// <summary>
        /// Печать сообщения.
        /// </summary>
        /// <param name="message">Сообщение для печати.</param>
        void PrintMessage(string message);
        /// <summary>
        /// Печать сообщения с параметрами.
        /// </summary>
        /// <param name="message">Сообщение для печати.</param>
        /// <param name="parameter">Произвольный параметр сообщения.</param>
        void PrintMessage(string message, object parameter);
        /// <summary>
        /// Выгрузить содержимое внутреннего буфера/хранилища.
        /// </summary>
        void Flush();
    }
}