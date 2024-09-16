using Core.Base.Filter;

namespace CourseService.Course.CourseList.Filter
{
    public class CourseFilter : RequestFilter
    {
        public string? Name { get; set; }
        public bool? IsPrivateCourse { get; set; }
        public bool? AutomaticGenerateCertificate { get; set; }
        public bool? SendEmail { get; set; }
        public bool? CourseWithLector { get; set; }
        public int? Sale { get; set; }
        public int? MinimumStudent { get; set; }
        public int? MaximumStudent { get; set; }
        public double? Price { get; set; }
        public List<Guid> CourseTypeId { get; set; } = [];
        public List<Guid> CourseStatusId { get; set; } = [];
        public List<Guid> CertificateId { get; set; } = [];
        public List<Guid> CourseMaterialId { get; set; } = [];
        public List<Guid> SendMessageId { get; set; } = [];
    }
}
