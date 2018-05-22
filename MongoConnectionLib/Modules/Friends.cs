using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConnectionLib.Modules
{
    public class Friends
    {
        [BsonId]
        public ObjectId ID { get; set; }
        [BsonElement("user")]
        public ObjectId UserId { get; set; }
        [BsonElement("friend_ids")]
        public List<ObjectId> FriendIds { get; set; }
        [BsonElement("pending_ids")]
        public List<ObjectId> PendingIds { get; set; }
        [BsonElement("blocked_ids")]
        public List<ObjectId> BlockedIds { get; set; }
    }
}
