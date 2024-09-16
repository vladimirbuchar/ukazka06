using Core.Base.Dto;
using UserService.User.Dto;

namespace UserService.UserProfile.MyTimeTable.Dto
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
