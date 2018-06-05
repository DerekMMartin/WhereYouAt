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
    /// This is the class for how the location data is set up.
    /// </summary>
    public class EmbeddedLocationData
    {
        /// <summary>
        /// This is the mongo equivalent of _id and needs to be setup upon creation.
        /// </summary>
        [BsonId]
        public ObjectId ID { get; set; }
        /// <summary>
        /// This is the date when this location data is no longer viable.
        /// </summary>
        [BsonElement("Expires_At")]
        public DateTime ExpiresAt { get; set; }
        /// <summary>
        /// This is the latitude for the location data.
        /// </summary>
        [BsonElement("latitude")]
        public double Latitude { get; set; }
        /// <summary>
        /// This is the longitude for the location data.
        /// </summary>
        [BsonElement("longitude")]
        public double Longitude { get; set; }
        /// <summary>
        /// This is the optional image location data.
        /// </summary>
        [BsonElement("location_image")]
        public ImageLocationData ImageLocation { get; set; }
        /// <summary>
        /// These are the Profile document ID's of the users who are allowed to see this data.
        /// </summary>
        [BsonElement("view_restrictions")]
        public List<ObjectId> ViewRestrictions { get; set; }
    }
}
