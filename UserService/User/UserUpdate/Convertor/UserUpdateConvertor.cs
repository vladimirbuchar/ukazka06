using Model.Edu.Person;
using Model.Edu.PersonAddress;
using Model.Edu.User;
using UserService.User.UserUpdate.Dto;

namespace UserService.User.UserUpdate.Convertor
{
    public class UserUpdateConvertor : IUserUpdateConvertor
    {
        public Task<UserDbo> ConvertToBussinessEntity(UserUpdateDto update, UserDbo entity, string culture)
        {
            foreach (PersonAddressDbo addr in entity.Person.PersonAddress)
            {
                if (update.Person.Address.FirstOrDefault(x => x.Id == addr.Id) == null)
                {
                    addr.IsDeleted = true;
                }
            }
            List<PersonAddressDbo> address = update
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
                .ToList();
            entity.Person = new PersonDbo()
            {
                FirstName = update.Person.FirstName,
                LastName = update.Person.LastName,
                SecondName = update.Person.SecondName,
                PersonAddress = address,
                AvatarUrl = update.Person.AvatarUrl
            };
            return Task.FromResult(entity);
        }
    }
}
