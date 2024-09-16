using Core.Base.Filter;

namespace CourseService.CourseTermStudent.CourseTermStudentList.Filter
{
    public class CourseTermStudentFilter : RequestFilter
    {
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public bool CourseFinish { get; set; }
    }
}
