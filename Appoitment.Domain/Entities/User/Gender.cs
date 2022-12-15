using MongoDB.Bson.Serialization.Attributes;

namespace Appoitment.Domain.Entities
{
    public class Gender : CommonEntity
    {
        [BsonElement("genderName")]
        public string GenderName { get; set; }
    }
}