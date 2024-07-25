using Core.Base.Dto;
using System;

namespace Services.CourseMaterial.Dto
{
    public class CourseMaterialCreateDto : CreateDto
    {
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
