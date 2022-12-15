using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Appoitment.Domain.Entities
{
    public class User : CommonEntity
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("addresses")]
        public IEnumerable<Address> Addresses { get; set; } = new List<Address>();

        [BsonElement("phones")]
        public IEnumerable<Phone> Phones { get; set; } = new List<Phone>();

        [BsonElement("numberPersonal")]
        public string Dni { get; set; }

        [BsonElement("userTypeId")]
        public string UserTypeId { get; set; }

        [BsonElement("genderId")]
        public string GenderId { get; set; }

        [BsonElement("birthdate")]
        public DateTime Birthdate { get; set; }

        [BsonIgnore]
        public Gender UserGender { get; set; } = new Gender();

        [BsonIgnore]
        public UserType.UserType UserType { get; set; } = new UserType.UserType();
    }
}