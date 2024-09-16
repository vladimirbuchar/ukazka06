using Core.Base.Convertor;
using CourseService.CourseTerm.CourseTermDetail.Dto;
using Model.Edu.CourseTerm;

namespace CourseService.CourseTerm.CourseTermDetail.Convertor
{
    public interface ICourseTermDetailConvertor : IBaseDetailConvertor<CourseTermDbo, CourseTermDetailDto> { }
}
