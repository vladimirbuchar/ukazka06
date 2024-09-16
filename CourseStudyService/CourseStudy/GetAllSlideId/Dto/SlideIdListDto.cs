using Core.Base.Dto;

namespace CourseStudyService.CourseStudy.GetAllSlideId.Dto
{
    public class SlideIdListDto : ListDto
    {
        public Guid ParentId { get; set; }
        public string? Name { get; set; }
    }
}
