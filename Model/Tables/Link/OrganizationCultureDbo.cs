using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.CodeBook;
using Model.Tables.Edu.Organization;

namespace Model.Tables.Link
{
    [Table("Link_OrganizationCulture")]
    public class OrganizationCultureDbo : TableModel
    {
        public virtual OrganizationDbo Organization { get; set; }
        public virtual Guid OrganizationId { get; set; }
        public virtual CultureDbo Culture { get; set; }
        public virtual Guid CultureId { get; set; }
        public virtual bool IsDefault { get; set; }
    }
}
