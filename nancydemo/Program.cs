using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nancy;
using Newtonsoft.Json;

namespace nancydemo
{

    class Worker
    {
        /*  "name": "John Doe",
            "age": 35,
            "job": "Full-stack web developer",
            "salary": 4000,
            "img": "https://randomuser.me/api/portraits/men/65.jpg" */

        public string Name {get;set;}

        public int Age {get;set;}

        public string Job {get;set;}

        public int Salary {get;set;}

        public string Img {get;set;}

        public override string ToString()
        {
            return $"{Name} - {Age} - {Job} - {Salary} usd - {Img}";
        }
    }

    public class SampleModule : Nancy.NancyModule
    {
        // Get["/"] = _ => "Hello World!";
        /* Ie. The magic custom indexer syntax that allowed you to do this:
                Get["/"] = ...
                Is gone in the Nancy 2.x releases.
        */
        // src: https://stackoverflow.com/questions/39574057/cannot-apply-indexing-with-to-an-expression-of-type-method-groupsinglepage
            
        public SampleModule()
        {
            Get("/", _ => "Hello World!");
            
            Get("/hello", _ => "Hello there!");
            
            Get("/bye", _ => "Good bye!");
        }
    }


    public class WorkerModule : Nancy.NancyModule
    {
        public WorkerModule()
        {
            Get("/getAll", _ => 
            {
                WebClient wc = new WebClient();
                string jsonContent = wc.DownloadString("http://users.nik.uni-obuda.hu/siposm/api/endpoint.php");

                string ret = "";

                JsonConvert.DeserializeObject<List<Worker>>(jsonContent)
                            .ForEach( x => ret += x + "\n" );

                return ret;
            });

            Get("/getByAge/{age:int}", parameters => {

                WebClient wc = new WebClient();
                string jsonContent = wc.DownloadString("http://users.nik.uni-obuda.hu/siposm/api/endpoint.php");

                var workers = JsonConvert.DeserializeObject<List<Worker>>(jsonContent);

                var selected = from x in workers
                                where x.Age.Equals(parameters.age)
                                select x;

                var response = (Response)JsonConvert.SerializeObject(selected);
                response.ContentType = "application/json";

                return response;
            });
        }
    }


    public class Program
    {
        /*
            CLI COMMANDS
            
            dotnet new web

            dotnet add package Microsoft.AspNetCore.Owin
            dotnet add package Microsoft.AspNetCore.Server.Kestrel

            dotnet add package Newtonsoft.Json
        */
        
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseContentRoot(Directory.GetCurrentDirectory())
                        .UseKestrel(o => o.AllowSynchronousIO = true)
                        .UseStartup<Startup>();
                });

    }
}
