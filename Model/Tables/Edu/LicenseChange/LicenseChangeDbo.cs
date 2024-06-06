using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.CodeBook;
using Model.Tables.Edu.Organization;

namespace Model.Tables.Edu.LicenseChange
{
    [Table("Edu_LicenseChange")]
    public class LicenseChangeDbo : TableModel
    {
        [Column("LicenseChange")]
        public virtual DateTime LicenseChange { get; set; }
        public virtual LicenseDbo LicenseOld { get; set; }
        public virtual Guid LicenseOldId { get; set; }
        public virtual OrganizationDbo Organization { get; set; }
        public virtual Guid OrganizationId { get; set; }
    }
}
