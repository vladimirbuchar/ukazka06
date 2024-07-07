using Model.CodeBook;
using Model.Edu.Organization;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Edu.OrganizationAddress
{
    [Table("Edu_OrganizationAddress")]
    public class OrganizationAddressDbo : TableModel
    {
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
        public virtual Guid? CountryId { get; set; }
        public virtual CountryDbo Country { get; set; }
        public virtual AddressTypeDbo AddressType { get; set; }
        public virtual Guid AddressTypeId { get; set; }
        public virtual Guid OrganizationId { get; set; }
        public virtual OrganizationDbo Organization { get; set; }
    }
}
