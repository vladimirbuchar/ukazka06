using Core.Base.Filter;

namespace OrganizationService.ClassRoom.ClassRoomList.Filter
{
    public class ClassRoomFilter : RequestFilter
    {
        public int? Floor { get; set; }
        public int? MaxCapacity { get; set; }
        public string? Name { get; set; }
    }
}
