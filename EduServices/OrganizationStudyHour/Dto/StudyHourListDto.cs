using System;
using Core.Base.Dto;

namespace EduServices.OrganizationStudyHour.Dto
{
    public class StudyHourListDto : ListDto
    {
        public string ActiveFrom { get; set; }
        public string ActiveTo { get; set; }
        public int Position { get; set; }
        public Guid ActiveFromId { get; set; }
        public Guid ActiveToId { get; set; }
    }
}
