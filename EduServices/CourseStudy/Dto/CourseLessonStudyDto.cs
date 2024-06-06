using System;
using System.Collections.Generic;

namespace EduServices.CourseStudy.Dto
{
    public class CourseLessonStudyDto
    {
        public CourseLessonStudyDto()
        {
            Questions = [];
        }

        public Guid SlideId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string TemplateIdentificator { get; set; }
        public string Html { get; set; } = "";
        public string ImagePath { get; set; }
        public int TimeLimit { get; set; }
        public HashSet<CourseLessonQuestionStudyDto> Questions { get; set; }
        public string PowerPointFile { get; set; }
        public string Youtube { get; set; } = "";
        public bool CanRunTest { get; set; } = false;
    }
}
