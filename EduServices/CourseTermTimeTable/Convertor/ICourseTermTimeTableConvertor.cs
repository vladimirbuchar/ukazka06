using Core.Base.Convertor;
using Model.Edu.CourseTermDate;
using Services.CourseTermTimeTable.Dto;
using System.Collections.Generic;

namespace Services.CourseTermTimeTable.Convertor
{
    public interface ICourseTermTimeTableConvertor : IBaseConvertor
    {
        HashSet<CourseTermTimeTableListDto> ConvertToWebModel(HashSet<CourseTermDateDbo> getTimeTables, string culture);
    }
}
