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
            Task task = new Task(Operation);
                task.Start();
            await task;
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
