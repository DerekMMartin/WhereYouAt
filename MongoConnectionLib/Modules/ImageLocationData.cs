using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConnectionLib.Modules
{
    public class ImageLocationData
    {
        [BsonElement("image_location")]
        public ObjectId ImageLocation { get; set; }
        [BsonElement("image_id")]
        public string ImageId { get; set; }
    }
}
