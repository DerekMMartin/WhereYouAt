using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConnectionLib.Modules
{
    internal class RolePrivileges
    {
        [BsonElement("resource")]
        public PrivilegeResources Resources { get; set; }
        [BsonElement("actions")]
        public List<string> Actions { get; set; }
    }
}
