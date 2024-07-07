using System;
using Core.Base.Dto;

namespace Services.StudentGroup.Dto
{
    public class StudentGroupCreateDto : CreateDto
    {
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
    }
}
