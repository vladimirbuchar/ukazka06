using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Edu.Note;

namespace Model.CodeBook
{
    [Table("Cb_NoteType")]
    public class NoteTypeDbo : CodeBook
    {
        public virtual IEnumerable<NoteDbo> NoteDbos { get; set; }
    }
}
