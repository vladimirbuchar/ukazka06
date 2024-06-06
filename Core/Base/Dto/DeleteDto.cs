using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Base.Dto
{
    public class DeleteDto : BaseDto
    {
        [Required]
        public Guid Id { get; set; }

    }
}
