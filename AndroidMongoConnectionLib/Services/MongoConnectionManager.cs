using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConnectionLib.Services
{
    public class MongoConnectionManager
    {
        public IMongoClient Client { get; private set; }
        public IMongoDatabase Database { get; private set; }
        public MongoConnectionManager()
        {
            Client = new MongoClient(new MongoClientSettings
            {
                Server = new MongoServerAddress("104.42.172.104")
            });

            Database = Client.GetDatabase("WhereYouAt");
            //Database.DropCollection("locations"); 
            using (IAsyncCursor<string> cursor = Client.ListDatabaseNames())
            {
                while (cursor.MoveNext())
                {
                    foreach (var database in cursor.Current)
                    {
                        Console.WriteLine(database);
                    }
                }
            }
            Console.WriteLine();
            using (IAsyncCursor<BsonDocument> cursor = Database.ListCollections())
            {
                while (cursor.MoveNext())
                {
                    foreach (var doc in cursor.Current)
                    {
                        Console.WriteLine(doc["name"]);
                    }
                }
            }
            IMongoCollection<BsonDocument> collection = Database.GetCollection<BsonDocument>("Readme");
            foreach(BsonDocument doc in collection.Find(Builders<BsonDocument>.Filter.Empty).ToList())
            {
                foreach (string names in doc.Names)
                {
                    Console.WriteLine($"{names}: {doc[names]}");
                }
            }
        }
        public void ChangeConnection(string userName, string password)
        {
            Client = new MongoClient(new MongoClientSettings
            {
                Server = new MongoServerAddress("104.42.172.104"),
                Credential = MongoCredential.CreateMongoCRCredential("WhereYouAt", userName, password),
                ConnectTimeout = TimeSpan.FromSeconds(10)
            });
            Database = Client.GetDatabase("WhereYouAt");            
        }
        public void RunCommand<DocumentType>(DocumentType command)
        {
            Database.RunCommand<DocumentType>(command.ToBsonDocument());
        }
        public IMongoCollection<DocumentType> RetrieveCollection<DocumentType>()
        {
            return Database.GetCollection<DocumentType>(typeof(DocumentType).Name.ToLower());
        }
    }
}
