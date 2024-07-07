using Core.Base.Dto;
using System;

namespace Services.StudentGroup.Dto
{
    public class StudentGroupCreateDto : CreateDto
    {
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
    }

}