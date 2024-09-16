using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Base.Dto
{
    public class RestoreDto : BaseDto
    {
        [Required]
        public Guid Id { get; set; }
    }
}
