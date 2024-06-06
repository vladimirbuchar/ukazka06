using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.CourseTerm;
using Model.Tables.Edu.CourseTermDate;
using Model.Tables.Edu.OrganizationStudyHour;

namespace Model.Tables.CodeBook
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
