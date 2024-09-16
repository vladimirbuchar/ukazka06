using Core.Base.Validator;
using CourseService.CourseTermTimeTable.CourseTermTimeTableUpdate.Dto;
using Model.Edu.CourseTermDate;

namespace CourseService.CourseTermTimeTable.CourseTermTimeTableUpdate.Validator
{
    public interface ICourseTermTimeTableUpdatevalidator : IBaseUpdateValidator<CourseTermDateDbo, CourseTermTimeTableUpdateDto> { }
}
