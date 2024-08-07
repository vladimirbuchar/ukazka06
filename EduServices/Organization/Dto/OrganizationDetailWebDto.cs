﻿using Core.Base.Dto;

namespace Services.Organization.Dto
{
    public class OrganizationDetailWebDto : ListDto
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string WWW { get; set; }
        public string Name { get; set; }
    }
}
