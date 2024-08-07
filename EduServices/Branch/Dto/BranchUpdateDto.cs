﻿using System;
using Core.Base.Dto;

namespace Services.Branch.Dto
{
    public class BranchUpdateDto : UpdateDto
    {
        public Guid? CountryId { get; set; } = Guid.Empty;
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string WWW { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsMainBranch { get; set; } = false;
    }
}
