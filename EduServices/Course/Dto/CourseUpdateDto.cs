using Core.Base.Dto;
using System;

namespace EduServices.Course.Dto
{


    public class CourseUpdateDto : UpdateDto
    {
        public double Price { get; set; }
        public int Sale { get; set; }
        public int DefaultMinimumStudents { get; set; }
        public int DefaultMaximumStudents { get; set; }
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

    }
}
