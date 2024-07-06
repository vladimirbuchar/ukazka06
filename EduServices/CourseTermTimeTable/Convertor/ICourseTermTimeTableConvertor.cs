using System.Collections.Generic;
using Core.Base.Convertor;
using EduServices.CourseTermTimeTable.Dto;
using Model.Edu.CourseTermDate;

namespace EduServices.CourseTermTimeTable.Convertor
{
    public interface ICourseTermTimeTableConvertor : IBaseConvertor
    {
        HashSet<CourseTermTimeTableListDto> ConvertToWebModel(HashSet<CourseTermDateDbo> getTimeTables, string culture);
    }
}
