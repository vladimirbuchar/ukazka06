using Core.Base.Dto;

namespace EduServices.Note.Dto
{
    public class NoteDetailDto : DetailDto
    {
        public string NoteType { get; set; }
        public string NoteName { get; set; }
        public string Text { get; set; }
        public string FilePath { get; set; }
    }
}
