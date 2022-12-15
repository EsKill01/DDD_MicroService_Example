using FluentValidation;
using Appoitment.Application.Commands.User;
using System.Linq;

namespace Appoitment.Application.Validations.Commands.User
{
    public class UserPostCommandValidation : AbstractValidator<UserPostCommand>
    {
        public UserPostCommandValidation()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Please specify a first name.");
            RuleFor(c => c.Lastname).NotEmpty().WithMessage("Please specify a last name.");
            RuleFor(c => c.Email).NotEmpty().WithMessage("Please specify an email address.");
            RuleFor(c => c.UserTypeId).NotEmpty().WithMessage("Please specify an user type id.");
            RuleFor(c => c.Phones.FirstOrDefault()).NotNull().WithMessage("Please specify at least phone number.");
            RuleFor(c => c.Phones.FirstOrDefault().PhoneTypeId).NotEmpty().WithMessage("Please specify phone type id.");
            RuleFor(c => c.DNI).NotEmpty().WithMessage("Please specify user DNI.");
            RuleFor(c => c.Birthdate).NotEmpty().WithMessage("Please specify user date of birth");
        }
    }
}