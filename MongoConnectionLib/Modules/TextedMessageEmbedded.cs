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
    /// This is the class that is teh document format of the TextedMessageEmbedded.
    /// </summary>
    public class TextedMessageEmbedded
    {
        /// <summary>
        /// This is the mongo equivalent of _id and needs to be setup upon creation.
        /// </summary>
        [BsonId]
        public ObjectId ID { get; set; }
        /// <summary>
        /// This is the date the message was sent to this document's user 
        /// </summary>
        [BsonElement("date_sent")]
        public DateTime DateSent { get; set; }
        /// <summary>
        /// This is the message sent.
        /// </summary>
        [BsonElement("message")]
        public string Message { get; set; }
        /// <summary>
        /// This is the Profile.ID of the sender.
        /// </summary>
        [BsonElement("sender")]
        public ObjectId SenderId { get; set; }
    }
}
