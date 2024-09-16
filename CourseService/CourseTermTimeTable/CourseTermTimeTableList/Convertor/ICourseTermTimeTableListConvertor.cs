using Core.Base.Convertor;
using Model.Edu.CourseTermDate;
using Services.CourseTermTimeTable.CourseTermTimeTableList.Dto;

namespace CourseService.CourseTermTimeTable.CourseTermTimeTableList.Convertor
{
    public interface ICourseTermTimeTableListConvertor : IBaseListConvertor<CourseTermDateDbo, CourseTermTimeTableListDto> { }
}
