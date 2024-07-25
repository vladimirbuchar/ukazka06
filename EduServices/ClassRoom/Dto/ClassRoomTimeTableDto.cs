using Core.Base.Dto;
using Services.OrganizationStudyHour.Dto;
using System.Collections.Generic;

namespace Services.ClassRoom.Dto
{
    public class ClassRoomTimeTableDto : ListDto
    {
        public ClassRoomTimeTableDto()
        {
            StudyHours = [];
        }

        public List<StudyHourListDto> StudyHours { get; set; }

    }
}
