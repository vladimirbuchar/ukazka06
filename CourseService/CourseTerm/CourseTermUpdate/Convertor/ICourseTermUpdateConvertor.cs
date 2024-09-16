using Core.Base.Convertor;
using CourseService.CourseTerm.CourseTermUpdate.Dto;
using Model.Edu.CourseTerm;

namespace CourseService.CourseTerm.CourseTermUpdate.Convertor
{
    public interface ICourseTermUpdateConvertor : IBaseUpdateConvertor<CourseTermDbo, CourseTermUpdateDto> { }
}
