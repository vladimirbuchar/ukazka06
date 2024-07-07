using Model.Edu.PersonAddress;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CodeBook
{
    [Table("Cb_AddressType")]
    public class AddressTypeDbo : CodeBook
    {
        public virtual IEnumerable<PersonAddressDbo> PersonAddresses { get; set; }
    }
}
