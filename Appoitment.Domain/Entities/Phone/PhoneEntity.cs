using MongoDB.Bson.Serialization.Attributes;

namespace Appoitment.Domain.Entities
{
    public class Phone
    {
        [BsonElement("code")]
        public string Code { get; set; }

        [BsonElement("number")]
        public string Number { get; set; }

        public string PhoneTypeId { get; set; }

        [BsonIgnore]
        public PhoneType PhoneType { get; set; }
    }
}