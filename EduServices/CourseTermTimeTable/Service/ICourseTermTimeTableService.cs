﻿using Core.Base.Service;
using Core.DataTypes;
using EduServices.CourseTermTimeTable.Dto;
using System;
using System.Collections.Generic;

namespace EduServices.CourseTermTimeTable.Service
{
    public interface ICourseTermTimeTableService : IBaseService
    {
        Result GenerateTimeTable(DateTime activeFrom, DateTime activeTo, Guid timeFromId, Guid timeToId, List<bool> days, Guid courseTermId, List<string> lectors, Guid classRoomId);
        HashSet<CourseTermTimeTableListDto> GetTimeTable(Guid courseTermId, string culture);
        Result CancelCourseTerm(Guid courseTermTimeTableId);
        Result Restore(Guid courseTermTimeTableId);
        Result GenerateTimeTable(Guid courseTermId);
    }
}