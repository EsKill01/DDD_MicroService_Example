using AutoMapper;
using Appoitment.Application.Abstractions.Handlers;
using Appoitment.Application.Abstractions.Repository;
using Appoitment.Application.Commands.User;
using Appoitment.Application.Models;
using Appoitment.Domain.Entities;
using Appoitment.Domain.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Appoitment.Application.Handlers.Users.UserPostHandler
{
    public class UserPostCommandHandler : CommonHandler, ICommandHandler<UserPostCommand, RepositoryResponse>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper maper;

        public UserPostCommandHandler(IUserRepository userRepository, IMapper maper)
        {
            this.userRepository = userRepository;
            this.maper = maper;
        }

        public async Task<RepositoryResponse> Handle(UserPostCommand request, CancellationToken cancellationToken)
        {
            var map = maper.Map<User>(request);

            var result = await userRepository.AddAsync(map);

            result.ObjectResponse = maper.Map<UserModel>(result.ObjectResponse); ;

            return result;
        }
    }
}