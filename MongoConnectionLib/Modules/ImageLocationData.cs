using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConnectionLib.Modules
{
    public class ImageLocationData
    {
        [BsonId]
        public ObjectId ID { get; set; }
        [BsonElement("image_document_id")]
        public ObjectId ImageDocumentId { get; set; }
        [BsonElement("image_id")]
        public ObjectId ImageId { get; set; }
    }
}
