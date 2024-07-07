using System;
using Core.Base.Dto;

namespace Services.Course.Dto
{
    public class CourseCreateDto : CreateDto
    {
        public double Price { get; set; }
        public int Sale { get; set; }
        public int DefaultMinimumStudents { get; set; } = 0;
        public int DefaultMaximumStudents { get; set; } = 0;
        public Guid CourseTypeId { get; set; }
        public Guid CourseStatusId { get; set; }
        public bool IsPrivateCourse { get; set; } = false;
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? CertificateId { get; set; }
        public bool AutomaticGenerateCertificate { get; set; }
        public Guid? CourseMaterialId { get; set; }
        public bool SendEmail { get; set; }
        public Guid? EmailTemplateId { get; set; }
        public bool CourseWithLector { get; set; }
        public Guid OrganizationId { get; set; }
    }
}
