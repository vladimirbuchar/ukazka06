using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Edu.PersonAddress;

namespace Model.CodeBook
{
    [Table("Cb_AddressType")]
    public class AddressTypeDbo : CodeBook
    {
        public virtual IEnumerable<PersonAddressDbo> PersonAddresses { get; set; }
    }
}
