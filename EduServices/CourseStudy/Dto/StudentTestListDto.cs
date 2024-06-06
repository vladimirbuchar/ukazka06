using System;
using Core.Base.Dto;

namespace EduServices.CourseStudy.Dto
{
    public class StudentTestListDto : ListDto
    {
        public string Name { get; set; }
        public DateTime Finish { get; set; }
        public double Score { get; set; }
        public bool TestCompleted { get; set; }
        public Guid TestId { get; set; }
        public Guid CourseMaterialId { get; set; }
        public Guid CourseId { get; set; }
    }
}
