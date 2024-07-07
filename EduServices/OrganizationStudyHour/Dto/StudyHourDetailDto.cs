using Core.Base.Dto;
using System;

namespace Services.OrganizationStudyHour.Dto
{
    public class StudyHourDetailDto : DetailDto
    {
        public string ActiveFrom { get; set; }
        public string ActiveTo { get; set; }
        public int Position { get; set; }
        public Guid ActiveFromId { get; set; }
        public Guid ActiveToId { get; set; }
    }
}
