using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Base.Dto
{
    public class ListDeletedRequestDto : ListRequestDto
    {
        public bool IsDeleted { get; set; } = false;
    }

    public class ListRequestDto : BaseDto
    {
        [Required]
        public Guid ParentId { get; set; }
    }
    public class ListDeletedRequestWithoutParentDto
    {
        public bool IsDeleted { get; set; } = false;
    }
}
