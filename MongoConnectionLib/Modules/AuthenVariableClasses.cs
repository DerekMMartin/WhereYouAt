using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConnectionLib.Modules
{
    public class AuthenVariableClasses
    {
        public string UserName { get; internal set; }
        public bool IsAuthenticated { get; internal set; }
        public ObjectId UserId { get; internal set; }
    }
}
