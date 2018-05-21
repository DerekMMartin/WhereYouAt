using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConnectionLib.Modules
{
    public class Messages
    {
        [BsonId]
        public ObjectId ID { get; set; }
        [BsonElement("user")]
        public ObjectId UserId { get; set; }
        [BsonElement("texted_messages")]
        public List<TextedMessageEmbedded> SentMessages { get; set; }
        [BsonElement("image_message")]
        public List<TextedMessageEmbedded> SentImages { get; set; }
    }
}
