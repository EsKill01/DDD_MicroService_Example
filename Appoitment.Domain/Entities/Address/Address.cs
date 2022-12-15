using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Appoitment.Domain.Entities
{
    public class Address
    {
        [BsonElement("street")]
        public string Street { get; set; }

        [BsonElement("city")]
        public string City { get; set; }
    }
}