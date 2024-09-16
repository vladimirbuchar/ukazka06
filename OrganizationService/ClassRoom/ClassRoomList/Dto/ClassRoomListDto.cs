using Core.Base.Dto;

namespace OrganizationService.ClassRoom.ClassRoomList.Dto
{
    public class ClassRoomListDto : ListDto
    {
        public int Floor { get; set; }
        public int MaxCapacity { get; set; }
        public string? Name { get; set; }
    }
}
