﻿using System;
using Core.Base.Dto;

namespace EduServices.CourseStudy.Dto
{
    public class CourseLessonPowerPointFileDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PowerPointFile { get; set; }
    }
}
