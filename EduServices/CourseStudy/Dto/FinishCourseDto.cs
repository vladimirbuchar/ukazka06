using Core.Base.Dto;

namespace Services.CourseStudy.Dto
{
    public class FinishCourseDto : ListDto
    {
        public string CertificatePdf { get; set; }
        public bool PdfCreated { get; set; }
    }
}
