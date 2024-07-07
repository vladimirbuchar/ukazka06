using Core.Base.Dto;

namespace Services.ClassRoom.Dto
{
    public class ClassRoomUpdateDto : UpdateDto
    {
        public int Floor { get; set; }
        public int MaxCapacity { get; set; }
        public string Name { get; set; }

    }

}
