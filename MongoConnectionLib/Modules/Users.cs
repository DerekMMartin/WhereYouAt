using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConnectionLib.Modules
{
    public class Users
    {
        [BsonId]
        public ObjectId ID { get; set; }
        [BsonElement("username")]
        public string UserName { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
        [BsonElement("profile_id")]
        public ObjectId ProfileId { get; set; }
        [BsonElement("friend_id")]
        public ObjectId FriendId { get; set; }
        [BsonElement("message_id")]
        public ObjectId MessageId { get; set; }
        [BsonElement("image_id")]
        public ObjectId ImageId { get; set; }
    }
}
