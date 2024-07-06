using Core.Base.Convertor;
using EduServices.CourseTerm.Dto;
using Model.Edu.CourseTerm;

namespace EduServices.CourseTerm.Convertor
{
    public interface ICourseTermConvertor : IBaseConvertor<CourseTermDbo, CourseTermCreateDto, CourseTermListDto, CourseTermDetailDto, CourseTermUpdateDto> { }
}
