using System;
using Model.Tables.CodeBook;

namespace Model
{
    public class TranslationTableModel : TableModel
    {
        public virtual CultureDbo Culture { get; set; }
        public virtual Guid CultureId { get; set; }
    }
}
