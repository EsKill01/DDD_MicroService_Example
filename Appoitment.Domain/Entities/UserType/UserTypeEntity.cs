using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Appoitment.Domain.Entities.UserType
{
    public class UserType : CommonEntity
    {
        [BsonElement("userTypeName")]
        public string UserTypeName { get; set; }
    }
}