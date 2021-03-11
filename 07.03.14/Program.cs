using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07._03._14
{
    class Program
    {
        public delegate void Signature_For_Function_Void_With_No_Parameters();
        public delegate int Signature_for_function_int_with_2int_parameters(int d1, int d2);
        public delegate void WaitCallback(object state);

        public static void Downloading ()
        {
            Console.WriteLine("Downloading...");
            Thread.Sleep(10000);
            Console.WriteLine("Completed");
        }
        public static int Multiply (int x, int y)
        {
            return x * y;
        }
        public static void PrintInvokeResult(Signature_for_function_int_with_2int_parameters f, int x, int y)
        {
            Thread thread = Thread.CurrentThread;
            int result =  f(x, y);
            Console.WriteLine(result);
        }



        static void Main(string[] args)
        {
           Thread t = new Thread (Downloading);
            t.Start();

            ThreadPool.QueueUserWorkItem((o) => { Console.WriteLine(Multiply(2,3)); }, null);
            //PrintInvokeResult(Multiply, 5, 5);
        }
    }
}
