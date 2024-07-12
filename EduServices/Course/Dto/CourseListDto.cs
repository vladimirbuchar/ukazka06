using Core.Base.Dto;
using System;

namespace Services.Course.Dto
{
    public class CourseListDto : ListDto
    {
        public string Name { get; set; }
        public bool IsPrivateCourse { get; set; } = false;
        public double Price { get; set; }
        public int Sale { get; set; }
        public int MinimumStudent { get; set; }
        public int MaximumStudent { get; set; }
        public bool AutomaticGenerateCertificate { get; set; }
        public bool SendEmail { get; set; }
        public bool CourseWithLector { get; set; }
        public Guid? CourseTypeId { get; set; }
        public string CourseTypeName { get; set; }
        public Guid? CourseStatusId { get; set; }
        public string CouseStatusName { get; set; }
        public Guid? CertificateId { get; set; }
        public string CertificateName { get; set; }
        public Guid? CourseMaterialId { get; set; }
        public string CourseMaterialName { get; set; }
        public Guid? SendMessageId { get; set; }
        public string SendMessageName { get; set; }
    }
}


