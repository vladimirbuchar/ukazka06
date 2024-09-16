using Core.Base.Convertor;
using CourseService.CourseTermTimeTable.CourseTermTimeTableUpdate.Dto;
using Model.Edu.CourseTermDate;

namespace CourseService.CourseTermTimeTable.CourseTermTimeTableUpdate.Convertor
{
    public interface ICourseTermTimeTableUpdateConvertor : IBaseUpdateConvertor<CourseTermDateDbo, CourseTermTimeTableUpdateDto> { }
}
