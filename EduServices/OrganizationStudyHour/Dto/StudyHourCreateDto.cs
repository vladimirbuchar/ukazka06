using Core.Base.Dto;
using System;

namespace EduServices.OrganizationStudyHour.Dto
{
    public class StudyHourCreateDto : CreateDto
    {
        public Guid OrganizationId { get; set; }
        public string ActiveFromId { get; set; }
        public string ActiveToId { get; set; }
        public int Position { get; set; }
        public int LessonLength { get; set; }

    }


}
