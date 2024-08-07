﻿using System;
using System.Text.Json.Serialization;
using Core.Base.Dto;

namespace Services.CourseTermStudent.Dto
{
    public class CourseTermStudentCreateDto : CreateDto
    {
        public string UserEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid CourseTermId { get; set; }

        [JsonIgnore]
        public Guid OrganizationId { get; set; }
    }
}
