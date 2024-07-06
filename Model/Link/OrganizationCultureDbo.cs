using Model.CodeBook;
using Model.Edu.Organization;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Link
{
    [Table("Link_OrganizationCulture")]
    public class OrganizationCultureDbo : TableModel
    {
        public virtual OrganizationDbo Organization { get; set; }
        public virtual Guid OrganizationId { get; set; }
        public virtual CultureDbo Culture { get; set; }
        public virtual Guid CultureId { get; set; }
        [Column("IsDefault")]
        public virtual bool IsDefault { get; set; }
    }
}
