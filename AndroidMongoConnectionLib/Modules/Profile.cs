using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConnectionLib.Modules
{
    /// <summary>
    /// This class is the document format of the Profile colection.
    /// </summary>
    public class Profile
    {
        /// <summary>
        /// This is the mongo equivalent of _id and is automatically set upon insertion into a collection.
        /// </summary>
        [BsonId]
        public ObjectId ID { get; set; }
        /// <summary>
        /// This is the Users.ID of this document's user.
        /// </summary>
        [BsonElement("user")]
        public ObjectId UserId { get; set; }
        /// <summary>
        /// This is the name that the user wants to be known as.
        /// </summary>
        [BsonElement("profile_name")]
        public string ProfileName { get; set; }
        /// <summary>
        /// This is the profile image that the user has set.
        /// </summary>
        [BsonElement("profile_image")]
        public ImageLocationData ProfileImage { get; set; }
        /// <summary>
        /// This is the list of images that te user has stored on their profile.
        /// </summary>
        [BsonElement("profile_stored_images", Order = 4)]
        public List<ImageLocationData> ProfileImageList { get; set; }
    }
}
