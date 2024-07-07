using Core.Base.Dto;
using System;
using System.Text.Json.Serialization;

namespace Services.ClassRoom.Dto
{
    public class ClassRoomCreateDto : CreateDto
    {
        public int Floor { get; set; }
        public int MaxCapacity { get; set; }
        public Guid BranchId { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public bool IsOnline { get; set; }

    }
}


