using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConnectionLib.Modules
{
    public class ImageMessageEmbedded
    {
        [BsonId]
        public ObjectId ID { get; set; }
        [BsonElement("date_sent")]
        public DateTime DateSent { get; set; }
        [BsonElement("image")]
        public ImageLocationData Image { get; set; }
        [BsonElement("sender")]
        public ObjectId SenderId { get; set; }
    }
}
