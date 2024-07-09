using System.Collections.Generic;
using Core.Base.Convertor;
using Model.Edu.CourseTermDate;
using Services.CourseTermTimeTable.Dto;

namespace Services.CourseTermTimeTable.Convertor
{
    public interface ICourseTermTimeTableConvertor : IBaseConvertor
    {
        List<CourseTermTimeTableListDto> ConvertToWebModel(List<CourseTermDateDbo> getTimeTables, string culture);
    }
}
