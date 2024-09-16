namespace Core.Base.Dto
{
    public class ListDeletedRequestDto : ListRequestDto
    {
        public bool IsDeleted { get; set; } = false;
    }
}
