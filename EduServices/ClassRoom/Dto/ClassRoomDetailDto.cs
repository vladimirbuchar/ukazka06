using Core.Base.Dto;

namespace Services.ClassRoom.Dto
{
    public class ClassRoomDetailDto : DetailDto
    {
        public int Floor { get; set; }
        public int MaxCapacity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
