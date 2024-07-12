using System;
using System.Collections.Generic;
using Core.Base.Filter;

namespace Services.Branch.Filter
{
    public class BranchFilter : FilterRequest
    {
        public bool? IsMainBranch { get; set; }
        public List<Guid> Country { get; set; } = [];
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string WWW { get; set; }
        public string Name { get; set; }
    }
}
