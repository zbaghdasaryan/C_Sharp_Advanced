using System;
using System.Threading;
using System.Threading.Tasks;

// Отмена задачи с использованием опроса. (Пример выполнять через CTRL+F5)

namespace TPL
{
    class Program
    {
        // Метод который будет выполнен как задача.
        static void MyTask(object ct)
        {
            var cancelTok = (CancellationToken)ct;

            // Прверить, отменена ли задача, прежде чем ее запускать.
            cancelTok.ThrowIfCancellationRequested();

            Console.WriteLine("MyTask() запущен.");

            for (int count = 0; count < 10; count++)
            {
                // Для отслеживая отмены задачи применяется опрос.
                if (cancelTok.IsCancellationRequested)
                {
                    Console.WriteLine("Получен запрос на отмену задачи.");
                    cancelTok.ThrowIfCancellationRequested();
                }

                Thread.Sleep(500);
                Console.WriteLine("В методе MyTask(), счетчик равен: " + count);
            }

            Console.WriteLine("MyTask() завершен.");
        }



        static void Main()
        {
            Console.WriteLine("Основной поток запущен.");

            // Создать объект источника признаков отмены.
            var cancelTokSrc = new CancellationTokenSource();

            // Запустить задачу, передав признак отмены ей самой и делегату.
            Task task = Task.Factory.StartNew(MyTask, cancelTokSrc.Token, cancelTokSrc.Token);

            // Дать задаче возможность исполняться вплоть до ее отмены.
            Thread.Sleep(2000);

            try
            {
                // Отменить задачу.
                cancelTokSrc.Cancel();

                // Приостановить выполнение метода Main() до тех пор, 
                // пока не завершится задача - task.
                task.Wait();
            }
            catch (AggregateException e)
            {
                if (task.IsCanceled)
                    Console.WriteLine("\nЗадача task отменена.\n");

                Console.WriteLine("- " + e.InnerException.Message); // Для просмотра исключения снять комментарий.
            }
            finally
            {
                task.Dispose();
                cancelTokSrc.Dispose();
            }

            Console.WriteLine("Основной поток завершен.");

            // Delay.
            Console.ReadKey();
        }
    }
}
