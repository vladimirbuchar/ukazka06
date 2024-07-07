using Core.Base.Dto;

namespace Services.Chat.Dto
{
    public class ChatItemUpdateDto : UpdateDto
    {
        public string Text { get; set; }
    }
}
