using System;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
    class Program
    {
        // Метод который будет выполнен как задача.
        static void MyTask()
        {
            Console.WriteLine("MyTask() запущен.");

            for (int count = 0; count < 20; count++)
            {
                Thread.Sleep(1500);
                Console.WriteLine("В методе MyTask(), счетчик равен: " + count);
            }

            Console.WriteLine("MyTask() завершен.");
        }

        static void Main()
        {
            Console.WriteLine("Основной поток запущен.");

            var action = new Action(MyTask);

            // Создание экземпляра задачи.
            var task = new Task(action);

            // Выполнение задачи.
            task.Start();

            // Метод Main() остается активным до завершения задачи MyTask(). 
            for (int i = 0; i < 60; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            Console.WriteLine("Основной поток завершен.");

            // Delay.
            //Console.ReadKey();
        }
    }
}
