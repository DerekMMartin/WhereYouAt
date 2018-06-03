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
    /// This is the class formated for the documents in the Users collection.
    /// </summary>
    public class Users
    {
        /// <summary>
        /// This is the mongo equivalent of _id and is automatically set upon insertion into the collection.
        /// </summary>
        [BsonId]
        public ObjectId ID { get; set; }
        /// <summary>
        /// This is the username encrypted of the user.
        /// </summary>
        [BsonElement("username")]
        public string UserName { get; set; }
        /// <summary>
        /// This is the password encrypted of the user.
        /// </summary>
        [BsonElement("password")]
        public string Password { get; set; }
        /// <summary>
        /// This is the Profile.ID of this user.
        /// </summary>
        [BsonElement("profile_id")]
        public ObjectId ProfileId { get; set; }
        /// <summary>
        /// This is the Friends.ID of this user.
        /// </summary>
        [BsonElement("friend_id")]
        public ObjectId FriendId { get; set; }
        /// <summary>
        /// This is the Messages.ID of this user.
        /// </summary>
        [BsonElement("message_id")]
        public ObjectId MessageId { get; set; }
        /// <summary>
        /// This is the Images.ID of this user.
        /// </summary>
        [BsonElement("image_id")]
        public ObjectId ImageId { get; set; }
        /// <summary>
        /// This is the Locations.ID of this user.
        /// </summary>
        [BsonElement("location_id")]
        public ObjectId LocationId { get; set; }
    }
}
