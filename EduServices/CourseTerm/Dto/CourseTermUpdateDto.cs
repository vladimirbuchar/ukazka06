﻿using Core.Base.Dto;
using System;
using System.Collections.Generic;

namespace EduServices.CourseTerm.Dto
{
    public class CourseTermUpdateDto : UpdateDto
    {
        public double Price { get; set; }
        public int Sale { get; set; }
        public DateTime? ActiveFrom { get; set; }
        public DateTime? ActiveTo { get; set; }
        public DateTime? RegistrationFrom { get; set; }
        public DateTime? RegistrationTo { get; set; }
        public int MinimumStudents { get; set; }
        public int MaximumStudents { get; set; }
        public Guid? ClassRoomId { get; set; } = null;
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public Guid TimeFromId { get; set; }
        public Guid TimeToId { get; set; }
        public List<string> Lector { get; set; }
        public List<string> StudentGroup { get; set; }
        public string OrganizationStudyHourId { get; set; }
        public Guid OrganizationId { get; set; }
    }
}
