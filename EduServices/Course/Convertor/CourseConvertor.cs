using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.Certificate;
using Model.Edu.Course;
using Model.Edu.CourseLesson;
using Model.Edu.CourseMaterial;
using Model.Edu.Message;
using Services.Course.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Services.Course.Convertor
{
    public class CourseConvertor(ICodeBookRepository<CourseTypeDbo> courseType, ICodeBookRepository<CultureDbo> culture) : ICourseConvertor
    {
        private readonly List<CourseTypeDbo> _courseTypes = courseType.GetEntities(false).Result;

        private readonly List<CultureDbo> _cultureList = culture.GetEntities(false).Result;

        public CourseDbo ConvertToBussinessEntity(CourseCreateDto addCourseDto, string culture)
        {
            CourseDbo course =
                new()
                {
                    Price = addCourseDto.Price,
                    Sale = addCourseDto.Sale,
                    CourseStatusId = addCourseDto.CourseStatusId,
                    CourseTypeId = addCourseDto.CourseTypeId,
                    OrganizationId = addCourseDto.OrganizationId,
                    IsPrivateCourse = addCourseDto.IsPrivateCourse,
                    MaximumStudent = addCourseDto.DefaultMaximumStudents,
                    MinimumStudent = addCourseDto.DefaultMinimumStudents,
                    CertificateId = addCourseDto.CertificateId,
                    AutomaticGenerateCertificate = addCourseDto.AutomaticGenerateCertificate,
                    CourseMaterialId = addCourseDto.CourseMaterialId,
                    SendEmail = addCourseDto.SendEmail,
                    SendMessageId = addCourseDto.EmailTemplateId,
                    CourseWithLector = addCourseDto.CourseWithLector
                };
            _ =
                course.CourseTranslations =
                _ =
                    course.CourseTranslations.PrepareTranslation(addCourseDto.Name, addCourseDto.Description, culture, _cultureList);
            return course;
        }

        public CourseDbo ConvertToBussinessEntity(CourseUpdateDto updateCourseDto, CourseDbo entity, string culture)
        {
            entity.CourseTranslations = entity.CourseTranslations.PrepareTranslation(
                updateCourseDto.Name,
                updateCourseDto.Description,
                culture,
                _cultureList
            );
            entity.Price = updateCourseDto.Price;
            entity.Sale = updateCourseDto.Sale;
            entity.CourseStatusId = updateCourseDto.CourseStatusId;
            entity.CourseTypeId = updateCourseDto.CourseTypeId;
            entity.IsPrivateCourse = updateCourseDto.IsPrivateCourse;
            entity.MaximumStudent = updateCourseDto.DefaultMaximumStudents;
            entity.MinimumStudent = updateCourseDto.DefaultMinimumStudents;
            entity.CertificateId = updateCourseDto.CertificateId;
            entity.AutomaticGenerateCertificate = updateCourseDto.AutomaticGenerateCertificate;
            entity.CourseMaterialId = updateCourseDto.CourseMaterialId;
            entity.SendEmail = updateCourseDto.SendEmail;
            entity.SendMessageId = updateCourseDto.EmailTemplateId;
            entity.CourseWithLector = updateCourseDto.CourseWithLector;
            return entity;
        }

        public List<CourseListDto> ConvertToWebModel(List<CourseDbo> getAllCourseInOrganizations, string culture)
        {
            return getAllCourseInOrganizations
                .Select(item => new CourseListDto()
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
                .ToList();
        }

        public CourseDetailDto ConvertToWebModel(CourseDbo getCourseDetail, string culture)
        {
            return new CourseDetailDto()
            {
                CourseStatusId = getCourseDetail.CourseStatusId,
                Description = getCourseDetail.CourseTranslations.FindTranslation(culture).Description,
                Name = getCourseDetail.CourseTranslations.FindTranslation(culture).Name,
                CourseTypeId = getCourseDetail.CourseTypeId,
                FileName = "",
                Id = getCourseDetail.Id,
                IsPrivateCourse = getCourseDetail.IsPrivateCourse,
                Price = getCourseDetail.Price,
                Sale = getCourseDetail.Sale,
                CourseType = _courseTypes.FirstOrDefault(x => x.Id == getCourseDetail.CourseTypeId).SystemIdentificator,
                MaximumStudent = getCourseDetail.MaximumStudent,
                MinimumStudent = getCourseDetail.MinimumStudent,
                CertificateId = getCourseDetail.CertificateId,
                AutomaticGenerateCertificate = getCourseDetail.AutomaticGenerateCertificate,
                CourseMaterialId = getCourseDetail.CourseMaterialId,
                SendEmail = getCourseDetail.SendEmail,
                SendMessageId = getCourseDetail.SendMessageId,
                CourseWithLector = getCourseDetail.CourseWithLector
            };
        }


    }
}
