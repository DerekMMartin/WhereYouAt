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
        [BsonElement("user", Order = 1)]
        public ObjectId UserId { get; set; }
        [BsonElement("texted_messages", Order = 2)]
        public List<TextedMessageEmbedded> SentMessages { get; set; }
        [BsonElement("image_message", Order = 3)]
        public List<ImageMessageEmbedded> SentImages { get; set; }
    }
}
