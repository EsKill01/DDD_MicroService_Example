using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Appoitment.Domain.Entities
{
    public interface ICommonEntity
    {
        ObjectId _id { get; set; }
        DateTime CreatedDate { get; set; }

        [BsonIgnore]
        string Id { get; set; }
    }
}