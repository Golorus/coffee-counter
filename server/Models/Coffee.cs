using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace server.Models
{
    public class Coffee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public User DrunkByUser { get; set; }
        public decimal price { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}