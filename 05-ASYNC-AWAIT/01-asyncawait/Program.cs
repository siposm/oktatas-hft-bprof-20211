using System;
using System.Threading;
using System.Threading.Tasks;

namespace _07asyncawait
{
    class Worker
    {
        public bool IsComplete { get; private set; }

        public async void DoWork()
        {
            IsComplete = false;
            Console.WriteLine("\t... doing my work");
            await LongOperation();
            Console.WriteLine("\t... my work is done");
            IsComplete = true;
        }

        private Task LongOperation()
        {
            return Task.Factory.StartNew(() =>
            {
               Console.WriteLine("\t >> long operation is under progress...");
               Thread.Sleep(3000);
            });
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started...");

            var w = new Worker();
            w.DoWork();

            while (!w.IsComplete)
            {
                Console.Write(".");
                Thread.Sleep(250);
            }

            Console.WriteLine("Finished...");
            Console.ReadLine();

        }
    }
}
