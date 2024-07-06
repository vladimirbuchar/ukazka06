using Model.Edu.Organization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CodeBook
{
    [Table("Cb_License")]
    public class LicenseDbo : CodeBook
    {
        [Column("MounthPrice")]
        public virtual double MounthPrice { get; set; }

        [Column("OneYearSale")]
        public virtual double OneYearSale { get; set; }
        public virtual IEnumerable<OrganizationDbo> Organizations { get; set; }
    }
}
