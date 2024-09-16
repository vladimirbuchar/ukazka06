using Core.Base.Convertor;
using CourseService.CourseTerm.CourseTermList.Dto;
using Model.Edu.CourseTerm;

namespace CourseService.CourseTerm.CourseTermList.Convertor
{
    public interface ICourseTermListConvertor : IBaseListConvertor<CourseTermDbo, CourseTermListDto> { }
}
