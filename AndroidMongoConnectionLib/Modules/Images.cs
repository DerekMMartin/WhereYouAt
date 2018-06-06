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
    /// This is the class for how the Images collection is going to store documents
    /// </summary>
    public class Images
    {
        /// <summary>
        /// This is the mongo equivalent of _id and is automatically set upon creation.
        /// </summary>
        [BsonId]
        public ObjectId ID { get; set; }
        /// <summary>
        /// This is the Users.ID of this documents user.
        /// </summary>
        [BsonElement("user")]
        public ObjectId UserId { get; set; }
        /// <summary>
        /// This is the list of images stored in this document in EmbeddedImageData format.
        /// </summary>
        [BsonElement("image")]
        public List<EmbeddedImageData> ImageData { get; set; }
    }
}
