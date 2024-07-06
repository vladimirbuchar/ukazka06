using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.CodeBook;
using Model.Edu.Organization;

namespace Model.Edu.OrganizationStudyHour
{
    [Table("Edu_OrganizationStudyHour")]
    public class OrganizationStudyHourDbo : TableModel
    {
        [Column("Position")]
        public virtual int Position { get; set; }

        [Column("ActiveFrom")]
        public virtual TimeTableDbo ActiveFrom { get; set; }
        public virtual Guid ActiveFromId { get; set; }

        [Column("ActiveTo")]
        public virtual TimeTableDbo ActiveTo { get; set; }
        public virtual Guid ActiveToId { get; set; }

        public virtual OrganizationDbo Organization { get; set; }
        public Guid OrganizationId { get; set; }
    }
}
