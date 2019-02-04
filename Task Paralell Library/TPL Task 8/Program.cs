using System;
using System.Threading;
using System.Threading.Tasks;

// Продолжение - автоматический запуск новой задачи, после завершения первой задачи.

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

        // Метод исполняемый как продолжение задачи.
        static void ContinuationTask(Task task)
        {
            Console.WriteLine("Продолжение запущено.");

            for (int count = 0; count < 5; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine("В продолжении, счетчик равен: " + count);
            }

            Console.WriteLine("Продолжение завершено.");
        }

        static void Main()
        {
            Console.WriteLine("Основной поток запущен.");

            // Создание экземпляра задачи.
            var action = new Action(MyTask);
            var task = new Task(action);

            // Создание продолжения задачи.
            var continuationAction = new Action<Task>(ContinuationTask);
            Task taskContinuation = task.ContinueWith(ContinuationTask);

            // Выполнение последовательности задач.
            task.Start();

            // Ожидание завершения продолжения. 
            taskContinuation.Wait();
            //task.Wait();
            task.Dispose();
            taskContinuation.Dispose();

            Console.WriteLine("Основной поток завершен.");

            // Delay.
            //Console.ReadKey();
        }
    }
}
