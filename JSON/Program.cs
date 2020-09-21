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

    class Logic
    {
        private IRepo repository { get; set; }

        public Logic(IRepo repo)
        {
            this.repository = repo;
        }

        public List<Profile> ListProfiles()
        {
            return this.repository.GetAll();
        }

        public List<Profile> ListProfilesFrom(int param)
        {
            return this.repository.GetFrom(param);
        }

        public void SaveProfiles()
        {
            this.repository.SaveAll();
        }
    }

    interface IRepo<T>
    {
        List<T> GetAll();
        List<T> GetFrom(int param);
        void SaveAll();
    }

    class ProfileRepository : IRepo<Profile>
    {
        private List<Profile> DB { get; set; }

        public ProfileRepository()
        {
            this.DB = DataLoader.LoadJSON();
        }

        public List<Profile> GetAll()
        {
            return this.DB;
        }

        public List<Profile> GetFrom(int param)
        {
            return (from x in this.DB
                    where x.BirthYear > param
                    select x).ToList();
        }

        public void SaveAll()
        {
            var q = from x in this.DB
                    where x.BirthYear > 1992
                    select x;

            DataLoader.SaveJSON(q.ToList());
        }
    }

    static class DataLoader
    {
        public static List<Profile> LoadJSON()
        {
            string url = "https://users.nik.uni-obuda.hu/siposm/db/players_v2.json";
            WebClient wc = new WebClient();
            string jsonContent = wc.DownloadString(url);

            return JsonConvert.DeserializeObject<List<Profile>>(jsonContent);
        }

        public static void SaveJSON(List<Profile> plist)
        {
            string json = JsonConvert.SerializeObject(plist);
            File.WriteAllText("my_database_save.json" , json);
        }
    }
    

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("== JSON APP ==");

            Logic l = new Logic(new ProfileRepository());

            l.ListProfiles().ForEach( x => System.Console.WriteLine(x));

            System.Console.WriteLine("\n====\n");

            l.ListProfilesFrom(1992).ForEach( x => System.Console.WriteLine(x));

            l.SaveProfiles();
        }
    }
}
