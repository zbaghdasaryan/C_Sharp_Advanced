using System;
using System.Diagnostics;
using System.IO;

// Отслеживание изменений в системе.

namespace FileSystemWatcherDemo
{
    class Program
    {
        static void Main()
        {
            // Создание наблюдателя и сосредоточение его внимания на системном диске.
            var watcher = new FileSystemWatcher { Path = @"." };

            // Зарегистрировать обработчики событий.
            watcher.Created += new FileSystemEventHandler(WatcherChanged);
            //  watcher.Deleted += WatcherChanged;

            // Начать мониторинг.
            watcher.EnableRaisingEvents = true;

            // Delay.
            var change = watcher.WaitForChanged(WatcherChangeTypes.All);
            Console.WriteLine(change.ChangeType);
        }

        // Обработчик события.
        static void WatcherChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Directory changed({0}): {1}", e.ChangeType, e.FullPath);
        }
    }
}
