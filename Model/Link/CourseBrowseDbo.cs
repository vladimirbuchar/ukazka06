﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Edu.Course;
using Model.Edu.CourseLessonItem;
using Model.Edu.User;

namespace Model.Link
{
    [Table("Link_CourseBrowse")]
    public class CourseBrowseDbo : TableModel
    {
        public virtual CourseDbo Course { get; set; }
        public Guid CourseId { get; set; }
        public virtual CourseLessonItemDbo CourseLessonItem { get; set; }
        public virtual Guid CourseLessonItemId { get; set; }
        public virtual UserDbo User { get; set; }
        public virtual Guid UserId { get; set; }
    }
}
