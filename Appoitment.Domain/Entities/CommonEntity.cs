using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Appoitment.Domain.Entities
{
    public class CommonEntity : ICommonEntity
    {
        [BsonId]
        public ObjectId _id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnore]
        public string Id { get; set; }

        [BsonElement("createdDate")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}