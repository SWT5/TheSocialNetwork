using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using TheSocialNetwork.Models;

namespace TheSocialNetwork.Services
{
    public class WallService
    {
        private readonly IMongoCollection<Wall> _walls;

        public WallService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("SocialNetworkDb"));
            IMongoDatabase database = client.GetDatabase("SocialNetworkDb");

            _walls = database.GetCollection<Wall>("walls");
        }

        public List<Wall> Get() =>
            _walls.Find(wall => true).ToList();

        public Wall Get(string userID) =>
            _walls.Find<Wall>(wall => wall.UserID == userID).FirstOrDefault();

        public Wall Create(Wall wall)
        {
            _walls.InsertOne(wall);
            return wall;
        }

        public void Update(string userID, Wall wallIn) =>
            _walls.ReplaceOne(wall => wall.UserID == userID, wallIn);

        public void Remove(Wall wallIn) =>
            _walls.DeleteOne(wall => wall.UserID == wallIn.UserID);

        public void Remove(string userID) =>
            _walls.DeleteOne(wall => wall.UserID == userID);


    }
}