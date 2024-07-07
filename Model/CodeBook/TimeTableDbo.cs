using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Edu.CourseTerm;
using Model.Edu.CourseTermDate;
using Model.Edu.OrganizationStudyHour;

namespace Model.CodeBook
{
    [Table("Cb_TimeTable")]
    public class TimeTableDbo : CodeBook
    {
        public virtual IEnumerable<OrganizationStudyHourDbo> OrganizationStudyHourFrom { get; set; }
        public virtual IEnumerable<OrganizationStudyHourDbo> OrganizationStudyHourTo { get; set; }
        public virtual IEnumerable<CourseTermDbo> CourseTermFrom { get; set; }
        public virtual IEnumerable<CourseTermDbo> CourseTermTo { get; set; }
        public virtual IEnumerable<CourseTermDateDbo> CourseTermDateFrom { get; set; }
        public virtual IEnumerable<CourseTermDateDbo> CourseTermDateTo { get; set; }
    }
}
