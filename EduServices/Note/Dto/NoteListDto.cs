using Core.Base.Dto;

namespace Services.Note.Dto
{
    public class NoteListDto : ListDto
    {
        public string NoteType { get; set; }
        public string NoteName { get; set; }
    }
}
