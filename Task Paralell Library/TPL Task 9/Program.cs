using System;
using System.Threading;
using System.Threading.Tasks;

// Лямбда-выражение в качестве продолжения задачи.

namespace TPL
{
    class Program
    {
        // Метод который будет выполнен как задача.
        static void MyTask()
        {
            Console.WriteLine("MyTask() запущен.");

            for (int count = 0; count < 5; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine("В методе MyTask(), счетчик равен: " + count);
            }

            Console.WriteLine("MyTask() завершен.");
        }

        static void Main()
        {
            Console.WriteLine("Основной поток запущен.");

            // Создание экземпляра задачи.
            var action = new Action(MyTask);
            var task = new Task(action);

            // Создание продолжения задачи.
            Task taskContinuation = task.ContinueWith(myT =>
            {
                Console.WriteLine("Продолжение запущено.");
                for (int count = 0; count < 5; count++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("В продолжении, счетчик равен: " + count);
                }
                Console.WriteLine("Продолжение завершено.");
            });

            // Выполнение последовательности задач.
            task.Start();

            // Ожидание завершения продолжения. 
            taskContinuation.Wait();
            task.Dispose();
            taskContinuation.Dispose();

            Console.WriteLine("Основной поток завершен.");

            // Delay.
            Console.ReadKey();
        }
    }
}
