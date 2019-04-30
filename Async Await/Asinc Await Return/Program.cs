using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Async_Await_Return
{
    
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            Task<int> task = myClass.OperationAsinc();
            task.ContinueWith(t => Console.WriteLine("rezult {0}", task.Result));

            Console.ReadKey();
        }
    }
}

