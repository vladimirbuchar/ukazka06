using Core.Base.Filter;
using System;
using System.Collections.Generic;

namespace Services.CourseTerm.Filter
{
    public class CourseTermFilter : FilterRequest
    {
        public bool? Monday { get; set; }
        public bool? Tuesday { get; set; }
        public bool? Wednesday { get; set; }
        public bool? Thursday { get; set; }
        public bool? Friday { get; set; }
        public bool? Saturday { get; set; }
        public bool? Sunday { get; set; }
        public List<Guid> BranchId { get; set; } = [];
        public List<Guid> ClassRoomId { get; set; } = [];
        public string TimeTo;
        public string TimeFrom;
        public DateTime? ActiveFrom { get; set; }
        public DateTime? ActiveTo { get; set; }
    }
}
