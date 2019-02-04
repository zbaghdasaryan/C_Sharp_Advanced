using System;
using System.Threading;
using System.Threading.Tasks;

// Применение методов ожидания - WaitAll() и WaitAny().

// WaitAll() - Ожидает завершения выполнения всех указанных объектов Task.
// WaitAny() - Ожидает завершения выполнения любого из указанных объектов Task.

namespace TPL
{
    class Program
    {
        // Метод который будет выполнен как задача.
        static void MyTask()
        {
            Console.WriteLine("MyTask() # " + Task.CurrentId + " запущен.");

            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine("В методе MyTask() #" + Task.CurrentId + " счетчик равен: " + count);
            }

            Console.WriteLine("MyTask() # " + Task.CurrentId + " завершен.");
        }

        static void Main()
        {
            Console.WriteLine("Основной поток запущен.");

            var task1 = new Task(MyTask);
            var task2 = new Task(MyTask);

            // Выполнение задач.
            task1.Start();
            task2.Start();

            Console.WriteLine("Идентификатор задачи task1: " + task1.Id);
            Console.WriteLine("Идентификатор задачи task2: " + task2.Id);

            //Task.WaitAll(task1, task2);
            Task.WaitAny(task1, task2);

            Console.WriteLine("Основной поток завершен.");

            // Delay.
            Console.ReadKey();
        }
    }
}
