using Core.Base.Dto;

namespace UserService.Note.NoteList.Dto
{
    public class NoteListDto : ListDto
    {
        public string? NoteType { get; set; }
        public string? NoteName { get; set; }
    }
}
