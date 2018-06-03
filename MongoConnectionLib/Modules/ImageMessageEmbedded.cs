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
    /// This is the class for storing the image messages that have been sent to the person.
    /// </summary>
    public class ImageMessageEmbedded
    {
        /// <summary>
        /// This is the mongo equivalent of _id and needs to be setup upon creation.
        /// </summary>
        [BsonId]
        public ObjectId ID { get; set; }
        /// <summary>
        /// This is the date when the image message was sent.
        /// </summary>
        [BsonElement("date_sent")]
        public DateTime DateSent { get; set; }
        /// <summary>
        /// This is the date when the image message needs to be deleted at.
        /// </summary>
        [BsonElement("expires_at")]
        public DateTime ExpiresAt { get; set; }
        /// <summary>
        /// This is the ImageLocationData for this message for finding the image in the database.
        /// </summary>
        [BsonElement("image")]
        public ImageLocationData ImageLocation { get; set; }
        /// <summary>
        /// This is the Users.ID for the preson who went the message.
        /// </summary>
        [BsonElement("sender")]
        public ObjectId SenderId { get; set; }
    }
}
