using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Async_Await_Continuation
{
    class MyClass
    {
        void Operation()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Main Task  {0}", Thread.CurrentThread.ManagedThreadId);
        }

        public async Task OperationAsinc()
        {
            await Task.Factory.StartNew(Operation);
                    }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            Task task = myClass.OperationAsinc();
            task.ContinueWith(t => Console.WriteLine("\nContinuation task"));
           
            Console.ReadKey();

        }
    }
}
