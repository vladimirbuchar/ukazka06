using Core.Base.Dto;

namespace EduServices.CourseMaterial.Dto
{
    public class CourseMaterialUpdateDto : UpdateDto
    {

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
