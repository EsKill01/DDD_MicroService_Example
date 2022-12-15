using AutoMapper;
using Appoitment.Application.Commands.Phone;
using Appoitment.Application.Commands.User;
using Appoitment.Application.Extentions;
using Appoitment.Application.Models;
using Appoitment.Domain.Entities;
using Appoitment.Domain.Entities.UserType;

namespace Appoitment.Application.Mappers
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
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email))
                .ForMember(dest => dest.Addresses, act => act.MapFrom(src => src.Addresses))
                .ReverseMap();

                cfg.CreateMap<User, UserModel>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, act => act.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Addresses, act => act.MapFrom(src => src.Addresses))
                .ForMember(dest => dest.Dni, act => act.MapFrom(src => src.Dni))
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserType, act => act.MapFrom(src => src.UserType.UserTypeName))
                .ForMember(dest => dest.Phones, act => act.MapFrom(src => src.Phones))
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src._id.ToString()))
                .ForMember(dest => dest.Gender, act => act.MapFrom(src => string.IsNullOrEmpty(src.UserGender.GenderName) ? "not specified" : src.UserGender.GenderName))
                .ForMember(dest => dest.Age, act => act.MapFrom(src => DateTimeHelper.Age(src.Birthdate)))
                .ReverseMap();

                cfg.CreateMap<Gender, GenderModel>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src._id.ToString()))
                .ReverseMap();

                cfg.CreateMap<AddressModel, Address>()
                .ReverseMap();

                cfg.CreateMap<PhoneTypeModel, PhoneType>()
                .ForMember(dest => dest.PhoneTypeName, act => act.MapFrom(src => src.PhoneTypeName))
                .ReverseMap()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src._id.ToString()));

                cfg.CreateMap<PhoneModel, Phone>()
                .ForMember(dest => dest.Code, act => act.MapFrom(src => src.Code))
                .ForMember(dest => dest.Number, act => act.MapFrom(src => src.Number))
                .ReverseMap()
                .ForMember(dest => dest.PhoneType, act => act.MapFrom(src => src.PhoneType.PhoneTypeName));

                cfg.CreateMap<PhoneModel, PhoneTypeModel>()
                  .ForMember(dest => dest.PhoneTypeName, act => act.MapFrom(src => src.PhoneType))
                  .ReverseMap();

                cfg.CreateMap<User, UserPostCommand>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.Lastname, act => act.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email))
                .ForMember(dest => dest.Addresses, act => act.MapFrom(src => src.Addresses))
                .ForMember(dest => (dest.UserTypeId), act => act.MapFrom(src => src.UserTypeId))
                .ForMember(dest => (dest.Phones), act => act.MapFrom(src => src.Phones))
                .ForMember(dest => (dest.GenderId), act => act.MapFrom(src => src.GenderId))
                .ForMember(dest => (dest.Birthdate), act => act.MapFrom(src => src.Birthdate))
                .ReverseMap()
                .ForMember(dest => (dest.GenderId), act => act.MapFrom(src => src.GenderId))
                .ForMember(dest => (dest.UserTypeId), act => act.MapFrom(src => src.UserTypeId));

                cfg.CreateMap<UserTypeModel, UserType>()

                .ReverseMap()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src._id.ToString()));

                cfg.CreateMap<PhoneCommand, PhoneModel>()
                .ForMember(dest => dest.Number, act => act.MapFrom(src => src.Number))
                .ForMember(dest => dest.Code, act => act.MapFrom(src => src.Code))
                .ReverseMap()
                .ForMember(dest => dest.PhoneTypeId, act => act.MapFrom(src => src.PhoneType));

                cfg.CreateMap<PhoneCommand, Phone>()
                .ForMember(dest => dest.Number, act => act.MapFrom(src => src.Number))
                .ForMember(dest => dest.Code, act => act.MapFrom(src => src.Code))
                .ForMember(dest => dest.PhoneTypeId, act => act.MapFrom(src => src.PhoneTypeId))
                .ReverseMap()
                .ForMember(dest => dest.PhoneTypeId, act => act.MapFrom(src => src.PhoneTypeId));
            });

            return config;
        }
    }
}