using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Base.Dto
{
    public class ListRequestDto : BaseDto
    {
        [Required]
        public Guid ParentId { get; set; }
    }
}
