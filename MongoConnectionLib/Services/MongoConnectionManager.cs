using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.GridFS;
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
        }
        public IMongoCollection<DocumentType> RetriveCollection<DocumentType>()
        {
            return Database.GetCollection<DocumentType>(typeof(DocumentType).Name.ToLower());
        }
    }
}
