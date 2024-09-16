using Core.Base.Convertor;
using CourseService.CourseTerm.CourseTermCreate.Dto;
using Model.Edu.CourseTerm;

namespace CourseService.CourseTerm.CourseTermCreate.Convertor
{
    public interface ICourseTermCreateConvertor : IBaseCreateConvertor<CourseTermDbo, CourseTermCreateDto> { }
}
