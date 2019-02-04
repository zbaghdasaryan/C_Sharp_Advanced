using System;
using System.Threading;
using System.Threading.Tasks;

// Возвращение значения из задачи.

namespace TPL
{
    class Program
    {
        // Метод который будет возвращать результат.
        static bool MyTask()
        {
            //   throw new Exception();
            return true;
        }

        // Метод возвращает сумму.
        static int SumIt(object v)
        {
            int x = (int)v, sum = 0;

            for (; x > 0; x--)
                sum += x;

            Thread.Sleep(3000);
            return sum;
        }

        static void Main()
        {
            Console.WriteLine("Основной поток запущен.");

            // Создание экземпляра первой задачи.
            Task<bool> task1 = Task<bool>.Factory.StartNew(MyTask);
            Console.WriteLine("Результат выполнения задачи MyTask: " + task1.Result);

            // Создание экземпляра второй задачи.
            Task<int> task2 = Task<int>.Factory.StartNew(SumIt, 3);
            Console.WriteLine("Результат выполнения задачи SumIt: " + task2.Result);

            task1.Dispose();
            task2.Dispose();

            Console.WriteLine("Основной поток завершен.");

            // Delay.
            Console.ReadKey();
        }
    }
}
