using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConnectionLib.Modules
{
    [BsonIgnoreExtraElements]
    internal class CreateRole
    {
        [BsonElement("createRole")]
        public string Role { get; set; }
        [BsonElement("privileges")]
        public List<RolePrivileges> Privileges { get; set; }
        [BsonElement("roles")]
        public List<Roles> Roles { get; set; }
    }
}
