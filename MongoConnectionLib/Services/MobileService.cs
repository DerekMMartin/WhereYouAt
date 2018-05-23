using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConnectionLib.Services
{
    public class MobileService
    {
        private readonly MongoConnectionManager connectionManager;
        public MobileService()
        {
            connectionManager = new MongoConnectionManager();
        }
        public void Insert<DocumentType>(DocumentType document)
        {
            connectionManager.RetriveCollection<DocumentType>().InsertOne(document);
        }
        public void Delete<DocumentType>(ObjectId id)
        {
            connectionManager.RetriveCollection<DocumentType>().DeleteOne(Builders<DocumentType>.Filter.Eq("_id", id));
        }
        public DocumentType RetrieveOneDocument<DocumentType>(ObjectId id)
        {
            return connectionManager.RetriveCollection<DocumentType>().Find(Builders<DocumentType>.Filter.Eq("_id", id)).First();
        }
        public List<DocumentType> RetrieveAllDocuments<DocumentType>()
        {
            return connectionManager.RetriveCollection<DocumentType>().Find(Builders<DocumentType>.Filter.Empty).ToList();
        }
        public void Update<DocumentType>(DocumentType document)
        {
            BsonDocument localDocument = document.ToBsonDocument();

            IMongoCollection<DocumentType> collection = connectionManager.RetriveCollection<DocumentType>();

            FilterDefinition<DocumentType> filter = Builders<DocumentType>.Filter.Eq("_id", localDocument["_id"]);

            UpdateDefinition<DocumentType> update;
            List<UpdateDefinition<DocumentType>> updateDefinitions = new List<UpdateDefinition<DocumentType>>();
            UpdateDefinitionBuilder<DocumentType> updateBuilder = Builders<DocumentType>.Update;

            List<string> names = localDocument.Names.ToList();
            for (int bsonNameIndex = 1; bsonNameIndex < names.Count; bsonNameIndex++)
            {
                updateDefinitions.Add(updateBuilder.Set(names[bsonNameIndex], localDocument[names[bsonNameIndex]]));
            }
            update = updateBuilder.Combine(updateDefinitions);
            collection.UpdateOne(filter, update);
        }
    }
}
