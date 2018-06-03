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
    /// This is the class that is used as the document format of the Messages collection.
    /// </summary>
    public class Messages
    {
        /// <summary>
        /// This is the mongo equivalent of _id and is automatically set upon insertion into the collection.
        /// </summary>
        [BsonId]
        public ObjectId ID { get; set; }
        /// <summary>
        /// This is the Users.ID of this document's user.
        /// </summary>
        [BsonElement("user")]
        public ObjectId UserId { get; set; }
        /// <summary>
        /// This is all the TextedMessageEmbedded for this document's user.
        /// </summary>
        [BsonElement("texted_messages")]
        public List<TextedMessageEmbedded> SentMessages { get; set; }
        /// <summary>
        /// This is all the ImageMessageEmbedded for this document's user.
        /// </summary>
        [BsonElement("image_message")]
        public List<ImageMessageEmbedded> SentImages { get; set; }
    }
}
