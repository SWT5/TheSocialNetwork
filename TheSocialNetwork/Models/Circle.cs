using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TheSocialNetwork.Models;

namespace TheSocialNetwork.Models
{
    public class Circle
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CircleId { get; set; }

        public string CircleName { get; set; }

        public List<User> Users { get; set; }

        public List<Post> Posts { get; set; }
    }
}
