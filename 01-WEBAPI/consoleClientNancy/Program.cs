using System;
using System.Net;
using Newtonsoft.Json;

namespace consoleClientNancy
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:5000/getByAge/27";
            WebClient wc = new WebClient();            
            string jsonContent = wc.DownloadString(url);

            System.Console.WriteLine(jsonContent);
            
        }
    }
}
