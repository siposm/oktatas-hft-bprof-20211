using System;
using System.Threading;

namespace _04interlocked
{
    class Program
    {
        static int sum = 0;
        static object lockObject = new object();

        static void Main(string[] args)
        {
            Thread th01 = new Thread(Count);
            Thread th02 = new Thread(Count);

            th01.Start();
            th02.Start();

            th01.Join();
            th02.Join();

            Console.WriteLine("Sum: " + sum);

        }

        static void Count()
        {
            for (int i = 0; i < 50000; i++)
                Interlocked.Increment(ref sum); //sum = sum + 1;

            // lock (lockObject)
            // {
            //     for (int i = 0; i < 50000; i++)
            //         sum = sum + 1;
            // }
        }

    }
}
