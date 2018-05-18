using System;
using System.Collections.Generic;
using System.Text;

namespace WhereYouAt.models
{
    class User
    {
        public User(int Id, string userName)
        {
            id = Id;
            username = userName;
        }
        public int id { get; }
        public string username { get; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public Picture profilepicture { get; set; }
    }
}
