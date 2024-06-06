using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Tables.Edu.PersonAddress;

namespace Model.Tables.Edu.Person
{
    [Table("Edu_Person")]
    public class PersonDbo : TableModel
    {
        [Column("FirstName")]
        public virtual string FirstName { get; set; }

        [Column("SecondName")]
        public virtual string SecondName { get; set; }

        [Column("LastName")]
        public virtual string LastName { get; set; }

        [Column("AvatarUrl")]
        public virtual string AvatarUrl { get; set; }
        public virtual ICollection<PersonAddressDbo> PersonAddress { get; set; }
    }
}
