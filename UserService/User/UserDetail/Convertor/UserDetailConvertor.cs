using Core.DataTypes;
using Model.Edu.User;
using UserService.User.Dto;
using UserService.User.UserDetail.Dto;

namespace UserService.User.UserDetail.Convertor
{
    public class UserDetailConvertor : IUserDetailConvertor
    {
        public Task<UserDetailDto> ConvertToWebModel(UserDbo detail, List<string> culture)
        {
            List<Address> address = detail
                .Person.PersonAddress.Select(item => new Address()
                {
                    Id = item.Id,
                    AddressTypeId = item.AddressTypeId,
                    City = item.City,
                    CountryId = item.CountryId,
                    HouseNumber = item.HouseNumber,
                    Region = item.Region,
                    Street = item.Street,
                    ZipCode = item.ZipCode,
                    AddresssType = item.AddressType.SystemIdentificator
                })
                .ToList();
            return Task.FromResult(
                new UserDetailDto()
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
                }
            );
        }
    }
}
