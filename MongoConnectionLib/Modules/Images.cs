using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConnectionLib.Modules
{
    public class Images
    {
        [BsonId]
        public ObjectId ID { get; set; }
        [BsonElement("expires_at")]
        public DateTime ExpiresAt { get; set; }
        [BsonElement("image")]
        public EmbeddedImageData Image { get; set; }
    }
}
