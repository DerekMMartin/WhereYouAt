using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConnectionLib.Modules
{
    [BsonIgnoreExtraElements]
    internal class CreateUser
    {
        [BsonElement("createUser")]
        public string User { get; set; }
        [BsonElement("pwd")]
        public string Password { get; set; }
        [BsonElement("roles")]
        public List<Roles> Roles { get; set; }
    }
}
