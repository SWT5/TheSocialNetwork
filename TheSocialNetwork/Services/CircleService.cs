using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using TheSocialNetwork.Models;

namespace TheSocialNetwork.Services
{
    public class CircleService
    {
        private readonly IMongoCollection<Circle> _circles;

        public CircleService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("SocialNetworkDb"));
            IMongoDatabase database = client.GetDatabase("SocialNetworkDb");

            _circles = database.GetCollection<Circle>("circles");
        }


        //Different get methods************************
        public List<Circle> Get()
        {
            return _circles.Find(circle => true).ToList();
        }

        public Circle Get(string circleId)
        {
            return _circles.Find(circle => circle.CircleId == circleId).FirstOrDefault();
        }



        //Different create methods************************
        public Circle Create(Circle circle)
        {
            _circles.InsertOne(circle);
            return circle;
        }


        //Different Update methods************************
        public void Update(string id, Circle circleIn) =>
            _circles.ReplaceOne(circle => circle.CircleId == id, circleIn);


        //Different Remove methods************************
        public void Remove(Circle circleIn) =>
            _circles.DeleteOne(circle => circle.CircleId == circleIn.CircleId);

        public void Remove(string circleId) =>
            _circles.DeleteOne(circle => circle.CircleId == circleId);



    }
}