using Core.Base.Dto;
using System;

namespace EduServices.StudentGroup.Dto
{
    public class StudentGroupCreateDto : CreateDto
    {
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
    }

}