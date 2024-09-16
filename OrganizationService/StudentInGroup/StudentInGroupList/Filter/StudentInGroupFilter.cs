using Core.Base.Filter;

namespace OrganizationService.StudentInGroup.StudentInGroupList.Filter
{
    public class StudentInGroupFilter : RequestFilter
    {
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
    }
}
