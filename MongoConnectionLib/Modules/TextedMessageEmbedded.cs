using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConnectionLib.Modules
{
    public class TextedMessageEmbedded
    {
        [BsonElement("date_sent")]
        public DateTime DateSent { get; set; }
        [BsonElement("message")]
        public string Message { get; set; }
        [BsonElement("sender")]
        public ObjectId SenderId { get; set; }
    }
}
