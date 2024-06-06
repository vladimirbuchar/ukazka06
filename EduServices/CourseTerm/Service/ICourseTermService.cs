using Core.Base.Service;
using EduServices.CourseTerm.Dto;
using Model.Tables.Edu.CourseTerm;

namespace EduServices.CourseTerm.Service
{
    public interface ICourseTermService : IBaseService<CourseTermDbo, CourseTermCreateDto, CourseTermListDto, CourseTermDetailDto, CourseTermUpdateDto> { }
}
