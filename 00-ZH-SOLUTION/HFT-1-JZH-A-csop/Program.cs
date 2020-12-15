using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace javzh
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ToStringAttribute : Attribute { /* ... */ }

    public static class ConsoleLogger // place to separate DLL
    {
        public static void ConsoleLog(object o)
        {
            System.Console.WriteLine(o.ToString());
        }
    }

    public enum SizeUnitEnum
    {
        cm, inch
    }

    public interface IPizza
    {
        string Type { get; set; }
        int Size { get; set; }
        int PastaThickness { get; set; }
        int NumberOfToppings { get; set; }
        double Price { get; set; }
    }

    public class Pizza : IPizza
    {
        [ToString] public string FantasyName { get; set; }
        [ToString] public string Type { get; set; }
        [ToString] public int Size { get; set; }
        public int PastaThickness { get; set; }
        public int NumberOfToppings { get; set; }
        public double Price { get; set; }
        public SizeUnitEnum SizeUnit { get; set; }

        public override string ToString()
        {
            string x = "";
            foreach (var item in this.GetType().GetProperties().Where(x =>
               x.GetCustomAttribute<ToStringAttribute>() != null))
            {
                x += "   ";
                x += item.Name + "\t=> ";
                x += item.GetValue(this);
                x += "\n";
            }
            return x;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://users.nik.uni-obuda.hu/siposm/db/pizza-database.xml";
            Func<string, IEnumerable<Pizza>> processor = (url) =>
            {
                XDocument xdoc = XDocument.Load(url);
                List<Pizza> collection = new List<Pizza>();
                foreach (var item in xdoc.Root.Descendants("Pizza"))
                {
                    collection.Add(new Pizza()
                    {
                        FantasyName = item.Element("FantasyName").Value,
                        Type = item.Element("Type").Value + " (" + item.Element("Type").Attribute("base").Value + " base)",
                        Size = int.Parse(item.Element("Size").Value),
                        Price = int.Parse(item.Element("Price").Value)
                        // TODO additional properties...
                    });
                }

                return collection;
            };

            IEnumerable<Pizza> database = processor(url);

            foreach (var item in database)
                ConsoleLogger.ConsoleLog(item);

            var q1 = from x in database
                     group x by x.Size into g
                     select new
                     {
                         AVGSAL = g.Average(a => a.Price),
                         SIZE = g.Key
                     };

            foreach (var item in q1) System.Console.WriteLine(item);

            var q2 = from x in database
                     group x by x.Size into g
                     select new
                     {
                         TYPE = g.Key,
                         COUNT = g.Count()
                     };

            foreach (var item in q2) System.Console.WriteLine(item);

            // TODO q3
        }
    }
}
