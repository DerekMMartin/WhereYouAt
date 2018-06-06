using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConnectionLib.Modules
{
    internal class Roles
    {
        [BsonElement("role")]
        public string Role { get; set; }
        [BsonElement("db")]
        public string DB { get; set; }
    }
}
