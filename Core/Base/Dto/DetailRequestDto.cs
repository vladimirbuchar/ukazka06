using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Base.Dto
{
    public class DetailRequestDto : BaseDto
    {
        [Required]
        public Guid Id { get; set; }


    }
}
