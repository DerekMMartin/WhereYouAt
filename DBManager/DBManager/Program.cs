using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhereYouAt.models;

namespace DBManager
{
    class Program
    {
        static void Main(string[] args)
        {
            User s = new User(1,"Admin2");
            MongoClient Client = new MongoClient("mongodb://104.42.172.104:27017");
            Console.WriteLine(Client.Settings.ApplicationName);
            var db = Client.GetDatabase("WhereYouAt");
            var col = db.GetCollection<User>("Users");
            col.InsertOne(s);
            Console.WriteLine(db);

        }
    }
}
