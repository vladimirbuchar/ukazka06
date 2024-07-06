using Core.DataTypes;
using Core.Extension;
using EduServices.User.Dto;
using Model.Edu.Person;
using Model.Edu.PersonAddress;
using Model.Edu.User;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.User.Convertor
{
    public class UserConvertor : IUserConvertor
    {
        public UserDbo ConvertToBussinessEntity(UserCreateDto webModel, string culture)
        {
            HashSet<PersonAddressDbo> address = webModel
                .Person.Address.Select(item => new PersonAddressDbo()
                {
                    AddressTypeId = item.AddressTypeId,
                    City = item.City,
                    CountryId = item.CountryId,
                    HouseNumber = item.HouseNumber,
                    Region = item.Region,
                    Street = item.Street,
                    ZipCode = item.ZipCode
                })
                .ToHashSet();
            return new UserDbo()
            {
                UserEmail = webModel.UserEmail,
                UserPassword = webModel.UserPassword.GetHashString(),
                Person = new PersonDbo()
                {
                    FirstName = webModel.Person.FirstName,
                    LastName = webModel.Person.LastName,
                    SecondName = webModel.Person.SecondName,
                    PersonAddress = address,
                    AvatarUrl = webModel.Person.AvatarUrl
                },
                AllowCLassicLogin = webModel.AllowClassicLogin
            };
        }

        public UserDbo ConvertToBussinessEntity(UserUpdateDto userUpdateDto, UserDbo entity, string culture)
        {
            foreach (PersonAddressDbo addr in entity.Person.PersonAddress)
            {
                if (userUpdateDto.Person.Address.FirstOrDefault(x => x.Id == addr.Id) == null)
                {
                    addr.IsDeleted = true;
                }
            }
            HashSet<PersonAddressDbo> address = userUpdateDto
                .Person.Address.Select(item => new PersonAddressDbo()
                {
                    Id = item.Id,
                    AddressTypeId = item.AddressTypeId,
                    City = item.City,
                    CountryId = item.CountryId,
                    HouseNumber = item.HouseNumber,
                    Region = item.Region,
                    Street = item.Street,
                    ZipCode = item.ZipCode,
                })
                .ToHashSet();
            entity.Person = new PersonDbo()
            {
                FirstName = userUpdateDto.Person.FirstName,
                LastName = userUpdateDto.Person.LastName,
                SecondName = userUpdateDto.Person.SecondName,
                PersonAddress = address,
                AvatarUrl = userUpdateDto.Person.AvatarUrl
            };
            return entity;
        }

        public UserTokenDto ConvertToWebModel(UserDbo loginUser)
        {
            return new UserTokenDto()
            {
                Id = loginUser.Id,
                IsAvatarUrl = loginUser.Person.AvatarUrl?.IsValidUri(),
                Avatar =
                    loginUser.Person.AvatarUrl == null
                        ? string.Format("{0}{1}", loginUser.Person.FirstName?.FirstOrDefault(), loginUser.Person.LastName?.FirstOrDefault())
                        : loginUser.Person.AvatarUrl.IsValidUri()
                            ? loginUser.Person.AvatarUrl
                            : string.Format("{0}{1}", loginUser.Person.FirstName.FirstOrDefault(), loginUser.Person.LastName.FirstOrDefault()),
                FullName = string.Format("{0} {1}", loginUser.Person.FirstName, loginUser.Person.LastName),
                UserMustChangePassword = loginUser.UserMustChangePassword,
                UserEmail = loginUser.UserEmail,
                UserRole = loginUser.UserRole.SystemIdentificator
            };
        }

        public HashSet<UserListDto> ConvertToWebModel(HashSet<UserDbo> list, string culture)
        {
            return list.Select(item => new UserListDto()
            {
                Id = item.Id,
                PersonName = new PersonDto()
                {
                    Address = item
                            .Person.PersonAddress.Select(x => new Address()
                            {
                                Id = x.Id,
                                AddressTypeId = x.AddressTypeId,
                                City = x.City,
                                CountryId = x.CountryId,
                                HouseNumber = x.HouseNumber,
                                Region = x.Region,
                                Street = x.Street,
                                ZipCode = x.ZipCode,
                            })
                            .ToHashSet(),
                    AvatarUrl =
                            item.Person.AvatarUrl == null
                                ? string.Format("{0}{1}", item.Person.FirstName.FirstOrDefault(), item.Person.LastName.FirstOrDefault())
                                : item.Person.AvatarUrl.IsValidUri()
                                    ? item.Person.AvatarUrl
                                    : string.Format("{0}{1}", item.Person.FirstName.FirstOrDefault(), item.Person.LastName.FirstOrDefault()),
                    FirstName = item.Person.FirstName,
                    LastName = item.Person.LastName,
                    SecondName = item.Person.LastName,
                }
            })
                .ToHashSet();
        }

        public UserDetailDto ConvertToWebModel(UserDbo detail, string culture)
        {
            HashSet<Address> address = detail
                .Person.PersonAddress.Select(item => new Address()
                {
                    Id = item.Id,
                    AddressTypeId = item.AddressTypeId,
                    City = item.City,
                    CountryId = item.CountryId,
                    HouseNumber = item.HouseNumber,
                    Region = item.Region,
                    Street = item.Street,
                    ZipCode = item.ZipCode
                })
                .ToHashSet();
            return new UserDetailDto()
            {
                Id = detail.Id,
                Person = new PersonDto()
                {
                    FirstName = detail.Person.FirstName,
                    Address = address,
                    LastName = detail.Person.LastName,
                    SecondName = detail.Person.SecondName
                },
                UserEmail = detail.UserEmail
            };
        }
    }
}
