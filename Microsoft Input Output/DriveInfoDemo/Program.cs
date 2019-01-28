using System;
using System.IO;

// Получение информации о дисках.

namespace DriveInfoDemo
{
    class Program
    {
        static void Main()
        {
            // Создание коллекции дисков.
            DriveInfo[] drives = DriveInfo.GetDrives();

            // Вывод информации о дисках компьютера.
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("Drive: {0} Type: {1}", drive.Name, drive.DriveType);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
