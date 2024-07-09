using System.Collections.Generic;
using Core.Base.Dto;
using Services.OrganizationStudyHour.Dto;

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
        public List<StudyHourListDto> StudyHours { get; set; }
        public bool HaveStudyHours { get; set; }
        public List<TimeTableDto> TimeTable { get; set; }
    }
}
