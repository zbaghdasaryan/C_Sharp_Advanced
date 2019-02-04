using System;
using System.Threading;
using System.Threading.Tasks;

// Применение метода Parallel.Invoke() для параллельного выполнения лямбда-выражений.

namespace TPL
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Основной поток запущен.");

            // Выполнить параллельно два метода.
            Parallel.Invoke(
                () =>
                {
                    Console.WriteLine("Выражение 1 запущено.");
                    for (int count = 0; count < 5; count++)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("В выражении 1, счетчик равен: " + count);
                    }
                    Console.WriteLine("Выражение 1 завершено.");
                },
                () =>
                {
                    Console.WriteLine("Выражение 2 запущено.");
                    for (int count = 0; count < 5; count++)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("В выражении 2, счетчик равен: " + count);
                    }
                    Console.WriteLine("Выражение 2 завершено.");
                }
                );

            // Внимание!
            // Выполнение метода Main() приостанавливается, 
            // пока не произойдет возврат из метода Invoke().

            Console.WriteLine("Основной поток завершен.");

            // Delay.
            Console.ReadKey();
        }
    }
}
