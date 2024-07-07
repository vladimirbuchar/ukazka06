using Core.Base.Dto;
using System;

namespace Services.OrganizationCulture.Dto
{
    public class OrganizationCultureListDto : ListDto
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public Guid CultureId { get; set; }
    }
}
