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
    /// This is the class that stores the data required to find an image.
    /// </summary>
    public class ImageLocationData
    {
        /// <summary>
        /// This is the mongo equivalent of _id and needs to be setup upon creation.
        /// </summary>
        [BsonId]
        public ObjectId ID { get; set; }
        /// <summary>
        /// This is the Images.ID for the document that contains the appropriate image. 
        /// </summary>
        [BsonElement("image_document_id")]
        public ObjectId ImageDocumentId { get; set; }
        /// <summary>
        /// This is the EmbeddedImageData.ID for the image data in the associated document.
        /// </summary>
        [BsonElement("image_id")]
        public ObjectId ImageId { get; set; }
        /// <summary>
        /// This is the date at which this data is still usable.
        /// </summary>
        [BsonElement("expires_at")]
        public DateTime ExpiresAt { get; set; }
    }
}
