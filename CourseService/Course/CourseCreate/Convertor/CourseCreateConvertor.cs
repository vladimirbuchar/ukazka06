using CourseService.Course.CourseCreate.Dto;
using Model.Edu.Course;

namespace CourseService.Course.CourseCreate.Convertor
{
    public class CourseCreateConvertor : ICourseCreateConvertor
    {
        public Task<CourseDbo> ConvertToBussinessEntity(CourseCreateDto create, string culture)
        {
            CourseDbo course =
                new()
                {
                    Price = create.Price,
                    Sale = create.Sale,
                    CourseStatusId = create.CourseStatusId,
                    CourseTypeId = create.CourseTypeId,
                    OrganizationId = create.OrganizationId,
                    IsPrivateCourse = create.IsPrivateCourse,
                    MaximumStudent = create.DefaultMaximumStudents,
                    MinimumStudent = create.DefaultMinimumStudents,
                    CertificateId = create.CertificateId,
                    AutomaticGenerateCertificate = create.AutomaticGenerateCertificate,
                    CourseMaterialId = create.CourseMaterialId,
                    SendEmail = create.SendEmail,
                    SendMessageId = create.EmailTemplateId,
                    CourseWithLector = create.CourseWithLector
                };
            _ = course.CourseTranslations = _ = course.CourseTranslations.PrepareTranslation(create.Name, create.Description, create.CultureId);
            return Task.FromResult(course);
        }
    }
}
