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
    /// This is the class that is passed into format the Locations collection documents.
    /// </summary>
    public class Locations
    {
        /// <summary>
        /// This is the mongo equivalent of _id and is automatically set upon insetion int the collection.
        /// </summary>
        [BsonId]
        public ObjectId ID { get; set; }
        /// <summary>
        /// This is the Users.ID for this documents user.
        /// </summary>
        [BsonElement("user")]
        public ObjectId UserId { get; set; }
        /// <summary>
        /// This is a list of the EmbeddedLocationData stored on this document.
        /// </summary>
        [BsonElement("locations")]
        public List<EmbeddedLocationData> LocationData { get; set; }
    }
}
