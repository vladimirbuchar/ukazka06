using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.Note;

namespace Model.Tables.CodeBook
{
    [Table("Cb_NoteType")]
    public class NoteTypeDbo : CodeBook
    {
        public virtual IEnumerable<NoteDbo> NoteDbos { get; set; }
    }
}
