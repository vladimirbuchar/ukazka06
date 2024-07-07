using System.Collections.Generic;
using Core.Base.Dto;
using Services.OrganizationStudyHour.Dto;
using Services.User.Dto;

namespace Services.ClassRoom.Dto
{
    public class ClassRoomTimeTableDto : ListDto
    {
        public ClassRoomTimeTableDto()
        {
            StudyHours = [];
            TimeTable = [];
        }

        public HashSet<StudyHourListDto> StudyHours { get; set; }
        public HashSet<TimeTableDto> TimeTable { get; set; }
    }
}
