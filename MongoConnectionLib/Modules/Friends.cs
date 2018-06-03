using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConnectionLib.Modules
{
    /// <summary>
    /// This is the document format for the Friends collection.
    /// </summary>
    public class Friends
    {
        ///// <summary>
        /// This is the mongo equivalent of _id and is automatically created upon insertion into the database.
        /// </summary>
        [BsonId]
        public ObjectId ID { get; set; }
        /// <summary>
        /// This is the ObjectId for the Users document for this document's user.
        /// </summary>
        [BsonElement("user")]
        public ObjectId UserId { get; set; }
        /// <summary>
        /// This is a list of the Profile documents ID of other users who are set as friends.
        /// </summary>
        [BsonElement("friend_ids")]
        public List<ObjectId> FriendIds { get; set; }
        /// <summary>
        /// This is a list of the Profile documents ID of other users who are pending friends.
        /// </summary>
        [BsonElement("pending_ids")]
        public List<ObjectId> PendingIds { get; set; }
        /// <summary>
        /// This is a list of the Profile documents ID of other users who are set as blocked. 
        /// </summary>
        [BsonElement("blocked_ids")]
        public List<ObjectId> BlockedIds { get; set; }
    }
}
