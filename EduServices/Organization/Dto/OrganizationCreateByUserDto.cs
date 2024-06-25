using Core.Base.Dto;
using Core.DataTypes;
using System;
using System.Collections.Generic;

namespace EduServices.Organization.Dto
{
    public class OrganizationCreateByUserDto : CreateDto
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string WWW { get; set; }
        public HashSet<Address> Addresses { get; set; }
        public string Name { get; set; }
        public Guid DefaultCultureId { get; set; }
    }

}
