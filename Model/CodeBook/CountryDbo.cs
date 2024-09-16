using Model.Edu.Branch;
using Model.Edu.PersonAddress;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CodeBook
{
    [Table("Cb_Country")]
    public class CountryDbo : CodeBookModel
    {
        public virtual IEnumerable<BranchDbo> Branchs { get; set; }
        public virtual IEnumerable<PersonAddressDbo> PersonAddresses { get; set; }
    }
}
