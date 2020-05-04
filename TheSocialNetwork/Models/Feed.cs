using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TheSocialNetwork.Models;

namespace TheSocialNetwork.Models
{
    public class Feed
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FeedID { get; set; }

        public string Logged_In_User_Id { get; set; }

        public User UsersFeed { get; set; }
    }
}
