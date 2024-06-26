﻿using System.Collections.Generic;
using Core.Base.Dto;

namespace EduServices.User.Dto
{
    public class TimeTableDto : ListDto
    {
        public TimeTableDto()
        {
            CourseTerm = [];
        }

        public string DayOfWeek { get; set; }
        public List<string> CourseTerm { get; set; }
    }
}
