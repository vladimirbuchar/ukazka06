using Core.Base.Dto;
using Services.OrganizationStudyHour.OrganizationStudyHourList.Dto;

namespace OrganizationService.ClassRoom.ClassRoomTimeTable.Dto
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
