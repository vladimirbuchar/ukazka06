using Core.Base.Request;
using Core.Base.Service;
using Model.Edu.CourseTerm;
using Services.CourseTerm.Dto;

namespace Services.CourseTerm.Service
{
    public interface ICourseTermService
        : IBaseService<CourseTermDbo, CourseTermCreateDto, CourseTermListDto, CourseTermDetailDto, CourseTermUpdateDto, FilterRequest> { }
}
