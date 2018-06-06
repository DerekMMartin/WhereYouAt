using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConnectionLib.Modules
{
    internal class PrivilegeResources
    {
        [BsonElement("db")]
        public string DB { get; set; }
        [BsonElement("collection")]
        public string Collection { get; set; }
    }
}
