﻿using Model.Edu.CourseTerm;
using Model.Edu.StudentGroup;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Link
{
    [Table("Link_StudentInGroupCourseTerm")]
    public class StudentInGroupCourseTermDbo : TableModel
    {
        public virtual CourseTermDbo CourseTerm { get; set; }
        public virtual Guid CourseTermId { get; set; }
        public virtual StudentGroupDbo StudentGroup { get; set; }
        public virtual Guid StudentGroupId { get; set; }
    }
}
