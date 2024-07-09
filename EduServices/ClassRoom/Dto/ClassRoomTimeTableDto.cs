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

        public List<StudyHourListDto> StudyHours { get; set; }
        public List<TimeTableDto> TimeTable { get; set; }
    }
}
