using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace hft2jzh_parallel
{
    public class Pizza
    {
        public string Type { get; set; }
        public int Size { get; set; }
        public int PastaThickness { get; set; }
        public int NumberOfToppings { get; set; }
        public double Price { get; set; }
        public string FantasyName { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Task<long>[] tasks = new Task<long>[10];

            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new Task<long>(() =>
                {
                    WebClient wc = new WebClient();
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    string jsonC = wc.DownloadString("http://localhost:5000/GetPizzasBySize/30");
                    //JsonConvert.DeserializeObject<List<Pizza>>(jsonC); // additional works could be done
                    sw.Stop();
                    return sw.ElapsedMilliseconds;
                });

                tasks[i].RunSynchronously();
            }

            Task.WhenAll(tasks).ContinueWith(z =>
            {
                long sum = 0;
                System.Console.WriteLine("RUNS:");
                foreach (var item in tasks)
                {
                    System.Console.WriteLine(item.Result);
                    sum += item.Result;
                }
                System.Console.WriteLine();
                System.Console.WriteLine($"AVG DOWNLOAD TIME: {sum / tasks.Length}");

                Process.Start("firefox", "www.9gag.com"); // short form is enough
            });


            Console.ReadKey();
        }
    }
}
