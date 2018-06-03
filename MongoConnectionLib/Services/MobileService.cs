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
        #region Reads
        public List<ObjectId> RetrieveAllDocumentIds<DocumentType>()
        {
            FilterDefinition<DocumentType> filter = Builders<DocumentType>.Filter.Empty;
            ProjectionDefinition<DocumentType> projection = Builders<DocumentType>.Projection.Include("_id");
            return connectionManager.RetrieveCollection<DocumentType>().Find(filter).Project(projection).ToList().Select(idDoc => idDoc[0].AsObjectId).ToList();
        }
        public DocumentType RetrieveOneDocument<DocumentType>(ObjectId documentId)
        {
            return connectionManager.RetrieveCollection<DocumentType>().Find(Builders<DocumentType>.Filter.Eq("_id", documentId)).First();
        }
        #endregion

        #region Inserts
        public void Insert<DocumentType>(DocumentType document)
        {
            connectionManager.RetrieveCollection<DocumentType>().InsertOne(document);
        }
        #endregion

        #region Updates
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
            connectionManager.RetrieveCollection<DocumentType>().UpdateOne(filter, update);
        }

        public void AppendNewDataItem(Locations parentDocument, EmbeddedLocationData newData)
        {
            FilterDefinition<Locations> filter = Builders<Locations>.Filter.Eq("_id", parentDocument.ID);
            UpdateDefinition<Locations> update = Builders<Locations>.Update.Push("locations", newData);
            connectionManager.RetrieveCollection<Locations>().UpdateOne(filter, update);
        }
        public void AppendNewDataItem(Messages parentDocument, ImageMessageEmbedded newData)
        {
            FilterDefinition<Messages> filter = Builders<Messages>.Filter.Eq("_id", parentDocument.ID);
            UpdateDefinition<Messages> update = Builders<Messages>.Update.Push("image_message", newData);
            connectionManager.RetrieveCollection<Messages>().UpdateOne(filter, update);
        }
        public void AppendNewDataItem(Messages parentDocument, TextedMessageEmbedded newData)
        {
            FilterDefinition<Messages> filter = Builders<Messages>.Filter.Eq("_id", parentDocument.ID);
            UpdateDefinition<Messages> update = Builders<Messages>.Update.Push("texted_messages", newData);
            connectionManager.RetrieveCollection<Messages>().UpdateOne(filter, update);
        }
        public void AppendNewDataItem(Profile parentDocument, ImageLocationData newData)
        {
            FilterDefinition<Profile> filter = Builders<Profile>.Filter.Eq("_id", parentDocument.ID);
            UpdateDefinition<Profile> update = Builders<Profile>.Update.Push("profile_stored_images", newData);
            connectionManager.RetrieveCollection<Profile>().UpdateOne(filter, update);
        }
        public void AppendNewDataItem(Images parentDocument, EmbeddedImageData newData)
        {
            FilterDefinition<Images> filter = Builders<Images>.Filter.Eq("_id", parentDocument.ID);
            UpdateDefinition<Images> update = Builders<Images>.Update.Push("image", newData);
            connectionManager.RetrieveCollection<Images>().UpdateOne(filter, update);
        }
        public void AppendNewDataItem(Images parentDocument, ObjectId imageDataId, ObjectId newData)
        {
            FilterDefinitionBuilder<Images> filterBuilder = Builders<Images>.Filter;
            FilterDefinition<Images> filter = filterBuilder.And(filterBuilder.Eq("_id", parentDocument.ID), filterBuilder.Eq("image._id", imageDataId));
            UpdateDefinition<Images> update = Builders<Images>.Update.Push(document => document.ImageData[-1].ViewRestrictions, newData);
            connectionManager.RetrieveCollection<Images>().FindOneAndUpdate(filter, update);
        }
        public void AppendNewDataItem(Locations parentDocument, ObjectId locationDataId, ObjectId newData)
        {
            FilterDefinitionBuilder<Locations> filterBuilder = Builders<Locations>.Filter;
            FilterDefinition<Locations> filter = filterBuilder.And(filterBuilder.Eq("_id", parentDocument.ID), filterBuilder.Eq("locations._id", locationDataId));
            UpdateDefinition<Locations> update = Builders<Locations>.Update.Push(document => document.LocationData[-1].ViewRestrictions, newData);
            connectionManager.RetrieveCollection<Locations>().FindOneAndUpdate(filter, update);
        }
        public void AppendNewDataItem(Friends parentDocument, ObjectId newData, string propertyName)
        {
            FilterDefinition<Friends> filter = Builders<Friends>.Filter.Eq("_id", parentDocument.ID);
            UpdateDefinition<Friends> update = Builders<Friends>.Update.Push(propertyName, newData);
            connectionManager.RetrieveCollection<Friends>().FindOneAndUpdate(filter, update);
        }

        public void UpdateOneEmbeddedData(Locations parentDocument, EmbeddedLocationData updatedData)
        {
            FilterDefinitionBuilder<Locations> filterBuilder = Builders<Locations>.Filter;
            FilterDefinition<Locations> filter = filterBuilder.And(filterBuilder.Eq("_id", parentDocument.ID), filterBuilder.Eq("locations._id", updatedData.ID));
            UpdateDefinition<Locations> update = Builders<Locations>.Update.Set(document => document.LocationData[-1], updatedData);
            connectionManager.RetrieveCollection<Locations>().FindOneAndUpdate(filter, update);
        }
        public void UpdateOneEmbeddedData(Messages parentDocument, ImageMessageEmbedded updatedData)
        {
            FilterDefinitionBuilder<Messages> filterBuilder = Builders<Messages>.Filter;
            FilterDefinition<Messages> filter = filterBuilder.And(filterBuilder.Eq("_id", parentDocument.ID), filterBuilder.Eq("image_message._id", updatedData.ID));
            UpdateDefinition<Messages> update = Builders<Messages>.Update.Set(document => document.SentImages[-1], updatedData);
            connectionManager.RetrieveCollection<Messages>().FindOneAndUpdate(filter, update);
        }
        public void UpdateOneEmbeddedData(Messages parentDocument, TextedMessageEmbedded updatedData)
        {
            FilterDefinitionBuilder<Messages> filterBuilder = Builders<Messages>.Filter;
            FilterDefinition<Messages> filter = filterBuilder.And(filterBuilder.Eq("_id", parentDocument.ID), filterBuilder.Eq("texted_messages._id", updatedData.ID));
            UpdateDefinition<Messages> update = Builders<Messages>.Update.Set(document => document.SentMessages[-1], updatedData);
            connectionManager.RetrieveCollection<Messages>().FindOneAndUpdate(filter, update);
        }
        public void UpdateOneEmbeddedData(Profile parentDocument, ImageLocationData updatedData)
        {
            FilterDefinitionBuilder<Profile> filterBuilder = Builders<Profile>.Filter;
            FilterDefinition<Profile> filter = filterBuilder.And(filterBuilder.Eq("_id", parentDocument.ID), filterBuilder.Eq("profile_stored_images._id", updatedData.ID));
            UpdateDefinition<Profile> update = Builders<Profile>.Update.Set(document => document.ProfileImageList[-1], updatedData);
            connectionManager.RetrieveCollection<Profile>().FindOneAndUpdate(filter, update);
        }
        public void UpdateOneEmbeddedData(Images parentDocument, EmbeddedImageData updatedData)
        {
            FilterDefinitionBuilder<Images> filterBuilder = Builders<Images>.Filter;
            FilterDefinition<Images> filter = filterBuilder.And(filterBuilder.Eq("_id", parentDocument.ID), filterBuilder.Eq("image._id", updatedData.ID));
            UpdateDefinition<Images> update = Builders<Images>.Update.Set(document => document.ImageData[-1], updatedData);
            connectionManager.RetrieveCollection<Images>().FindOneAndUpdate(filter, update);
        }
        public void UpdateOneEmbeddedData(Locations parentDocument, ObjectId locationDataId, ImageLocationData updateData)
        {
            FilterDefinitionBuilder<Locations> filterBuilder = Builders<Locations>.Filter;
            FilterDefinition<Locations> filter = filterBuilder.And(filterBuilder.Eq("_id", parentDocument.ID), filterBuilder.Eq("locations._id", locationDataId));
            UpdateDefinition<Locations> update = Builders<Locations>.Update.Set(document => document.LocationData[-1].ImageLocation, updateData);
            connectionManager.RetrieveCollection<Locations>().FindOneAndUpdate(filter, update);
        }
        public void UpdateOneEmbeddedData(Messages parentDocument, ObjectId imageMessageId, ImageLocationData updateData)
        {
            FilterDefinitionBuilder<Messages> filterBuilder = Builders<Messages>.Filter;
            FilterDefinition<Messages> filter = filterBuilder.And(filterBuilder.Eq("_id", parentDocument.ID), filterBuilder.Eq("image_message._id", imageMessageId));
            UpdateDefinition<Messages> update = Builders<Messages>.Update.Set(document => document.SentImages[-1].ImageLocation, updateData);
            connectionManager.RetrieveCollection<Messages>().FindOneAndUpdate(filter, update);
        }
        #endregion

        #region Deletes
        public void DeleteFullDocument<DocumentType>(ObjectId documentId)
        {
            FilterDefinition<DocumentType> filter = Builders<DocumentType>.Filter.Eq("_id", documentId);
            connectionManager.RetrieveCollection<DocumentType>().DeleteOne(filter);
        }
        public void DeleteEmbeddedDocument(Locations parentDocument, EmbeddedLocationData deleteData)
        {
            FilterDefinitionBuilder<Locations> filterBuilder = Builders<Locations>.Filter;
            FilterDefinition<Locations> filter = filterBuilder.And(filterBuilder.Eq("_id", parentDocument.ID), filterBuilder.Eq("locations._id", deleteData.ID));
            UpdateDefinition<Locations> update = Builders<Locations>.Update.PullFilter("LocationData", Builders<EmbeddedLocationData>.Filter.Eq("_id", deleteData.ID));
            connectionManager.RetrieveCollection<Locations>().FindOneAndUpdate(filter, update);
        }
        public void DeleteEmbeddedDocument(Messages parentDocument, ImageMessageEmbedded deleteData)
        {
            FilterDefinitionBuilder<Messages> filterBuilder = Builders<Messages>.Filter;
            FilterDefinition<Messages> filter = filterBuilder.And(filterBuilder.Eq("_id", parentDocument.ID), filterBuilder.Eq("image_message._id", deleteData.ID));
            UpdateDefinition<Messages> update = Builders<Messages>.Update.PullFilter("SentImages", Builders<ImageMessageEmbedded>.Filter.Eq("_id", deleteData.ID));
            connectionManager.RetrieveCollection<Messages>().FindOneAndUpdate(filter, update);
        }
        public void DeleteEmbeddedDocument(Messages parentDocument, TextedMessageEmbedded deleteData)
        {
            FilterDefinitionBuilder<Messages> filterBuilder = Builders<Messages>.Filter;
            FilterDefinition<Messages> filter = filterBuilder.And(filterBuilder.Eq("_id", parentDocument.ID), filterBuilder.Eq("texted_messages._id", deleteData.ID));
            UpdateDefinition<Messages> update = Builders<Messages>.Update.PullFilter("SentMessages", Builders<TextedMessageEmbedded>.Filter.Eq("_id", deleteData.ID));
            connectionManager.RetrieveCollection<Messages>().FindOneAndUpdate(filter, update);
        }
        public void DeleteEmbeddedDocument(Profile parentDocument, ImageLocationData deleteData)
        {
            FilterDefinitionBuilder<Profile> filterBuilder = Builders<Profile>.Filter;
            FilterDefinition<Profile> filter = filterBuilder.And(filterBuilder.Eq("_id", parentDocument.ID), filterBuilder.Eq("profile_stored_images._id", deleteData.ID));
            UpdateDefinition<Profile> update = Builders<Profile>.Update.PullFilter("ProfileImageList", Builders<ImageLocationData>.Filter.Eq("_id", deleteData.ID));
            connectionManager.RetrieveCollection<Profile>().FindOneAndUpdate(filter, update);
        }
        public void DeleteEmbeddedDocument(Images parentDocument, EmbeddedImageData deleteData)
        {
            FilterDefinitionBuilder<Images> filterBuilder = Builders<Images>.Filter;
            FilterDefinition<Images> filter = filterBuilder.And(filterBuilder.Eq("_id", parentDocument.ID), filterBuilder.Eq("image._id", deleteData.ID));
            UpdateDefinition<Images> update = Builders<Images>.Update.PullFilter("Image", Builders<EmbeddedImageData>.Filter.Eq("_id", deleteData.ID));
            connectionManager.RetrieveCollection<Images>().FindOneAndUpdate(filter, update);
        }
        public void DeleteEmbeddedDocument(Images parentDocument, ObjectId imageDataId, ObjectId deleteData)
        {
            FilterDefinitionBuilder<Images> filterBuilder = Builders<Images>.Filter;
            FilterDefinition<Images> filter = filterBuilder.And(filterBuilder.Eq("_id", parentDocument.ID), filterBuilder.Eq("image._id", imageDataId));
            UpdateDefinition<Images> update = Builders<Images>.Update.Pull(document => document.ImageData[-1].ViewRestrictions, deleteData);
            connectionManager.RetrieveCollection<Images>().FindOneAndUpdate(filter, update);
        }
        public void DeleteEmbeddedDocument(Locations parentDocument, ObjectId locationDataId, ObjectId deleteData)
        {
            FilterDefinitionBuilder<Locations> filterBuilder = Builders<Locations>.Filter;
            FilterDefinition<Locations> filter = filterBuilder.And(filterBuilder.Eq("_id", parentDocument.ID), filterBuilder.Eq("locations._id", locationDataId));
            UpdateDefinition<Locations> update = Builders<Locations>.Update.Pull(document => document.LocationData[-1].ViewRestrictions, deleteData);
            connectionManager.RetrieveCollection<Locations>().FindOneAndUpdate(filter, update);
        }
        public void DeleteEmbeddedDocument(Friends parentDocument, ObjectId deleteData, string propertyName)
        {
            FilterDefinition<Friends> filter = Builders<Friends>.Filter.Eq("_id", parentDocument.ID);
            UpdateDefinition<Friends> update = Builders<Friends>.Update.Pull(propertyName, deleteData);
            connectionManager.RetrieveCollection<Friends>().FindOneAndUpdate(filter, update);
        }
        public void DeleteEmbeddedDocument(Locations parentDocument, ObjectId locationDataId, ImageLocationData deleteData)
        {
            FilterDefinitionBuilder<Locations> filterBuilder = Builders<Locations>.Filter;
            FilterDefinition<Locations> filter = filterBuilder.And(filterBuilder.Eq("_id", parentDocument.ID), filterBuilder.Eq("locations._id", locationDataId));
            UpdateDefinition<Locations> update = Builders<Locations>.Update.Set(document => document.LocationData[-1].ImageLocation, null);
            connectionManager.RetrieveCollection<Locations>().FindOneAndUpdate(filter, update);
        }
        public void DeleteEmbeddedDocument(Messages parentDocument, ObjectId imageMessageId, ImageLocationData deleteData)
        {
            FilterDefinitionBuilder<Messages> filterBuilder = Builders<Messages>.Filter;
            FilterDefinition<Messages> filter = filterBuilder.And(filterBuilder.Eq("_id", parentDocument.ID), filterBuilder.Eq("image_message._id", imageMessageId));
            UpdateDefinition<Messages> update = Builders<Messages>.Update.Set(document => document.SentImages[-1].ImageLocation, null);
            connectionManager.RetrieveCollection<Messages>().FindOneAndUpdate(filter, update);
        }
        #endregion
    }
}
