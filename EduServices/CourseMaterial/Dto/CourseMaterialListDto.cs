using Core.Base.Dto;

namespace Services.CourseMaterial.Dto
{
    public class CourseMaterialListDto : ListDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
