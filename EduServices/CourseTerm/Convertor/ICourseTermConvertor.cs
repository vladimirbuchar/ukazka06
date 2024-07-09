using Core.Base.Convertor;
using Model.Edu.CourseTerm;
using Services.CourseTerm.Dto;

namespace Services.CourseTerm.Convertor
{
    public interface ICourseTermConvertor
        : IBaseConvertor<CourseTermDbo, CourseTermCreateDto, CourseTermListDto, CourseTermDetailDto, CourseTermUpdateDto> { }
}
