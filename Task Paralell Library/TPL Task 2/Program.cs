using System;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
    class MyClass
    {
        // Метод который будет выполнен как задача.
        public void MyTask()
        {
            Console.WriteLine("MyTask() запущен.");

            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine("В методе MyTask(), счетчик равен: " + count);
            }

            Console.WriteLine("MyTask() завершен.");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Основной поток запущен.");

            MyClass my = new MyClass();

            //   var action = new Action(my.MyTask);

            // Создание экземпляра задачи.
            Task task = new Task(my.MyTask);

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
            Console.ReadKey();
        }
    }
}
