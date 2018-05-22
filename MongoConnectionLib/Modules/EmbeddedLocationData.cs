using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConnectionLib.Modules
{
    public class EmbeddedLocationData
    {
        [BsonElement("latitude")]
        public double Latitude { get; set; }
        [BsonElement("longitude")]
        public double Longitude { get; set; }
        [BsonElement("location_image")]
        public ImageLocationData LocationImage { get; set; }
        [BsonElement("restrictions")]
        public List<ObjectId> Restrictions { get; set; }
    }
}
