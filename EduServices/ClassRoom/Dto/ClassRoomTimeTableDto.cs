using System.Collections.Generic;
using Core.Base.Dto;
using EduServices.OrganizationStudyHour.Dto;
using EduServices.User.Dto;

namespace EduServices.ClassRoom.Dto
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
