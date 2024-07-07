using Core.Base.Dto;
using Services.OrganizationStudyHour.Dto;
using System.Collections.Generic;

namespace Services.User.Dto
{
    public class MyTimeTableListDto : ListDto
    {
        public MyTimeTableListDto()
        {
            StudyHours = [];
            TimeTable = [];
        }

        public string OrganizationName { get; set; }
        public HashSet<StudyHourListDto> StudyHours { get; set; }
        public bool HaveStudyHours { get; set; }
        public HashSet<TimeTableDto> TimeTable { get; set; }
    }
}
