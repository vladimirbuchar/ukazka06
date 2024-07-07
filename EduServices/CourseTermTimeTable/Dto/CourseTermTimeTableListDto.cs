using Core.Base.Dto;
using System;

namespace Services.CourseTermTimeTable.Dto
{
    public class CourseTermTimeTableListDto : ListDto
    {
        public bool IsCanceled { get; set; }
        public string DayOfWeek { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public DateTime Date { get; set; }
        public string Lector { get; set; }
        public string ClassRoom { get; set; }
    }
}
