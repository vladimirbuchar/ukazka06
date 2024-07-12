using Core.Base.Filter;

namespace Services.ClassRoom.Filter
{
    public class ClassRoomFilter : FilterRequest
    {
        public int? Floor { get; set; }
        public int? MaxCapacity { get; set; }
        public string Name { get; set; }
    }
}
