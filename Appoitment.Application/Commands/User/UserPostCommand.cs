using Appoitment.Application.Abstractions.Commands;
using Appoitment.Application.Commands.Phone;
using Appoitment.Application.Models;
using Appoitment.Domain.Responses;
using System;
using System.Collections.Generic;

namespace Appoitment.Application.Commands.User
{
    public class UserPostCommand : CommonCommand, ICommand<RepositoryResponse>
    {
        public string DNI { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }
        public string Email { get; set; }

        public IEnumerable<AddressModel> Addresses { get; set; }

        public IEnumerable<PhoneCommand> Phones { get; set; }

        public string UserTypeId { get; set; }

        public string GenderId { get; set; }

        public DateTime Birthdate { get; set; }
    }
}