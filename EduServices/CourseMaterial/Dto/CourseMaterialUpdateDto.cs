using Core.Base.Dto;

namespace Services.CourseMaterial.Dto
{
    public class CourseMaterialUpdateDto : UpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
