using System;
using System.Threading;
using System.Threading.Tasks;

// Использование лямбда-выражения в качестве задачи.

namespace TPL
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Основной поток запущен.");

            // Использование лямбда-оператора для определения задачи.
            Task task = Task.Factory.StartNew(new Action(() =>
            {
                Console.WriteLine("Задача запущена.");
                for (int count = 0; count < 10; count++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("В лямбда-операторе, счетчик равен: " + count);
                }
                Console.WriteLine("Задача завершена.");
            }));

            // Ожидание завершения задачи.
            task.Wait();

            // Освобождение задачи. 
            task.Dispose();

            Console.WriteLine("Основной поток завершен.");

            // Delay.
            Console.ReadKey();
        }
    }
}
