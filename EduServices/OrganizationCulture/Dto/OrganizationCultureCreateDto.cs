using Core.Base.Dto;
using System;

namespace Services.OrganizationCulture.Dto
{
    public class OrganizationCultureCreateDto : CreateDto
    {
        public Guid OrganizationId { get; set; }
        public Guid CultureId { get; set; }
        public bool IsDefault { get; set; }
    }
}
