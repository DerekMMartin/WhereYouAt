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
        //private readonly MongoHelper<Mobile> mobileHelper;
        public MobileService()
        {
            connectionManager = new MongoConnectionManager();
        }
        public void Insert<DocumentType>(DocumentType document)
        {
            connectionManager.RetriveCollection<DocumentType>().InsertOne(document);
        }
        //public void Edit(Mobile mob)
        //{
        //    mobileHelper.Collection.Update(
        //        Query.EQ("_id", mob.MobileID),
        //        Update.Set("Name", mob.Name)
        //            .Set("Details", mob.Details));
        //}

        //public void Delete(ObjectId postId)
        //{
        //    mobileHelper.Collection.DeleteOne(Query.EQ("_id", postId));
        //}

        //public IList<Mobile> GetMobiles()
        //{
        //    return mobileHelper.Collection.FindAll().ToList();
        //}

        //public Mobile GetMobile(ObjectId id)
        //{
        //    var filter = new FilterDefinitionBuilder<BsonDocument>.Empty();
        //    var mob = mobileHelper.Collection.Find(filter);

        //    return mob;
        //}
    }
}
