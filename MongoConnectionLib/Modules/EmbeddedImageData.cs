using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConnectionLib.Modules
{
    public class EmbeddedImageData
    {
        [BsonElement("image_id")]
        public string ImageId { get; set; }
        [BsonElement("image")]
        public byte[] Image { get; set; }
        [BsonElement("restrictions")]
        public List<ObjectId> Restrictions { get; set; }
    }
}
