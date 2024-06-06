using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu.CourseMaterial
{
    [Table("Edu_CourseMaterialileRepository")]
    public class CourseMaterialFileRepositoryDbo : FileRepositoryModel
    {
        public CourseMaterialDbo CourseMaterial { get; set; }
        public Guid CourseMaterialId { get; set; }
    }
}
