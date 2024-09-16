using Core.Base.Filter;

namespace OrganizationService.StudentGroup.StudentGroupList.Filter
{
    public class StudentGroupFilter : RequestFilter
    {
        public string? Name { get; set; }
    }
}
