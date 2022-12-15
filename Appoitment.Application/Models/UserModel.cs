using System.Collections.Generic;

namespace Appoitment.Application.Models
{
    public class UserModel : CommonModel
    {
        public string Dni { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public IEnumerable<AddressModel> Addresses { get; set; }

        public IEnumerable<PhoneModel> Phones { get; set; }

        public string UserType { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }
    }
}