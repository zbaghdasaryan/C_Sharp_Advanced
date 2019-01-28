using System;
using System.IO;

// Копирование файлов.

namespace FileInfo_Copy
{
    class Program
    {
        static void Main()
        {
            // Создаем объект для работы с файлом.
            var file = new FileInfo(@"C:\Windows\notepad.exe");

            //     var dir = new DirectoryInfo(".");

            // Копируем содержимое файла.
            try
            {
                file.CopyTo(@"D:\notepad.exe");
                Console.WriteLine("Файл успешно скопирован!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
