using Core.Base.Dto;

namespace CourseStudyService.Chat.ChatCreate.Dto
{
    public class ChatCreateDto : CreateDto
    {
        public Guid UserId { get; set; }
        public Guid CourseTermId { get; set; }
        public Guid ParentId { get; set; }
        public string? Text { get; set; }
    }
}
