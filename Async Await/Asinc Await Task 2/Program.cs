using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Async_Await
{
    class MyClass
    {
        public void Operation()
        {
            Console.WriteLine("Operation Thread ID {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Begin");
            Thread.Sleep(2000);
            Console.WriteLine("End");
        }

        public async void OperationAsinc()
        {
            Console.WriteLine("OperationAsinc (Part 1) Thread ID {0}", Thread.CurrentThread.ManagedThreadId);
            Task task = new Task(Operation);
            task.Start();
            await task;
            Console.WriteLine("\nOperationAsinc (Part 2) Thread ID {0}", Thread.CurrentThread.ManagedThreadId);
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mail ThreadID {0}", Thread.CurrentThread.ManagedThreadId);
            MyClass myClass = new MyClass();
            myClass.OperationAsinc();
        }
    }
}
