using Core.Base.Dto;

namespace OrganizationService.StudentInGroup.StudentInGroupList.Dto
{
    public class StudentInGroupListDto : ListDto
    {
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public Guid StudentId { get; set; }
        public string? Email { get; set; }
    }
}
