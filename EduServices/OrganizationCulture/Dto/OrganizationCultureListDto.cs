using System;
using Core.Base.Dto;

namespace Services.OrganizationCulture.Dto
{
    public class OrganizationCultureListDto : ListDto
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public Guid CultureId { get; set; }
    }
}
