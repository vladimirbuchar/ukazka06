using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.CodeBook;
using Model.Tables.Edu.Person;

namespace Model.Tables.Edu.PersonAddress
{
    [Table("Edu_PersonAddress")]
    public class PersonAddressDbo : TableModel
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
        public virtual AddressTypeDbo AddressType { get; set; }
        public virtual Guid AddressTypeId { get; set; }
        public virtual PersonDbo Person { get; set; }
        public virtual Guid PersonId { get; set; }
        public virtual Guid? CountryId { get; set; }
        public virtual CountryDbo Country { get; set; }
    }
}
