using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConnectionLib.Modules
{
    public class Profile
    {
        [BsonId]
        public ObjectId ID { get; set; }
        [BsonElement("user")]
        public ObjectId UserID { get; set; }
        [BsonElement("profile_name")]
        public string ProfileName { get; set; }
        [BsonElement("profile_image")]
        public ImageLocationData ProfileImage { get; set; }
        [BsonElement("profile_stored_images")]
        public List<ImageLocationData> ProfileImageList { get; set; }
    }
}
