using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CodeBook
{
    [Table("Cb_Culture")]
    public class CultureDbo : CodeBook
    {
        [Column("IsEnvironmentCulture")]
        public virtual bool IsEnvironmentCulture { get; set; }
    }
}
