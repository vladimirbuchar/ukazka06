using Core.Base.Dto;
using Core.Constants;

namespace CourseStudyService.Student.StudentCourseList.Dto
{
    public class StudentCourseListDto : ListDto
    {
        public string CourseName { get; set; } = string.Empty;
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        private string _timeTo = string.Empty;
        public string TimeTo
        {
            get => _timeTo == CodebookValue.CODEBOOK_SELECT_VALUE ? "" : _timeTo;
            set => _timeTo = value;
        }

        private string _timeFrom = string.Empty;
        public string TimeFrom
        {
            get => _timeFrom == CodebookValue.CODEBOOK_SELECT_VALUE ? "" : _timeFrom;
            set => _timeFrom = value;
        }
        public Guid UserId { get; set; }
        public string? ClassRoom { get; set; }
        public string? BranchName { get; set; }
        public bool Monday { get; set; }
        public bool Thursday { get; set; }
        public bool Wednesday { get; set; }
        public bool Tuesday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

        public string OrganizationName { get; set; } = string.Empty;
        public bool CourseFinish { get; set; }
        public Guid CourseTermId { get; set; }
    }
}
