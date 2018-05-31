using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConnectionLib.Modules
{
    public class Locations
    {
        [BsonId]
        public ObjectId ID { get; set; }
        [BsonElement("user")]
        public ObjectId UserId { get; set; }
        [BsonElement("locations")]
        public List<EmbeddedLocationData> LocationData { get; set; }
    }
}
