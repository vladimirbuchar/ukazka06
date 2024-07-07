using Model.CodeBook;
using System;

namespace Model
{
    public class TranslationTableModel : TableModel
    {
        public virtual CultureDbo Culture { get; set; }
        public virtual Guid CultureId { get; set; }
    }
}
