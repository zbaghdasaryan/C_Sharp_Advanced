using System;
using System.Threading;
using System.Threading.Tasks;

// Применение класса TaskFactory для создания и запуска задачи.

namespace TPL
{
    class Program
    {
        // Метод который будет выполнен как задача.
        static void MyTask()
        {
            Console.WriteLine("MyTask() запущен.");

            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine("В методе MyTask(), счетчик равен: " + count);
            }

            Console.WriteLine("MyTask() завершен.");
        }

        static void Main()
        {
            Console.WriteLine("Основной поток запущен.");

            // Создание экземпляра задачи с использованием свойства Factory, типа TaskFactory.
            Task task = Task.Factory.StartNew(MyTask);

            // В случае запуска задачи через TaskFactory, вызов метода task.Start() не требуется.
            //task.Start();

            // Метод Main() остается активным до завершения задачиMyTask(). 
            for (int i = 0; i < 60; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            Console.WriteLine("Основной поток завершен.");

            // Delay.
            Console.ReadKey();
        }
    }
}
