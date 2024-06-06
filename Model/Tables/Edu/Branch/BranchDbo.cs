using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.CodeBook;
using Model.Tables.Edu.ClassRoom;
using Model.Tables.Edu.Organization;

namespace Model.Tables.Edu.Branch
{
    [Table("Edu_Branch")]
    public class BranchDbo : TableModel
    {
        [Column("IsMainBranch")]
        public virtual bool IsMainBranch { get; set; }

        [Column("Region")]
        public virtual string Region { get; set; }

        [Column("City")]
        public virtual string City { get; set; }

        [Column("Street")]
        public virtual string Street { get; set; }

        [Column("HouseNumber")]
        public virtual string HouseNumber { get; set; }

        [Column("ZipCode")]
        public virtual string ZipCode { get; set; }

        [Column("Email")]
        public virtual string Email { get; set; }

        [Column("PhoneNumber")]
        public virtual string PhoneNumber { get; set; }

        [Column("WWW")]
        public virtual string WWW { get; set; }

        [Column("IsOnline")]
        public virtual bool IsOnline { get; set; }
        public virtual OrganizationDbo Organization { get; set; }
        public virtual Guid OrganizationId { get; set; }
        public virtual Guid? CountryId { get; set; }
        public virtual CountryDbo Country { get; set; }
        public virtual ICollection<BranchTranslationDbo> BranchTranslations { get; set; }
        public virtual ICollection<ClassRoomDbo> ClassRoom { get; set; }
    }
}
