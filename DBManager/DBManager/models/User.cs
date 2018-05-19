using System;
using System.Collections.Generic;
using System.Text;

namespace WhereYouAt.models
{
    public class User
    {
        public User(int Id, string userName)
        {
            id = Id;
            UserName = userName;
        }
        public int id { get; }
        public string UserName{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ProfilePictureId { get; set; }
    }
}
