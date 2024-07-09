using System.Collections.Generic;
using System.Linq;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.Course;
using Model.Edu.CourseLesson;
using Model.Edu.StudentTestSummary;
using Services.Course.Dto;
using Services.CourseStudy.Dto;

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
                .Select(item => new CourseListDto() { Id = item.Id, Name = item.CourseTranslations.FindTranslation(culture).Name, })
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

        public List<StudentTestListDto> ConvertToWebModel(List<StudentTestSummaryDbo> getStudentTests, string culture)
        {
            return getStudentTests
                .Select(x => new StudentTestListDto()
                {
                    Finish = x.Finish.Value,
                    Id = x.Id,
                    Name = x.CourseTest.CourseLesson.CourseLessonTranslations.FindTranslation(culture).Name,
                    Score = x.Score,
                    TestCompleted = x.IsSucess,
                    TestId = x.CourseTestId,
                    CourseMaterialId = x.CourseTest.CourseLesson.CourseMaterialId,
                    CourseId = x.CourseId
                })
                .ToList();
        }
    }
}
