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
        [BsonElement("user", Order = 1)]
        public ObjectId UserId { get; set; }
        [BsonElement("profile_name", Order = 2)]
        public string ProfileName { get; set; }
        [BsonElement("profile_image", Order = 3)]
        public ImageLocationData ProfileImage { get; set; }
        [BsonElement("profile_stored_images", Order = 4)]
        public List<ImageLocationData> ProfileImageList { get; set; }
    }
}
