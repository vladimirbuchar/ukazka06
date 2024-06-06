using Core.Base.Dto;

namespace EduServices.Note.Dto
{



    public class NoteUpdateDto : UpdateDto
    {
        public string Text { get; set; }
        public string NoteName { get; set; }
    }
}
