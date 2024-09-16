using Core.DataTypes;
using Core.Extension;

namespace UserService.User.Dto
{
    public class PersonDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string FullName =>
            FirstName.IsNullOrEmptyWithTrim() && SecondName.IsNullOrEmptyWithTrim() && LastName.IsNullOrEmptyWithTrim()
                ? string.Empty
                : SecondName.IsNullOrEmptyWithTrim()
                    ? string.Format("{0} {1}", FirstName.Trim(), LastName.Trim())
                    : string.Format("{0} {1} {2}", FirstName.Trim(), SecondName.Trim(), LastName.Trim());
        public List<Address> Address { get; set; } = [];
        public string AvatarUrl { get; set; } = "";
    }
}
