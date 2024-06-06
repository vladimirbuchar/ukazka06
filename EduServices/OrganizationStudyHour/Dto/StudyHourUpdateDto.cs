﻿using Core.Base.Dto;

namespace EduServices.OrganizationStudyHour.Dto
{


    public class StudyHourUpdateDto : UpdateDto
    {
        public string ActiveFromId { get; set; }
        public string ActiveToId { get; set; }
        public int Position { get; set; }
    }
}
