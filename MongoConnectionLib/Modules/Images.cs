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
        [BsonElement("user", Order = 1)]
        public ObjectId UserId { get; set; }
        [BsonElement("image", Order = 2)]
        public List<EmbeddedImageData> Image { get; set; }
    }
}
