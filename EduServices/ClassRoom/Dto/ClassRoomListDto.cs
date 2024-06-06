using Core.Base.Dto;

namespace EduServices.ClassRoom.Dto
{
    public class ClassRoomListDto : ListDto
    {
        public int Floor { get; set; }
        public int MaxCapacity { get; set; }
        public string Name { get; set; }
        public bool IsOnline { get; set; }
    }
}
