using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TheSocialNetwork.Models
{
    public class Wall
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserID { get; set; }

        public string User { get; set; }

        public User UsersWall { get; set; }

        public string GuestID { get; set; }

        public User Guest { get; set; }

        //public List<Post> WallPosts { get; set; }

    }
}