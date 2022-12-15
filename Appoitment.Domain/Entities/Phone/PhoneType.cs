using MongoDB.Bson.Serialization.Attributes;

namespace Appoitment.Domain.Entities
{
    [BsonKnownTypes(typeof(PhoneTypelandlineEntity), typeof(PhoneTypeMobileEntity))]
    public class PhoneType : CommonEntity
    {
        [BsonElement("phoneTypeName")]
        public string PhoneTypeName { get; set; }
    }

    public class PhoneTypeMobileEntity : PhoneType
    {
    }

    public class PhoneTypelandlineEntity : PhoneType
    {
    }
}