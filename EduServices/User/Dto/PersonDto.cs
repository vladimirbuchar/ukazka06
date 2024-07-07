using System.Collections.Generic;
using Core.DataTypes;
using Core.Extension;

namespace Services.User.Dto
{
    public class PersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string FullName =>
            FirstName.IsNullOrEmptyWithTrim() && SecondName.IsNullOrEmptyWithTrim() && LastName.IsNullOrEmptyWithTrim()
                ? string.Empty
                : SecondName.IsNullOrEmptyWithTrim()
                    ? string.Format("{0} {1}", FirstName.Trim(), LastName.Trim())
                    : string.Format("{0} {1} {2}", FirstName.Trim(), SecondName.Trim(), LastName.Trim());
        public HashSet<Address> Address { get; set; } = [];
        public string AvatarUrl { get; set; } = "";
    }
}
