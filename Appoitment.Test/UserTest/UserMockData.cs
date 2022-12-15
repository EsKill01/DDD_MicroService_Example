using Appoitment.Application.Models;
using Appoitment.Domain.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace Appoitment.Test.UserTest
{
    public static class UserMockData
    {
        public static ICollection<User> GetDTOUsers()
        {
            var _user = new List<User>()
            {
                new User()
                {
                    Name = "Roberto",
                    LastName = "Vargas",
                    CreatedDate = DateTime.Now,
                    _id = ObjectId.Parse("628c67be75245b2c62423234"),
                    Addresses = new List<Address>()
                    {
                        new Address
                        {
                            City = "San Jose",
                            Street = "232344"
                        }
                    },
                    Birthdate = DateTime.Now,
                    Dni = "25212522",
                    Email = "este1@gmail.com",
                    GenderId = "628c67be75245b2c62423234",
                    Phones = new List<Phone>()
                    {
                        new Phone
                        {
                            Code = "345",
                            Number = "878854566",
                            PhoneTypeId = "628c67be75245b2c62423234"
                        }
                    },
                    UserTypeId = "628c67be75245b2c62423234"
                },
                new User()
                {
                    Name = "Ricardo",
                    LastName = "Mejia",
                    CreatedDate = DateTime.Now,
                    _id = ObjectId.Parse("628c69e3bb48da105534047f"),
                    Addresses = new List<Address>()
                    {
                        new Address
                        {
                            City = "San Jose",
                            Street = "232344"
                        }
                    },
                    Birthdate = DateTime.Now,
                    Dni = "25412523",
                    Email = "este2@gmail.com",
                    GenderId = "628c67be75245b2c62423234",
                    Phones = new List<Phone>()
                    {
                        new Phone
                        {
                            Code = "345",
                            Number = "878854566",
                            PhoneTypeId = "628c67be75245b2c62423234"
                        }
                    },
                    UserTypeId = "628c67be75245b2c62423234"
                },
                new User()
                {
                    Name = "Josue",
                    LastName = "Ramirez",
                    CreatedDate = DateTime.Now,
                    _id = ObjectId.Parse("628c789a214e3deb67964799"),
                    Addresses = new List<Address>()
                    {
                        new Address
                        {
                            City = "San Jose",
                            Street = "232344"
                        }
                    },
                    Birthdate = DateTime.Now,
                    Dni = "25212529",
                    Email = "este3@gmail.com",
                    GenderId = "628c67be75245b2c62423234",
                    Phones = new List<Phone>()
                    {
                        new Phone
                        {
                            Code = "345",
                            Number = "878854566",
                            PhoneTypeId = "628c67be75245b2c62423234"
                        }
                    },
                    UserTypeId = "628c67be75245b2c62423234"
                },
                new User()
                {
                    Name = "Juan",
                    LastName = "Madrigal",
                    CreatedDate = DateTime.Now,
                    _id = ObjectId.Parse("628d32e6845530b82291981e"),
                    Addresses = new List<Address>()
                    {
                        new Address
                        {
                            City = "San Jose",
                            Street = "232344"
                        }
                    },
                    Birthdate = DateTime.Now,
                    Dni = "25212520",
                    Email = "este4@gmail.com",
                    GenderId = "628c67be75245b2c62423234",
                    Phones = new List<Phone>()
                    {
                        new Phone
                        {
                            Code = "345",
                            Number = "878854566",
                            PhoneTypeId = "628c67be75245b2c62423234"
                        }
                    },
                    UserTypeId = "628c67be75245b2c62423234"
                },
                new User()
                {
                    Name = "Jose",
                    LastName = "Varela",
                    CreatedDate = DateTime.Now,
                    _id = ObjectId.Parse("628d3435454646fdda33b859"),
                    Addresses = new List<Address>()
                    {
                        new Address
                        {
                            City = "San Jose",
                            Street = "232344"
                        }
                    },
                    Birthdate = DateTime.Now,
                    Dni = "25212529",
                    Email = "este5@gmail.com",
                    GenderId = "628c67be75245b2c62423234",
                    Phones = new List<Phone>()
                    {
                        new Phone
                        {
                            Code = "345",
                            Number = "878854566",
                            PhoneTypeId = "628c67be75245b2c62423234"
                        }
                    },
                    UserTypeId = "628c67be75245b2c62423234"
                },
            };

            return _user;
        }

        public static ICollection<UserModel> GetUsersModel()
        {
            var _user = new List<UserModel>()
            {
                new UserModel()
                {
                    Name = "Roberto",
                    LastName = "Vargas",
                    Id = "628c67be75245b2c62423234",
                    Addresses = new List<AddressModel>()
                    {
                        new AddressModel
                        {
                            City = "San Jose",
                            Street = "234354"
                        }
                    },
                    Age = 36,
                    Dni = "25212522",
                    Email = "este1@gmail.com",
                    Gender = "Masculino",
                    Phones = new List<PhoneModel>()
                    {
                        new PhoneModel
                        {
                            Code = "345667",
                            Number = "8978112",
                            PhoneType = "Celular"
                        }
                    },
                    UserType = "Admin"
                },
                new UserModel()
                {
                    Name = "Ricardo",
                    LastName = "Mejia",
                    Id = "628c69e3bb48da105534047f",
                    Addresses = new List<AddressModel>()
                    {
                        new AddressModel
                        {
                            City = "San Jose",
                            Street = "234354"
                        }
                    },
                    Age = 36,
                    Dni = "25412523",
                    Email = "este2@gmail.com",
                    Gender = "Masculino",
                    Phones = new List<PhoneModel>()
                    {
                        new PhoneModel
                        {
                            Code = "345667",
                            Number = "8978112",
                            PhoneType = "Celular"
                        }
                    },
                    UserType = "Admin"
                },
                new UserModel()
                {
                    Name = "Josue",
                    LastName = "Ramirez",
                    Id = "628c789a214e3deb67964799",
                    Addresses = new List<AddressModel>()
                    {
                        new AddressModel
                        {
                            City = "San Jose",
                            Street = "234354"
                        }
                    },
                    Age = 36,
                    Dni = "25212529",
                    Email = "este3@gmail.com",
                    Gender = "Masculino",
                    Phones = new List<PhoneModel>()
                    {
                        new PhoneModel
                        {
                            Code = "345667",
                            Number = "8978112",
                            PhoneType = "Celular"
                        }
                    },
                    UserType = "Admin"
                },
                new UserModel()
                {
                    Name = "Juan",
                    LastName = "Madrigal",
                    Id = "628d32e6845530b82291981e",
                    Addresses = new List<AddressModel>()
                    {
                        new AddressModel
                        {
                            City = "San Jose",
                            Street = "234354"
                        }
                    },
                    Age = 36,
                    Dni = "25212520",
                    Email = "este4@gmail.com",
                    Gender = "Masculino",
                    Phones = new List<PhoneModel>()
                    {
                        new PhoneModel
                        {
                            Code = "345667",
                            Number = "8978112",
                            PhoneType = "Celular"
                        }
                    },
                    UserType = "Admin"
                },
                new UserModel()
                {
                    Name = "Jose",
                    LastName = "Varela",
                    Id = "628d3435454646fdda33b859",
                    Addresses = new List<AddressModel>()
                    {
                        new AddressModel
                        {
                            City = "San Jose",
                            Street = "234354"
                        }
                    },
                    Age = 36,
                    Dni = "25212529",
                    Email = "este5@gmail.com",
                    Gender = "Masculino",
                    Phones = new List<PhoneModel>()
                    {
                        new PhoneModel
                        {
                            Code = "345667",
                            Number = "8978112",
                            PhoneType = "Celular"
                        }
                    },
                    UserType = "Admin"
                },
            };

            return _user;
        }
    }
}