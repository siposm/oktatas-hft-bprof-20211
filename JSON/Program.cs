using System;
using System.Collections.Generic;
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
            return $"{ID} - {Name} - {BirthYear} - {Image}";
        }
    }

    class Program
    {
        static void LoadJSON()
        {
            string s = "http://users.nik.uni-obuda.hu/siposm/db/players_v2.json";
            WebClient wc = new WebClient();
            string jsonContent = wc.DownloadString(s);
            JsonConvert.DeserializeObject<List<Profile>>(jsonContent)
            .ForEach( x => Console.WriteLine(x) );
        }

        static void Main(string[] args)
        {
            Console.WriteLine("== JSON LOADER APP ==");

            LoadJSON();
        }
    }
}
