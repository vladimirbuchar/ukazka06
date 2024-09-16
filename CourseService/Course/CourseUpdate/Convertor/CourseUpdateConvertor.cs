using CourseService.Course.CourseUpdate.Dto;
using Model.Edu.Course;

namespace CourseService.Course.CourseUpdate.Convertor
{
    public class CourseUpdateConvertor : ICourseUpdateConvertor
    {
        public Task<CourseDbo> ConvertToBussinessEntity(CourseUpdateDto update, CourseDbo entity, string culture)
        {
            entity.CourseTranslations = entity.CourseTranslations.PrepareTranslation(update.Name, update.Description, update.CultureId);
            entity.Price = update.Price;
            entity.Sale = update.Sale;
            entity.CourseStatusId = update.CourseStatusId;
            entity.CourseTypeId = update.CourseTypeId;
            entity.IsPrivateCourse = update.IsPrivateCourse;
            entity.MaximumStudent = update.DefaultMaximumStudents;
            entity.MinimumStudent = update.DefaultMinimumStudents;
            entity.CertificateId = update.CertificateId;
            entity.AutomaticGenerateCertificate = update.AutomaticGenerateCertificate;
            entity.CourseMaterialId = update.CourseMaterialId;
            entity.SendEmail = update.SendEmail;
            entity.SendMessageId = update.EmailTemplateId;
            entity.CourseWithLector = update.CourseWithLector;
            return Task.FromResult(entity);
        }
    }
}
