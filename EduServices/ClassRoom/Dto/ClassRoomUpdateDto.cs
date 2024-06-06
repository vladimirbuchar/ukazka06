using Core.Base.Dto;

namespace EduServices.ClassRoom.Dto
{
    public class ClassRoomUpdateDto : UpdateDto
    {
        public int Floor { get; set; }
        public int MaxCapacity { get; set; }
        public string Name { get; set; }

    }

}
