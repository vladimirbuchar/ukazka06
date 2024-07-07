using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.CodeBook;

namespace Model
{
    public abstract class FileRepositoryModel : TableModel
    {
        [Column("FileName")]
        public string FileName { get; set; }

        [Column("OriginalFileName")]
        public string OriginalFileName { get; set; }

        [Column("FileContent")]
        public byte[] FileContent { get; set; }
        public CultureDbo Culture { get; set; }
        public Guid CultureId { get; set; }
    }
}
