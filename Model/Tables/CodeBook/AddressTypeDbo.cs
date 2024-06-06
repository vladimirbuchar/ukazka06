using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.PersonAddress;

namespace Model.Tables.CodeBook
{
    [Table("Cb_AddressType")]
    public class AddressTypeDbo : CodeBook
    {
        public virtual IEnumerable<PersonAddressDbo> PersonAddresses { get; set; }
    }
}
