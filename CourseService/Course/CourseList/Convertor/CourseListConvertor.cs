using CourseService.Course.CourseList.Dto;
using Model.Edu.Certificate;
using Model.Edu.Course;
using Model.Edu.CourseMaterial;
using Model.Edu.Message;

namespace CourseService.Course.CourseList.Convertor
{
    public class CourseListConvertor : ICourseListConvertor
    {
        public Task<List<CourseListDto>> ConvertToWebModel(List<CourseDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(item => new CourseListDto()
                {
                    Id = item.Id,
                    Name = item.CourseTranslations.FindTranslation(culture).Name,
                    AutomaticGenerateCertificate = item.AutomaticGenerateCertificate,
                    CertificateId = item.CertificateId.HasValue ? item.CertificateId.Value : null,
                    CourseMaterialId = item.CourseMaterialId.HasValue ? item.CourseMaterialId.Value : null,
                    CourseStatusId = item.CourseStatusId,
                    CourseTypeId = item.CourseTypeId,
                    CourseWithLector = item.CourseWithLector,
                    IsPrivateCourse = item.IsPrivateCourse,
                    MaximumStudent = item.MaximumStudent,
                    MinimumStudent = item.MinimumStudent,
                    Price = item.Price,
                    Sale = item.Sale,
                    SendEmail = item.SendEmail,
                    SendMessageId = item.SendMessageId.HasValue ? item.SendMessageId.Value : null,
                    CertificateName = item.Certificate?.CertificateTranslations.FindTranslation(culture).Name,
                    CourseMaterialName = item.CourseMaterial?.CourseMaterialTranslation.FindTranslation(culture).Name,
                    CourseTypeName = item.CourseType.Name,
                    CouseStatusName = item.CourseStatus.Name,
                    SendMessageName = item.SendMessage?.SendMessageTranslations.FindTranslation(culture).Subject
                })
                    .ToList()
            );
        }
    }
}
