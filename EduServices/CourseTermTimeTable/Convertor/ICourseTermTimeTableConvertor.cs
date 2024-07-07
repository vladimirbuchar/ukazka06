using System.Collections.Generic;
using Core.Base.Convertor;
using Model.Edu.CourseTermDate;
using Services.CourseTermTimeTable.Dto;

namespace Services.CourseTermTimeTable.Convertor
{
    public interface ICourseTermTimeTableConvertor : IBaseConvertor
    {
        HashSet<CourseTermTimeTableListDto> ConvertToWebModel(HashSet<CourseTermDateDbo> getTimeTables, string culture);
    }
}
