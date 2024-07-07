using Core.Base.Dto;
using System;

namespace Services.User.Dto
{
    public class MyAttendanceListDto : ListDto
    {
        public DateTime Date { get; set; }
        public string DayOfWeek { get; set; }
        public bool IsActive { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public string CourseName { get; set; }
    }
}
