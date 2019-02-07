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
            Console.WriteLine("операция выполняется в потоке  {0}", Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(2000);
            return 2 * 2;
        }

        public async void OperationAsinc()
        {
           
            Task<int> task = Task<int>.Factory.StartNew(Operation);
            Console.WriteLine("\nрезультат  {0}", await task);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            myClass.OperationAsinc();
            Console.WriteLine("первичный поток завершил работу {0}", Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
            
        }
    }
}
