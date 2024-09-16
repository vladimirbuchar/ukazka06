using CourseService.Course.CourseDetail.Dto;
using Model.Edu.Course;

namespace CourseService.Course.CourseDetail.Convertor
{
    public class CourseDetailConvertor : ICourseDetailConvertor
    {
        public Task<CourseDetailDto> ConvertToWebModel(CourseDbo detail, List<string> culture)
        {
            return Task.FromResult(
                new CourseDetailDto()
                {
                    CourseStatusId = detail.CourseStatusId,
                    Description = detail.CourseTranslations.FindTranslation(culture).Description,
                    Name = detail.CourseTranslations.FindTranslation(culture).Name,
                    CourseTypeId = detail.CourseTypeId,
                    FileName = "",
                    Id = detail.Id,
                    IsPrivateCourse = detail.IsPrivateCourse,
                    Price = detail.Price,
                    Sale = detail.Sale,
                    MaximumStudent = detail.MaximumStudent,
                    MinimumStudent = detail.MinimumStudent,
                    CertificateId = detail.CertificateId,
                    AutomaticGenerateCertificate = detail.AutomaticGenerateCertificate,
                    CourseMaterialId = detail.CourseMaterialId,
                    SendEmail = detail.SendEmail,
                    SendMessageId = detail.SendMessageId,
                    CourseWithLector = detail.CourseWithLector
                }
            );
        }
    }
}
