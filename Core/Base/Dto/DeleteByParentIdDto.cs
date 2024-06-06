using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Base.Dto
{
    public class DeleteByParentIdDto : BaseDto
    {
        [Required]
        public Guid ParentId { get; set; }
    }
}
