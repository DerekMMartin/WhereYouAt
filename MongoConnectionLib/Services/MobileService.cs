using MongoConnectionLib.Modules;
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
        public void DeleteDocument<DocumentType>(ObjectId id)
        {
            connectionManager.RetriveCollection<DocumentType>().DeleteOne(Builders<DocumentType>.Filter.Eq("_id", id));
        }
        /// <summary>
        /// Returns a list of ID's that belong to a collection.
        /// </summary>
        /// <typeparam name="DocumentType">The serializable class that correlates to the collection being looked in.</typeparam>
        /// <returns>A List of all the ID's that are in the collection.</returns>
        public List<ObjectId> RetrieveAllDocumentIds<DocumentType>()
        {
            return (connectionManager.RetriveCollection<DocumentType>().Find(Builders<DocumentType>.Filter.Empty).Project(Builders<DocumentType>.Projection.Include("_id")).ToList()).Select(x => x[0].AsObjectId).ToList();
        }
        /// <summary>
        /// Retrieves on specific document. 
        /// </summary>
        /// <typeparam name="DocumentType">The document type that is being searched through.</typeparam>
        /// <param name="id">The ID of the specific document that you are want to retrieve.</param>
        /// <returns>A Bson Serializable class of the correct type and with the ID that you were looking for.</returns>
        public DocumentType RetrieveOneDocument<DocumentType>(ObjectId id)
        {
            return connectionManager.RetriveCollection<DocumentType>().Find(Builders<DocumentType>.Filter.Eq("_id", id)).First();
        }
        /// <summary>
        /// This is to retrieve all of a profile documents ProfileImageList ID's. 
        /// </summary>
        /// <param name="parentId">The profile documents ID.</param>
        /// <returns>A List of all the ImageLocationData ID's from ProfileImageList.</returns>
        public List<ObjectId> RetrieveAllImageLocationDataIDsFromProfile(ObjectId parentId)
        {
            return connectionManager.RetriveCollection<Profile>().Find(Builders<Profile>.Filter.Eq("_id", parentId)).First().ProfileImageList.Select(Data => Data.ID).ToList();
        }
        public List<ObjectId> RetrieveAllLocationDataIDsFromLocations(ObjectId parentId)
        {
            return connectionManager.RetriveCollection<Locations>().Find(Builders<Locations>.Filter.Eq("_id", parentId)).First().LocationData.Select(Data => Data.ID).ToList();
        }
        /// <summary>
        /// Retrieves one specific ImageLocationData from a profile's ProfileImageList.
        /// </summary>
        /// <param name="parentId">The profile that is being searched, ID.</param>
        /// <param name="childId">The ID of the specific ImageLocationData you are searching for.</param>
        /// <returns>The specific ImageLocationData.</returns>
        public ImageLocationData RetrieveOneImageLocationDataFromProfile(ObjectId parentId, ObjectId childId)
        {
            return connectionManager.RetriveCollection<Profile>().Find(Builders<Profile>.Filter.Eq("_id", parentId)).First().ProfileImageList.Where(data => data.ID == childId).First();
        }

        #region Updates
        /// <summary>
        /// Updates the specific document based on the input documents existing ID, though any document with embedded documentation do not inculde previously included
        /// embedded documentation update those seprately
        /// </summary>
        /// <typeparam name="DocumentType"></typeparam>
        /// <param name="document"></param>
        public void Update<DocumentType>(DocumentType document)
        {
            BsonDocument localDocument = document.ToBsonDocument();

            FilterDefinition<DocumentType> filter = Builders<DocumentType>.Filter.Eq("_id", localDocument["_id"]);

            UpdateDefinition<DocumentType> update;
            List<UpdateDefinition<DocumentType>> updateDefinitions = new List<UpdateDefinition<DocumentType>>();
            UpdateDefinitionBuilder<DocumentType> updateBuilder = Builders<DocumentType>.Update;

            List<string> names = localDocument.Names.ToList();
            for (int bsonNameIndex = 1; bsonNameIndex < names.Count; bsonNameIndex++)
            {
                if (localDocument[names[bsonNameIndex]].GetType() != typeof(BsonArray))
                {
                    updateDefinitions.Add(updateBuilder.Set(names[bsonNameIndex], localDocument[names[bsonNameIndex]]));
                }
            }
            update = updateBuilder.Combine(updateDefinitions);
            connectionManager.RetriveCollection<DocumentType>().UpdateOne(filter, update);
        }
        public void AppendNewDataItem(Profile parentDocument, ImageLocationData newData)
        {
            FilterDefinition<Profile> filter = Builders<Profile>.Filter.Eq("_id", parentDocument.ID);
            UpdateDefinition<Profile> update = Builders<Profile>.Update.Push("profile_stored_images", newData);
            connectionManager.RetriveCollection<Profile>().UpdateOne(filter, update);
        }
        public void AppendNewDataItem(Messages parentDocument, TextedMessageEmbedded newData)
        {
            FilterDefinition<Messages> filter = Builders<Messages>.Filter.Eq("_id", parentDocument.ID);
            UpdateDefinition<Messages> update = Builders<Messages>.Update.Push("texted_messages", newData);
            connectionManager.RetriveCollection<Messages>().UpdateOne(filter, update);
        }
        public void AppendNewDataItem(Messages parentDocument, ImageMessageEmbedded newData)
        {
            FilterDefinition<Messages> filter = Builders<Messages>.Filter.Eq("_id", parentDocument.ID);
            UpdateDefinition<Messages> update = Builders<Messages>.Update.Push("image_message", newData);
            connectionManager.RetriveCollection<Messages>().UpdateOne(filter, update);
        }
        public void AppendNewDataItem(Images parentDocument, EmbeddedImageData newData)
        {
            FilterDefinition<Images> filter = Builders<Images>.Filter.Eq("_id", parentDocument.ID);
            UpdateDefinition<Images> update = Builders<Images>.Update.Push("image", newData);
            connectionManager.RetriveCollection<Images>().UpdateOne(filter, update);
        }
        public void AppendNewDataItem(Locations parentDocument, EmbeddedLocationData newData)
        {
            FilterDefinition<Locations> filter = Builders<Locations>.Filter.Eq("_id", parentDocument.ID);
            UpdateDefinition< Locations> update = Builders<Locations>.Update.Push("locations", newData);
            connectionManager.RetriveCollection<Locations>().UpdateOne(filter, update);
        }
        public void UpdateOneEmbeddedData(Profile parentDocument, ImageLocationData updatedData)
        {
            FilterDefinitionBuilder<Profile> filterBuilder = Builders<Profile>.Filter;
            FilterDefinition<Profile> filter = filterBuilder.And(filterBuilder.Eq("_id", parentDocument.ID), filterBuilder.Eq("profile_stored_images._id", updatedData.ID));
            UpdateDefinition<Profile> update = Builders<Profile>.Update.Set(document => document.ProfileImageList[-1], updatedData);
            connectionManager.RetriveCollection<Profile>().FindOneAndUpdate(filter, update);
        }
        public void UpdateOneEmbeddedData(Messages parentDocument, TextedMessageEmbedded updatedData)
        {
            FilterDefinitionBuilder<Messages> filterBuilder = Builders<Messages>.Filter;
            FilterDefinition<Messages> filter = filterBuilder.And(filterBuilder.Eq("_id", parentDocument.ID), filterBuilder.Eq("texted_messages._id", updatedData.ID));
            UpdateDefinition<Messages> update = Builders<Messages>.Update.Set(document => document.SentMessages[-1], updatedData);
            connectionManager.RetriveCollection<Messages>().FindOneAndUpdate(filter, update);
        }
        public void UpdateOneEmbeddedData(Messages parentDocument, ImageMessageEmbedded updatedData)
        {
            FilterDefinitionBuilder<Messages> filterBuilder = Builders<Messages>.Filter;
            FilterDefinition<Messages> filter = filterBuilder.And(filterBuilder.Eq("_id", parentDocument.ID), filterBuilder.Eq("image_message._id", updatedData.ID));
            UpdateDefinition<Messages> update = Builders<Messages>.Update.Set(document => document.SentImages[-1], updatedData);
            connectionManager.RetriveCollection<Messages>().FindOneAndUpdate(filter, update);
        }
        public void UpdateOneEmbeddedData(Images parentDocument, EmbeddedImageData updatedData)
        {
            FilterDefinitionBuilder<Images> filterBuilder = Builders<Images>.Filter;
            FilterDefinition<Images> filter = filterBuilder.And(filterBuilder.Eq("_id", parentDocument.ID), filterBuilder.Eq("image._id", updatedData.ID));
            UpdateDefinition<Images> update = Builders<Images>.Update.Set(document => document.Image[-1], updatedData);
            connectionManager.RetriveCollection<Images>().FindOneAndUpdate(filter, update);
        }
        public void UpdateOneEmbeddedData(Locations parentDocument, EmbeddedLocationData updatedData)
        {
            FilterDefinitionBuilder<Locations> filterBuilder = Builders<Locations>.Filter;
            FilterDefinition<Locations> filter = filterBuilder.And(filterBuilder.Eq("_id", parentDocument.ID), filterBuilder.Eq("locations._id", updatedData.ID));
            UpdateDefinition<Locations> update = Builders<Locations>.Update.Set(document => document.LocationData[-1], updatedData);
            connectionManager.RetriveCollection<Locations>().FindOneAndUpdate(filter, update);
        }
        #endregion
    }
}
