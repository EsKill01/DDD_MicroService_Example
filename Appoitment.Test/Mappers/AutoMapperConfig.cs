using AutoMapper;
using Appoitment.Application.Commands.Phone;
using Appoitment.Application.Commands.User;
using Appoitment.Application.Models;
using Appoitment.Domain.Entities;

namespace Appoitment.Test.Mappers
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Configuration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserPostCommand, UserModel>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, act => act.MapFrom(src => src.Lastname))
                .ReverseMap();

                cfg.CreateMap<Address, AddressModel>()
                .ForMember(dest => dest.Street, act => act.MapFrom(src => src.Street))
                .ForMember(dest => dest.City, act => act.MapFrom(src => src.City))
                .ReverseMap();

                cfg.CreateMap<User, UserModel>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, act => act.MapFrom(src => src.LastName))
                .ReverseMap();

                cfg.CreateMap<Phone, PhoneCommand>()
               .ReverseMap();

                cfg.CreateMap<Phone, PhoneModel>()
               .ReverseMap();

                cfg.CreateMap<UserPostCommand, User>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, act => act.MapFrom(src => src.Lastname))
                .ReverseMap()
                .ForMember(dest => dest.Addresses, act => act.MapFrom(src => src.Addresses))
                .ForMember(dest => dest.GenderId, act => act.MapFrom(src => src.UserGender._id.ToString()))
                .ForMember(dest => dest.UserTypeId, act => act.MapFrom(src => src.UserType._id.ToString()));
            });

            return config;
        }
    }
}