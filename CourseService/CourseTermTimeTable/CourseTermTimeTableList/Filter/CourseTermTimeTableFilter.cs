using Core.Base.Filter;

namespace CourseService.CourseTermTimeTable.CourseTermTimeTableList.Filter
{
    public class CourseTermTimeTableFilter : RequestFilter
    {
        public bool? IsCanceled { get; set; }
        public string? DayOfWeek { get; set; }

        //public string TimeFrom { get; set; }
        //public string TimeTo { get; set; }
        public DateTime? Date { get; set; }
        public string? Lector { get; set; }
        //public string ClassRoom { get; set; }
    }
}
