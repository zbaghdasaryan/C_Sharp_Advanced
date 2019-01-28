using System;
using System.IO;

// Пример работы с классом Path.

namespace PathDemo
{
    class Program
    {
        static void Main()
        {
            // Создание строки, содержащей адрес.
            string path = @"C:\Windows\notepad.exe";
            Console.WriteLine(path);

            // Вывод на экран значений свойств класса-объекта Path.
            Console.WriteLine("Ext: {0}", Path.GetExtension(path));

            // ChangeExtension не изменяет расширение у файла — он просто создает строку с другим расширением, 
            // которую вы сами должны использовать для реального переименования (например, через статический метод Move класса File) 
            Console.WriteLine("Change Path: {0}", path = Path.ChangeExtension(path, "bak"));
            Console.WriteLine(path);

            // Delay.
            Console.ReadKey();
        }
    }
}
