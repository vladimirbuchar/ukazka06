using Core.Base.Dto;

namespace UserService.User.Dto
{
    public class TimeTableDto : ListDto
    {
        public TimeTableDto()
        {
            CourseTerm = [];
        }

        public string DayOfWeek { get; set; }
        public List<string> CourseTerm { get; set; }
    }
}
