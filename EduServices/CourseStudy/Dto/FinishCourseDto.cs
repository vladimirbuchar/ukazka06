using Core.Base.Dto;

namespace EduServices.CourseStudy.Dto
{
    public class FinishCourseDto : ListDto
    {
        public string CertificatePdf { get; set; }
        public bool PdfCreated { get; set; }
    }
}
