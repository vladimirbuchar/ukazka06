using Model.CodeBook;
using Model.Edu.AttendanceStudent;
using Model.Edu.Chat;
using Model.Edu.ClassRoom;
using Model.Edu.Course;
using Model.Edu.CourseTermDate;
using Model.Edu.Notification;
using Model.Edu.OrganizationStudyHour;
using Model.Link;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.CourseTerm
{
    [Table("Edu_CourseTerm")]
    public class CourseTermDbo : TableModel
    {
        [Column("ActiveFrom")]
        public virtual DateTime? ActiveFrom { get; set; }

        [Column("ActiveTo")]
        public virtual DateTime? ActiveTo { get; set; }

        [Column("RegistrationFrom")]
        public virtual DateTime? RegistrationFrom { get; set; }

        [Column("RegistrationTo")]
        public virtual DateTime? RegistrationTo { get; set; }

        [Column("Monday")]
        public virtual bool Monday { get; set; }

        [Column("Tuesday")]
        public virtual bool Tuesday { get; set; }

        [Column("Wednesday")]
        public virtual bool Wednesday { get; set; }

        [Column("Thursday")]
        public virtual bool Thursday { get; set; }

        [Column("Friday")]
        public virtual bool Friday { get; set; }

        [Column("Saturday")]
        public virtual bool Saturday { get; set; }

        [Column("Sunday")]
        public virtual bool Sunday { get; set; }

        [Column("MinimumStudent")]
        public virtual int MinimumStudent { get; set; }

        [Column("MaximumStudent")]
        public virtual int MaximumStudent { get; set; }

        [Column("Price")]
        public virtual double Price { get; set; }

        [Column("Sale")]
        public virtual int Sale { get; set; }
        public virtual TimeTableDbo TimeFrom { get; set; }
        public virtual Guid TimeFromId { get; set; }
        public virtual TimeTableDbo TimeTo { get; set; }
        public virtual Guid TimeToId { get; set; }
        public virtual ClassRoomDbo ClassRoom { get; set; }
        public virtual Guid ClassRoomId { get; set; }
        public virtual OrganizationStudyHourDbo OrganizationStudyHour { get; set; }
        public virtual Guid? OrganizationStudyHourId { get; set; }
        public virtual Guid CourseId { get; set; }
        public virtual CourseDbo Course { get; set; }
        public virtual ICollection<AttendanceStudentDbo> AttendanceStudents { get; set; }
        public virtual ICollection<CourseTermDateDbo> CourseTermDate { get; set; }
        public virtual ICollection<StudentInGroupCourseTermDbo> StudentInGroupCourseTerms { get; set; }
        public virtual ICollection<CourseLectorDbo> CourseLectors { get; set; }
        public virtual ICollection<CourseStudentDbo> CourseStudents { get; set; }
        public virtual ICollection<ChatDbo> Chats { get; set; }
        public virtual ICollection<NotificationDbo> Notifications { get; set; }
    }
}
