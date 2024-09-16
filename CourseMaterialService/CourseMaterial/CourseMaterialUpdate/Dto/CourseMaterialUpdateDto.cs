using Core.Base.Dto;

namespace CourseMaterialService.CourseMaterial.CourseMaterialUpdate.Dto
{
    public class CourseMaterialUpdateDto : UpdateDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
