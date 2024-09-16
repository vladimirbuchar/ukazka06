using Core.Base.Dto;

namespace CourseStudyService.CourseStudy.SaveActiveSlide.Dto
{
    public class SaveActiveSlideDto : CreateDto
    {
        public Guid SlideId { get; set; }
        public Guid CourseId { get; set; }
    }
}
