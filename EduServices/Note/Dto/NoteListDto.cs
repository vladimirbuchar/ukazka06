using Core.Base.Dto;

namespace EduServices.Note.Dto
{
    public class NoteListDto : ListDto
    {
        public string NoteType { get; set; }
        public string NoteName { get; set; }
    }
}
