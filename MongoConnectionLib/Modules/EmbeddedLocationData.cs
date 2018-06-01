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
        [BsonId]
        public ObjectId ID { get; set; }
        [BsonElement("Expires_At")]
        public DateTime ExpiresAt { get; set; }
        [BsonElement("latitude")]
        public double Latitude { get; set; }
        [BsonElement("longitude")]
        public double Longitude { get; set; }
        [BsonElement("location_image")]
        public ImageLocationData ImageLocation { get; set; }
        [BsonElement("view_restrictions")]
        public List<ObjectId> ViewRestrictions { get; set; }
    }
}
