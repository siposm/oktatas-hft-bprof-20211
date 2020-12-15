using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nancy;
using Newtonsoft.Json;

namespace hft2jzh
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

    public class ExceptionClass
    {
        public string Message { get; set; }
    }

    public class SampleModule : Nancy.NancyModule
    {
        public SampleModule()
        {
            Get("/", _ => "Hello World!");

            Get("/GetPizzasBySize/{size:int}", parameter =>
            {
                List<Pizza> coll = new List<Pizza>();
                foreach (var item in XDocument.Load("https://users.nik.uni-obuda.hu/siposm/db/pizza-database.xml").Root.Descendants("Pizza"))
                {
                    if (parameter.size == 20 || parameter.size == 30 || parameter.size == 45)
                    {
                        if (int.Parse(item.Element("Size").Value) == parameter.size)
                        {
                            coll.Add(new Pizza()
                            {
                                FantasyName = item.Element("FantasyName").Value,
                                Size = int.Parse(item.Element("Size").Value),
                                Price = int.Parse(item.Element("Price").Value)
                            });
                        }
                    }
                    else
                    {
                        var errorResponse = (Response)JsonConvert.SerializeObject(new Exception("ERROR : Input parameter is not valid."));
                        //var errorResponse = (Response)JsonConvert.SerializeObject(new ExceptionClass() { Message = "ERROR : Input parameter is not valid." }); // alternatíva
                        errorResponse.ContentType = "application/json";
                        return errorResponse;
                    }
                }
                var response = (Response)JsonConvert.SerializeObject(coll);
                response.ContentType = "application/json";
                return response;
            });

            Get("/GetPizzasBetweenPrice/{from:int}/{to:int}", parameter =>
            {
                List<Pizza> coll = new List<Pizza>();
                foreach (var item in XDocument.Load("https://users.nik.uni-obuda.hu/siposm/db/pizza-database.xml").Root.Descendants("Pizza"))
                {
                    if (int.Parse(item.Element("Price").Value) < parameter.to &&
                        int.Parse(item.Element("Price").Value) > parameter.from)
                    {
                        coll.Add(new Pizza()
                        {
                            FantasyName = item.Element("FantasyName").Value,
                            Size = int.Parse(item.Element("Size").Value),
                            Price = int.Parse(item.Element("Price").Value)
                        });
                    }
                }
                var response = (Response)JsonConvert.SerializeObject(coll);
                response.ContentType = "application/json";
                return response;
            });
        }
    }


    public class Program
    {
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