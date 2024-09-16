using Core.Base.Filter;

namespace CourseMaterialService.CourseMaterial.CourseMaterialList.Filter
{
    public class CourseMaterialFilter : RequestFilter
    {
        public string? Name { get; set; }
    }
}
