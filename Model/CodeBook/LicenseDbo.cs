﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Edu.Organization;

namespace Model.CodeBook
{
    [Table("Cb_License")]
    public class LicenseDbo : CodeBook
    {
        [Column("MounthPrice")]
        public virtual double MounthPrice { get; set; }

        [Column("OneYearSale")]
        public virtual double OneYearSale { get; set; }
        public virtual IEnumerable<OrganizationDbo> Organizations { get; set; }
    }
}
