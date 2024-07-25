using Core.Base.Service;
using Model.Edu.CourseTerm;
using Services.CourseTerm.Dto;
using Services.CourseTerm.Filter;

namespace Services.CourseTerm.Service
{
    public interface ICourseTermService
        : IBaseService<CourseTermDbo, CourseTermCreateDto, CourseTermListDto, CourseTermDetailDto, CourseTermUpdateDto, CourseTermFilter>
    { }
}
