using System;
using System.Threading;

namespace _03lock
{
    class Program
    {
        static int counter = 0;
        static object threadLocker = new object();

        static void IncrementVersion_1()
        {
            while (true)
            {
                counter = counter + 1;
                Console.WriteLine($"THREAD ID: {Thread.CurrentThread.ManagedThreadId} VALUE: {counter}");
                Thread.Sleep(250);
            }
        }

        static void IncrementVersion_2()
        {
            while (true)
            {
                int _localCounter = counter;
                Thread.Sleep(250);
                counter = _localCounter + 1;

                Console.WriteLine($"THREAD ID: {Thread.CurrentThread.ManagedThreadId} VALUE: {counter}");
                Thread.Sleep(250);
            }
        }

        static void IncrementVersion_3()
        {
            while (true)
            {
                lock ( threadLocker )
                {
                    int _localCounter = counter;
                    Thread.Sleep(250);
                    counter = _localCounter + 1;
                    Console.WriteLine($"THREAD ID: {Thread.CurrentThread.ManagedThreadId} VALUE: {counter}");
                }
                
                Thread.Sleep(250);
            }
        }

        static void Main(string[] args)
        {
            // Thread t1 = new Thread(IncrementVersion_1);
            // Thread t2 = new Thread(IncrementVersion_1);

            Thread t1 = new Thread(IncrementVersion_2);
            Thread t2 = new Thread(IncrementVersion_2);

            // Thread t1 = new Thread(IncrementVersion_3);
            // Thread t2 = new Thread(IncrementVersion_3);

            t1.Start();
            Thread.Sleep(300);
            t2.Start();



        }
    }
}
