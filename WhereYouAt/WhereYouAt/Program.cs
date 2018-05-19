//using System;
//using WhereYouAt.models;

//namespace DBManager
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            User s = new User(0, "Admin");
//            MongoClient Client = new MongoClient("mongodb://104.42.172.104:27017");
//            Console.WriteLine(Client.Settings.ApplicationName);
//            var db = Client.GetDatabase("WhereYouAt");
//            db.CreateCollection("Users");
//            var col = db.GetCollection<User>("Users");
//            col.InsertOne(s);
//            Console.WriteLine(db);

//        }
//    }
//}
