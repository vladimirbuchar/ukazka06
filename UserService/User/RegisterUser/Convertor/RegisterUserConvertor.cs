using Core.Extension;
using Model.Edu.Person;
using Model.Edu.PersonAddress;
using Model.Edu.User;
using UserService.User.RegisterUser.Dto;

namespace UserService.User.RegisterUser.Convertor
{
    public class RegisterUserConvertor : IRegisterUserConvertor
    {
        public Task<UserDbo> ConvertToBussinessEntity(UserCreateDto create, string culture)
        {
            List<PersonAddressDbo> address = create
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
                .ToList();
            return Task.FromResult(
                new UserDbo()
                {
                    UserEmail = create.UserEmail,
                    UserPassword = create.UserPassword.GetHashString(),
                    Person = new PersonDbo()
                    {
                        FirstName = create.Person.FirstName,
                        LastName = create.Person.LastName,
                        SecondName = create.Person.SecondName,
                        PersonAddress = address,
                        AvatarUrl = create.Person.AvatarUrl
                    },
                    UserMustChangePassword = create.UserMustChangePassword,
                    AllowCLassicLogin = create.AllowClassicLogin,
                    UserRoleId = create.RoleId
                }
            );
        }
    }
}
