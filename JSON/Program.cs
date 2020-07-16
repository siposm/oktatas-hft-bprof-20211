using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace JSON
{
    class Profile
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int BirthYear { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }
        public int Connections { get; set; }

        public override string ToString()
        {
            return $"{ID} - {Name}";
        }
    }

    class Program
    {
        static List<Profile> Load()
        {
            string url = "https://users.nik.uni-obuda.hu/siposm/db/players_v2.json";
            WebClient wc = new WebClient();
            string content = wc.DownloadString(url);

            List<Profile> pList = JsonConvert.DeserializeObject<List<Profile>>(content);

            // var q = from x in pList
            //         where x.BirthYear > 1992
            //         select x;

            // foreach (var item in q)
            //     System.Console.WriteLine(item);

            return pList;
        }

        static void Save(Profile p)
        {
            string output = JsonConvert.SerializeObject(p);

            File.WriteAllText("my_output.json", output);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("== JSON APP ==");

            var q = Load();

            Save(q.ToList()[0]);
        }
    }
}
