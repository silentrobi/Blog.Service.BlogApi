using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
namespace Blog.Service.BlogApi.Domain.SeedWork
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; } 

        public DateTime UpdatedAt { get; set; }

    }
}