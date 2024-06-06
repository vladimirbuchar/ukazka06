using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.Branch;
using Model.Tables.Edu.PersonAddress;

namespace Model.Tables.CodeBook
{
    [Table("Cb_Country")]
    public class CountryDbo : CodeBook
    {
        public virtual IEnumerable<BranchDbo> Branchs { get; set; }
        public virtual IEnumerable<PersonAddressDbo> PersonAddresses { get; set; }
    }
}
