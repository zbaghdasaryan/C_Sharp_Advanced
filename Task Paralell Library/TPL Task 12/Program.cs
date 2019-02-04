using System;
using System.Threading;
using System.Threading.Tasks;

// Применение метода Parallel.Invoke() для параллельного выполнения двух методов.

namespace TPL
{
    static class Program
    {
        // Метод который будет выполнен как задача.
        static void Method1()
        {
            Console.WriteLine("Method1() запущен.");
            for (int count = 0; count < 5; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine("В методе Method1(), счетчик равен: " + count);
            }
            Console.WriteLine("Method1() завершен.");
        }

        // Метод который будет выполнен как задача.
        static void Method2()
        {
            Console.WriteLine("Method2() запущен.");
            for (int count = 0; count < 5; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine("В методе Method2(), счетчик равен: " + count);
            }
            Console.WriteLine("Method2() завершен.");
        }

        static void Main()
        {
            Console.WriteLine("Основной поток запущен.");


            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount > 2
                                          ? Environment.ProcessorCount - 1 : 1
            };

            Console.WriteLine("Количество логических ядер центрального процессора:" + Environment.ProcessorCount);
            // Выполнить параллельно два метода.
            //Parallel.Invoke(Method1,Method2);

            Parallel.Invoke(Method1, Method2, Method1, Method2);

            // Внимание!
            // Выполнение метода Main() приостанавливается, 
            // пока не произойдет возврат из метода Invoke().

            Console.WriteLine("Основной поток завершен.");

            // Delay.
            Console.ReadKey();
        }
    }
}
