using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Async_Await_Task_3
{
    class MyClass
    {
        int Operation()
        {
            Console.WriteLine("Operation Thread ID {0}", Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(2000);
            return 2 * 2;
        }

        public async void OperationAsinc()
        {
            Console.WriteLine("OperationAsinc (Part 1) Thread ID {0}", Thread.CurrentThread.ManagedThreadId);
            Task<int> task = Task<int>.Factory.StartNew(Operation);
            Console.WriteLine("\nresult {0}", await task);
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
