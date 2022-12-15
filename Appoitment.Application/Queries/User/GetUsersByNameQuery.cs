using Appoitment.Application.Abstractions.Queries;
using Appoitment.Application.Models;
using System.Collections.Generic;

namespace Appoitment.Application.Queries
{
    public class GetUsersByNameQuery : IQuery<List<UserModel>>
    {
        public string Name { get; }

        public GetUsersByNameQuery(string name)
        {
            Name = name;
        }
    }
}