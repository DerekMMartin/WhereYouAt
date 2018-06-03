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
    /// This is how images are being stored in the database.
    /// </summary>
    public class EmbeddedImageData
    {
        /// <summary>
        /// This is the mongo equivalent of _id and needs to be setup upon creation.
        /// </summary>
        [BsonId]
        public ObjectId ID { get; set; }
        /// <summary>
        /// This is the date when this data is no longer viable.
        /// </summary>
        [BsonElement("expires_at")]
        public DateTime ExpiresAt { get; set; }
        /// <summary>
        /// This is the btye[] of the image that is being stored.
        /// </summary>
        [BsonElement("image")]
        public byte[] Image { get; set; }
        /// <summary>
        /// This is the list of Profile document ID's of the people allowed to see it.
        /// </summary>
        [BsonElement("view_restrictions")]
        public List<ObjectId> ViewRestrictions { get; set; }
    }
}
