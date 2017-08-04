namespace Sort.Sort_Algorithms
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
     */
    enum SortTypes
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
}